//抽象化   相当于桥接器,主要为了包含引用
public abstract class Coffee
{
    protected ICoffeeAdditives additives;
    public Coffee(ICoffeeAdditives additives)
    {
        this.additives = additives;
    }

    public abstract void orderCoffee(int count);
}

//抽象化的修正类
public abstract class RefinedCoffee : Coffee
{
    protected RefinedCoffee(ICoffeeAdditives additives) : base(additives)
    {
    }
}

//实现化接口
public interface ICoffeeAdditives 
{
    void addSomething();
}

//具体实现化
public class Milk : ICoffeeAdditives
{
    public void addSomething()
    {
        Console.WriteLine("添加了 牛奶");
    }
}

public class Sugar : ICoffeeAdditives
{
    public void addSomething()
    {
        Console.WriteLine("添加了 糖");
    }
}

//抽象类的扩展类
public class LargeCoffee : RefinedCoffee
{
    public LargeCoffee(ICoffeeAdditives additives) : base(additives)
    {
    }

    public override void orderCoffee(int count)
    {
        Console.WriteLine("购买了" + count +"杯大杯咖啡");
        additives.addSomething();
    }
}

public static class Program
{
    public static void Main()
    {
        RefinedCoffee coffee = new LargeCoffee(new Milk());
        coffee.orderCoffee(1);
    }
}
