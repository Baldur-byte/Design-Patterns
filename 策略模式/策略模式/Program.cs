//定义策略接口，规定算法的同一操作
public interface IStrategy
{
    int Operate(int value);
}

//封装各个算法
public class Strategy1 : IStrategy
{
    public int Operate(int value)
    {
        return value < 10 ? 4 : 6;
    }
}

public class Strategy2 : IStrategy
{
    public int Operate(int value)
    {
        return value < 3 ? 8 : (8 + (value - 3) * 3);
    }
}

public class Strategy3 : IStrategy
{
    public int Operate(int value)
    {
        return 2;
    }
}

//使用算法
public class Calculator
{
    public int Use(IStrategy strategy, int value)
    {
        return strategy.Operate(value);
    }
}

public static class Progam
{
    public static void Main()
    {
        Calculator calculator = new Calculator();
        Console.WriteLine(calculator.Use(new Strategy1(), 9));
        Console.WriteLine(calculator.Use(new Strategy2(), 9));
        Console.WriteLine(calculator.Use(new Strategy3(), 9));

        Console.WriteLine(calculator.Use(new Strategy1(), 91));
        Console.WriteLine(calculator.Use(new Strategy2(), 91));
        Console.WriteLine(calculator.Use(new Strategy3(), 91));
    }
}