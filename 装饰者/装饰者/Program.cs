//原始对象接口
public interface ICoffee
{
   void makeCoffee();
}

//原始对象
public class OriginalCoffee : ICoffee
{
    public void makeCoffee()
    {
        Console.Write("原味咖啡");
    }
}

public class MokaCoffee : ICoffee
{
    public void makeCoffee()
    {
        Console.Write("摩卡咖啡");
    }
}

public class NaTieCoffee : ICoffee
{
    public void makeCoffee()
    {
        Console.Write("拿铁咖啡");
    }
}

//装饰者基类  持有一个ICoffee类型的引用
public abstract class CoffeeDecorator : ICoffee
{
    private ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual void makeCoffee()
    {
        _coffee.makeCoffee();
    }
}

//各种装饰类
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {

    }

    public override void makeCoffee()
    {
        base.makeCoffee();
        Console.Write("添加牛奶");
    }
}

public class SugerDecorator : CoffeeDecorator
{
    public SugerDecorator(ICoffee coffee) : base(coffee)
    {

    }

    public override void makeCoffee()
    {
        base.makeCoffee();
        Console.Write("添加糖");
    }
}

public static class Program
{
    public static void Main()
    {
        ICoffee coffee = new OriginalCoffee();
        coffee.makeCoffee();

        Console.WriteLine();

        coffee = new MilkDecorator(coffee);
        coffee.makeCoffee();

        Console.WriteLine();

        coffee = new SugerDecorator(coffee);
        coffee.makeCoffee();

        Console.WriteLine();

        coffee = new NaTieCoffee();
        coffee.makeCoffee();

        Console.WriteLine();

        coffee = new MilkDecorator(coffee);
        coffee.makeCoffee();

        Console.WriteLine();

        coffee = new MokaCoffee();
        coffee.makeCoffee();

        Console.WriteLine();

        coffee = new SugerDecorator(coffee);
        coffee.makeCoffee();
    }
}