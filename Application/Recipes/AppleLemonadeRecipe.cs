using Application.Fruits;
using Application.Interfaces;

namespace Application.Recipes;

public class AppleLemonadeRecipe : IRecipe
{
    public string Name => "Apple Lemonade";
    public Type AllowedFruit { get; } = typeof(Apple);
    public decimal ConsumptionPerGlass => 2.5m;
    public int PricePerGlass => 10;
    
}