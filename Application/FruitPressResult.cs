namespace Application;

public class FruitPressResult
{
    public FruitPressResult()
    {
        Message = "";
    }

    public string Message { get; set; }
    public bool IsError { get; set; }
}