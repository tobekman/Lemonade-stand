using System.Collections.ObjectModel;
using Application.Fruits;
using Application.Interfaces;

namespace Application;

public class LemonadeService : IFruitPressService
{
    private IRecipe? _recipe;
    private Collection<IFruit>? _fruits;
    private int? _moneyPaid;
    private int? _orderedGlassQuantity;
    
    public FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity)
    {
        _recipe = recipe;
        _fruits = CollectCorrectFruits(recipe, fruits);
        _moneyPaid = moneyPaid;
        _orderedGlassQuantity = orderedGlassQuantity;
        
        if (ContainsNoCorrectFruit())
        {
            return new FruitPressResult
            {
                Message = NoCorrectFruitsMessage(),
                IsError = true
            };
        }

        if (NotEnoughFruits())
        {
            return new FruitPressResult
            {
                Message = NotEnoughFruitsMessage(),
                IsError = true
            };
        }

        if (NotEnoughMoney())
        {
            return new FruitPressResult
            {
                Message = NotEnoughMoneyMessage(),
                IsError = true
            };
        }
        
        return new FruitPressResult
        {
            Message = SuccessfulOrderMessage(),
            IsError = false
        };
    }

    private bool NotEnoughMoney()
    {
        var moneyNeeded = _recipe!.PricePerGlass * _orderedGlassQuantity;

        return _moneyPaid < moneyNeeded;
    }

    private bool NotEnoughFruits()
    {
        var fruitsNeeded = _recipe!.ConsumptionPerGlass * _orderedGlassQuantity;
        var amountOfFruitsProvided = _fruits!.Count;

        return fruitsNeeded > amountOfFruitsProvided;
    }

    private bool ContainsNoCorrectFruit()
    {
        return _fruits!.Count == 0;
    }

    private string NoCorrectFruitsMessage()
    {
        var fruitType = _recipe!.AllowedFruit;
        if (fruitType == typeof(Apple))
        {
            return "Error! You need apples to make Apple lemonade";
        }
        if (fruitType == typeof(Melon))
        {
            return "Error! You need melons to make Melon lemonade";
        }
        if (fruitType == typeof(Orange))
        {
            return "Error! You need oranges to make Orange lemonade";
        }

        return "";
    }

    private string NotEnoughFruitsMessage()
    {
        var fruitType = _recipe!.AllowedFruit;
        var fruitsNeeded = _recipe.ConsumptionPerGlass * _orderedGlassQuantity;

        if (fruitType == typeof(Apple))
        {
            return $"Error! You need {fruitsNeeded} apples to make {_orderedGlassQuantity} glasses of Apple lemonade.";
        }
        if (fruitType == typeof(Melon))
        {
            return $"Error! You need {fruitsNeeded} melons to make {_orderedGlassQuantity} glasses of Melon lemonade.";
        }
        if (fruitType == typeof(Orange))
        {
            return $"Error! You need {fruitsNeeded} oranges to make {_orderedGlassQuantity} glasses of Orange lemonade.";
        }

        return "";
    }

    private string NotEnoughMoneyMessage()
    {
        var cost = _recipe!.PricePerGlass * _orderedGlassQuantity;
        var possibleGlasses = _moneyPaid / _recipe.PricePerGlass;
        
        return $"Error! You can only get {possibleGlasses} glass(es) for {_moneyPaid} gold coins, {cost} needed!";
    }

    private string SuccessfulOrderMessage()
    {
        var cost = _recipe!.PricePerGlass * _orderedGlassQuantity;
        var spareChange = _moneyPaid - cost;
        
        var fruitsNeeded = _recipe.ConsumptionPerGlass * _orderedGlassQuantity;
        var leftOvers = _fruits!.Count - fruitsNeeded;

        return $"Success! You'll have {leftOvers} {LeftoverFruitLabel()} left. The customer should get {spareChange} back in change.";
    }
    
    private static Collection<IFruit> CollectCorrectFruits(IRecipe recipe, Collection<IFruit> fruits)
    {
        var correctFruitType = recipe.AllowedFruit;

        var correctFruits = fruits.Where(fruit => fruit.GetType() == correctFruitType)
            .ToList();

        return new Collection<IFruit>(correctFruits);
    }

    private string LeftoverFruitLabel()
    {
        var fruitType = _recipe!.AllowedFruit;

        if (fruitType == typeof(Apple))
        {
            return "apple(s)";
        }
        if (fruitType == typeof(Melon))
        {
            return "melon(s)";
        }
        if (fruitType == typeof(Orange))
        {
            return "orange(s)";
        }

        return "";
    }

}