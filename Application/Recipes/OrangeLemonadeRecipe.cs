using Application.Fruits;
using Application.Interfaces;

namespace Application.Recipes;

public class OrangeLemonadeRecipe : IRecipe
{
    public string Name => "Orange Lemonade";
    public Type AllowedFruit { get; } = typeof(Orange);
    public decimal ConsumptionPerGlass => 1m;
    public int PricePerGlass => 9;
    
}