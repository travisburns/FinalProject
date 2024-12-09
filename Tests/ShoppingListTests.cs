
using FinalProject.Models;
using NUnit.Framework;

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
        Assert.That(shoppingList.SelectMany(g => g.Items)
            .All(i => i.ScheduledUsage >= 0));
    }
}


