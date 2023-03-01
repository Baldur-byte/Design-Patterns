//设计一个所有处理器都要实现的接口
public interface BudgeHandler
{
    void setNextHandler(BudgeHandler nextHandler);
    bool handle(int amount);
}

//实现各种处理器
public class GroupLeader : BudgeHandler
{
    private BudgeHandler nextHandler;

    public void setNextHandler(BudgeHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }

    public bool handle(int amount)
    {
        if(amount < 1000)
        {
            Console.WriteLine("问题已经解决 1");
            return true;
        }
        Console.WriteLine("问题没有解决 1");
        return nextHandler.handle(amount);
    }
}

public class Manager : BudgeHandler
{
    private BudgeHandler nextHandler;

    public void setNextHandler(BudgeHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }

    public bool handle(int amount)
    {
        if (amount < 5000)
        {
            Console.WriteLine("问题已经解决 2");
            return true;
        }
        Console.WriteLine("问题没有解决 2");
        return nextHandler.handle(amount);
    }
}

public class CFO : BudgeHandler
{
    private BudgeHandler nextHandler;

    public void setNextHandler(BudgeHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }

    public bool handle(int amount)
    {
        if (amount < 50000)
        {
            Console.WriteLine("问题已经解决 3");
            return true;
        }
        Console.WriteLine("问题没有解决 3");
        if(nextHandler == null) return false;
        return nextHandler.handle(amount);
    }
}

public static class Program
{
    public static void Main()
    {
        GroupLeader leader = new GroupLeader();
        Manager manager = new Manager();
        CFO cfo = new CFO();

        leader.setNextHandler(manager);
        manager.setNextHandler(cfo);

        Console.WriteLine("开始解决问题");

        if (leader.handle(500000))
        {
            Console.WriteLine("牛啊牛啊");
        }
        else
        {
            Console.WriteLine("垃圾");
        }
    }
}