using System.Collections.ObjectModel;

namespace Application.Interfaces;

public interface IFruitPressService
{
    FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity);
}
