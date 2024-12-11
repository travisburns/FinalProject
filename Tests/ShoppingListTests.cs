using FinalProject.Models;
using NUnit.Framework;
using System.Linq;

[TestFixture]
public class ShoppingListTests
{
    private BitsContext _context;
    private ShoppingListService _service;

    [SetUp]
    public void Setup()
    {
        _context = new BitsContext();
        _service = new ShoppingListService(_context);
    }

    [Test]
    public void CanCalculateTotalWeight()
    {
        var startDate = DateTime.Now;
        var endDate = startDate.AddMonths(1);
        var shoppingList = _service.GetShoppingList(startDate, endDate);
        Assert.That(shoppingList, Is.Not.Null);
        Assert.That(shoppingList.All(g => g.TotalWeight == g.Items.Sum(i => i.QuantityToOrder)));
    }

    [Test]
    public void CorrectlyGroupsBySupplier()
    {
        var startDate = DateTime.Now;
        var endDate = startDate.AddMonths(1);
        var shoppingList = _service.GetShoppingList(startDate, endDate);
        Assert.That(shoppingList, Is.Not.Null);
        var supplierIds = shoppingList.Select(g => g.SupplierId).Distinct();
        Assert.That(supplierIds.Count(), Is.EqualTo(shoppingList.Count()));
    }

    [Test]
    public void DateRangeFiltersCorrectly()
    {
        var startDate = DateTime.Now;
        var endDate = startDate.AddDays(1);
        var shoppingList = _service.GetShoppingList(startDate, endDate);
        Assert.That(shoppingList, Is.Not.Null);
        Assert.That(shoppingList.SelectMany(g => g.Items).All(i => i.ScheduledUsage >= 0));
    }

    [Test]
    public void IncludesAllNecessaryIngredients()
    {
        var startDate = DateTime.Now;
        var endDate = startDate.AddMonths(1);
        var shoppingList = _service.GetShoppingList(startDate, endDate);
        Assert.That(shoppingList, Is.Not.Null);
        var ingredientIds = shoppingList.SelectMany(g => g.Items.Select(i => i.Ingredient.IngredientId)).Distinct();
        var expectedIngredients = _context.Ingredients
            .Where(i => i.OnHandQuantity <= i.ReorderPoint)
            .Select(i => i.IngredientId);
        Assert.That(ingredientIds, Is.EquivalentTo(expectedIngredients));
    }

    [Test]
    public void CanRetrieveCurrentOrders()
    {
        var startDate = DateTime.Now;
        var endDate = startDate.AddMonths(1);
        var shoppingList = _service.GetShoppingList(startDate, endDate);
        Assert.That(shoppingList, Is.Not.Null);
        var ingredientWithOrders = shoppingList.SelectMany(g => g.Items).First(i => i.CurrentOrders > 0);
        Assert.That(ingredientWithOrders, Is.Not.Null);
        var orders = _context.IngredientInventoryAdditions
            .Where(a => a.IngredientId == ingredientWithOrders.Ingredient.IngredientId && a.TransactionDate == null)
            .ToList();
        Assert.That(orders, Is.Not.Empty);
    }

    [Test]
    public void CanCalculateTotalCost()
    {
        var startDate = DateTime.Now;
        var endDate = startDate.AddMonths(1);
        var shoppingList = _service.GetShoppingList(startDate, endDate);
        Assert.That(shoppingList, Is.Not.Null);
        Assert.That(shoppingList.All(g => g.TotalCost == g.Items.Sum(i => i.QuantityToOrder * i.UnitCost)));
    }

 
}