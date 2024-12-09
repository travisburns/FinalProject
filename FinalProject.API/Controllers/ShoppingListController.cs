 using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using static ShoppingListService;

[Route("api/[controller]")]
[ApiController]
public class ShoppingListController : ControllerBase
{
    private readonly BitsContext _context;
    private readonly ShoppingListService _service;

    public ShoppingListController(BitsContext context)
    {
        _context = context;
        _service = new ShoppingListService(context);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ShoppingListGroup>> GetShoppingList(
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null)
    {
        try
        {
            startDate ??= DateTime.Today;
            endDate ??= DateTime.Today.AddMonths(1);

            var list = _service.GetShoppingList(startDate.Value, endDate.Value)
        .Select(g => new
        {
            g.SupplierId,
            g.SupplierName,
            Items = g.Items.Select(i => new
            {
                i.Ingredient.IngredientId,
                i.Ingredient.Name,
                i.Ingredient.ReorderPoint,
                i.Ingredient.OnHandQuantity,
                i.QuantityToOrder,
                i.CurrentOrders,
                i.ScheduledUsage,
                i.UnitCost,
               
            }).ToList(),
            g.TotalCost,
            g.TotalWeight
        });
            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error generating shopping list: {ex.Message}");
        }
    }

    [HttpGet("orders/{ingredientId}")]
    public ActionResult GetIngredientOrders(int ingredientId)
    {
        try
        {
            // Validate ingredientId exists first
            var ingredient = _context.Ingredients.Find(ingredientId);
            if (ingredient == null)
            {
                return NotFound($"Ingredient with ID {ingredientId} not found");
            }
            var orders = _context.IngredientInventoryAdditions
     .Where(a => a.IngredientId == ingredientId)  // Remove TransactionDate check
     .Select(a => new
     {
         ExpectedDate = a.EstimatedDeliveryDate,
         a.Quantity,
         a.UnitCost,
         SupplierInfo = new
         {
             a.Supplier.Name,
             a.Supplier.Phone,
             a.Supplier.Email
         }
     })
     .ToList();
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error retrieving orders: {ex.Message}");
        }
    }
}