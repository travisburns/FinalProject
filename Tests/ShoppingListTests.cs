using NUnit.Framework;
using FinalProject.Models;
using System;
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
    public void CanGetIngredientsNeedingReorder()
    {
       
        DateTime startDate = DateTime.Now;
        DateTime endDate = startDate.AddMonths(1);
        var shoppingList = _service.GetShoppingList(startDate, endDate);
        Assert.That(shoppingList, Is.Not.Null);
        Assert.That(shoppingList.SelectMany(g => g.Items).All(i => i.Ingredient.OnHandQuantity <= i.Ingredient.ReorderPoint));
    }

    [Test]
    public void ShoppingListContainsScheduledUsage()
    {
     
        DateTime startDate = DateTime.Now;
        DateTime endDate = startDate.AddMonths(1);
        var shoppingList = _service.GetShoppingList(startDate, endDate);
        Assert.That(shoppingList, Is.Not.Null);
        Assert.That(shoppingList.SelectMany(g => g.Items).All(i => i.ScheduledUsage >= 0));
    }
}