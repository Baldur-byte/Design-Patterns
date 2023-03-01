//定义模板类
public abstract class Model
{
    //模板方法
    public void Execute()
    {
        Action();
        Action0();
        Action1();
        Action2();
        Action3();
        Action4();
    }

    //实体方法，这个方法实现通用的业务逻辑
    private void Action()
    {
        Console.WriteLine("通用行为");
    }

    //抽象方法
    public abstract void Action1();
    public abstract void Action2();
    public abstract void Action3();
    public abstract void Action4();

    //钩子方法， 被部分子类实现
    public virtual void Action0()
    {
        Console.WriteLine("没有被子类实现");
    }
}

//实现实体类
public class Concrete1 : Model
{
    public override void Action1()
    {
        Console.WriteLine("实体1   的    行为1");
    }

    public override void Action2()
    {
        Console.WriteLine("实体1   的    行为2");
    }

    public override void Action3()
    {
        Console.WriteLine("实体1   的    行为3");
    }

    public override void Action4()
    {
        Console.WriteLine("实体1   的    行为4");
    }
}

public class Concrete2 : Model
{
    public override void Action1()
    {
        Console.WriteLine("实体2   的    行为1");
    }

    public override void Action2()
    {
        Console.WriteLine("实体2   的    行为2");
    }

    public override void Action3()
    {
        Console.WriteLine("实体2   的    行为3");
    }

    public override void Action4()
    {
        Console.WriteLine("实体2   的    行为4");
    }

    public override void Action0()
    {
        Console.WriteLine("实体2   的    行为0");
    }
}

public static class Program
{
    public static void Main()
    {
        Model model1 = new Concrete1();
        model1.Execute();
        Model model2 = new Concrete2();
        model2.Execute();
    }
}