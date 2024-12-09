using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingListService
{
    private readonly BitsContext _context;

    public ShoppingListService(BitsContext context)
    {
        _context = context;
    }

    public List<ShoppingListGroup> GetShoppingList(DateTime startDate, DateTime endDate)
    {
        // Get ingredients needing reorder
        var ingredients = _context.Ingredients
            .Where(i => i.OnHandQuantity <= i.ReorderPoint)
            .ToList();

        // Create shopping list groups by supplier
        var groups = ingredients
            .GroupBy(i => GetLastSupplier(i.IngredientId))
            .Select(g =>
            {
                var lastSupplier = g.Key;
                return new ShoppingListGroup
                {
                    SupplierId = lastSupplier.Supplier?.SupplierId,
                    SupplierName = lastSupplier.Supplier?.Name ?? "No Supplier",
                    Items = g.Select(i => new ShoppingListItem
                    {
                        Ingredient = i,
                        QuantityToOrder = (decimal)CalculateOrderQuantity(i, startDate, endDate),  // Add cast here
                        CurrentOrders = (decimal)GetCurrentOrders(i.IngredientId),                 // Add cast here
                        ScheduledUsage = GetScheduledUsage(i.IngredientId, startDate, endDate),
                        UnitCost = i.UnitCost
                    }).ToList()
                };
            })
            .ToList();

        return groups;
    }

    private (Supplier Supplier, decimal LastUnitCost) GetLastSupplier(int ingredientId)
    {
        // Get the most recent supplier and cost for this ingredient
        var lastOrder = _context.IngredientInventoryAdditions
            .Where(a => a.IngredientId == ingredientId && a.TransactionDate != null)
            .OrderByDescending(a => a.TransactionDate)
            .Select(a => new { a.Supplier, a.UnitCost })
            .FirstOrDefault();

        return lastOrder != null ? (lastOrder.Supplier, lastOrder.UnitCost) : (null, 0);
    }

    private double GetCurrentOrders(int ingredientId)
    {
        return _context.IngredientInventoryAdditions
            .Where(a => a.IngredientId == ingredientId && a.TransactionDate == null)
            .Sum(a => a.Quantity);
    }

    private double GetScheduledUsage(int ingredientId, DateTime startDate, DateTime endDate)
    {
        var scheduledBatches = _context.Batches
            .Where(b => b.ScheduledStartDate >= startDate && b.ScheduledStartDate <= endDate);

        // Get recipes for these batches
        var recipeIds = scheduledBatches.Select(b => b.RecipeId).Distinct();

        var usage = _context.RecipeIngredients
            .Where(ri => recipeIds.Contains(ri.RecipeId) && ri.IngredientId == ingredientId)
            .Join(scheduledBatches,
                ri => ri.RecipeId,
                b => b.RecipeId,
                (ri, b) => ri.Quantity)
            .Sum();

        return usage;
    }

    private double CalculateOrderQuantity(Ingredient ingredient, DateTime startDate, DateTime endDate)
    {
        var scheduledUsage = GetScheduledUsage(ingredient.IngredientId, startDate, endDate);
        var currentOrders = GetCurrentOrders(ingredient.IngredientId);

        // Calculate how much is needed 
        var totalNeeded = Math.Max(
            ingredient.ReorderPoint - ingredient.OnHandQuantity + scheduledUsage - currentOrders,
            0);

        return totalNeeded;
    }
}