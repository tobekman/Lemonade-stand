using System.Collections.ObjectModel;
using Application;
using Application.Fruits;
using Application.Interfaces;
using Application.Recipes;

namespace ApplicationTests;

public class ApplicationTests
{

    [Fact]
    public void FruitsHaveCorrectName()
    {
        var apple = new Apple();
        var appleName = apple.Name;

        var melon = new Melon();
        var melonName = melon.Name;

        var orange = new Orange();
        var orangeName = orange.Name;
        
        Assert.Equal("Apple", appleName);
        Assert.Equal("Melon", melonName);
        Assert.Equal("Orange", orangeName);
    }

    [Fact]
    public void NoCorrectFruitsProvidedReturnsError()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new AppleLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Melon(),
            new Melon(),
            new Orange()
        };
        const int moneyPAid = 20;
        const int orderedGlassQuantity = 2;

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.IsError;
        
        Assert.True(result);
    }

    [Fact]
    public void NotEnoughCorrectFruitsProvidedReturnsError()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new MelonLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Melon(),
            new Melon(),
            new Melon(),
            new Melon(),
            new Orange()
        };
        const int moneyPAid = 20;
        const int orderedGlassQuantity = 10;

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.IsError;
        
        Assert.True(result);
    }
    
    [Fact]
    public void NotEnoughApplesReturnsCorrectErrorMessage()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new AppleLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Apple()
        };
        const int moneyPAid = 20;
        const int orderedGlassQuantity = 10;
        const string expected = "Error! You need 25.0 apples to make 10 glasses of Apple lemonade.";

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.Message;
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void NotEnoughMelonsReturnsCorrectErrorMessage()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new MelonLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Melon()
        };
        const int moneyPAid = 20;
        const int orderedGlassQuantity = 10;
        const string expected = "Error! You need 5.0 melons to make 10 glasses of Melon lemonade.";

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.Message;
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void NotEnoughOrangesReturnsCorrectErrorMessage()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new OrangeLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Orange(),
        };
        const int moneyPAid = 20;
        const int orderedGlassQuantity = 10;
        const string expected = "Error! You need 10 oranges to make 10 glasses of Orange lemonade.";

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.Message;
        
        Assert.Equal(expected, result);
    }
    
    
    [Fact]
    public void NotEnoughMoneyProvidedReturnsError()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new AppleLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Apple(),
            new Apple(),
            new Apple(),
            new Apple(),
            new Apple()
        };
        const int moneyPAid = 15;
        const int orderedGlassQuantity = 2;

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.IsError;
        
        Assert.True(result);
    }
    
    [Fact]
    public void NotEnoughMoneyReturnsCorrectErrorMessage()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new AppleLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Apple(),
            new Apple(),
            new Apple(),
            new Apple(),
            new Apple()
        };
        const int moneyPAid = 15;
        const int orderedGlassQuantity = 2;
        const string expected = "Error! You can only get 1 glass(es) for 15 gold coins, 20 needed!";

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.Message;
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void SuccessfulOrangeOrderReturnsCorrectMessage()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new OrangeLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Orange(),
            new Orange(),
            new Orange(),
            new Orange(),
            new Orange(),
            new Orange(),
        };
        const int moneyPAid = 50;
        const int orderedGlassQuantity = 5;
        const string expected = "Success! You'll have 1 orange(s) left. The customer should get 5 back in change.";

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.Message;
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void SuccessfulAppleOrderReturnsCorrectMessage()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new AppleLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Apple(),
            new Apple(),
            new Apple(),
            new Apple(),
            new Apple(),
            new Apple(),
            new Apple(),
            new Apple()
        };
        const int moneyPAid = 30;
        const int orderedGlassQuantity = 3;
        const string expected = "Success! You'll have 0.5 apple(s) left. The customer should get 0 back in change.";

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.Message;
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void SuccessfulMelonOrderReturnsCorrectMessage()
    {
        var lemonadeService = new LemonadeService();
        var recipe = new MelonLemonadeRecipe();
        var fruits = new Collection<IFruit>
        {
            new Melon(),
            new Melon()
        };
        const int moneyPAid = 50;
        const int orderedGlassQuantity = 4;
        const string expected = "Success! You'll have 0.0 melon(s) left. The customer should get 2 back in change.";

        var produce = lemonadeService.Produce(recipe, fruits, moneyPAid, orderedGlassQuantity);
        var result = produce.Message;
        
        Assert.Equal(expected, result);
    }
    
    
    
}