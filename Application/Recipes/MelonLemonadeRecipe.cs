using Application.Fruits;
using Application.Interfaces;

namespace Application.Recipes;

public class MelonLemonadeRecipe : IRecipe
{
    public string Name => "Melon Lemonade";
    public Type AllowedFruit { get; } = typeof(Melon);
    public decimal ConsumptionPerGlass => 0.5m;
    public int PricePerGlass => 12;
 
}