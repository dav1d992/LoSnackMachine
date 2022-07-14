namespace Boundaries;

public class TouchScreen : ITouchScreen
{
    public void ShowBalance(float balance)
    {
        Console.WriteLine($"New Balance is {balance}");
    }
}
