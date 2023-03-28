namespace Application.Interfaces;

public interface IRecipe
{
    string Name { get; }
    Type AllowedFruit { get; }
    decimal ConsumptionPerGlass { get; }
    int PricePerGlass { get; }
}