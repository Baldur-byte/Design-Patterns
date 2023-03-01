//定义状态接口
public interface IState
{
    void doAction();
}

//实现各个状态
public class State1 : IState
{
    public void doAction() { Console.WriteLine("状态一"); }
}

public class State2 : IState
{
    public void doAction() { Console.WriteLine("状态二"); }
}

public class State3 : IState
{
    public void doAction() { Console.WriteLine("状态三"); }
}

//与客户端交互的类
public class Context
{
    private IState state;

    public void setState(IState state)
    {
        this.state = state;
    }

    public IState getState()
    {
        return state;
    }

    public void doAction() 
    {
        if (state != null) state.doAction();
    }
}

public class Program
{
    public static void Main()
    {
        Context context = new Context();

        context.setState(new State1());
        context.doAction();
        context.setState(new State2());
        context.doAction();
        context.setState(new State3());
        context.doAction();
    }
}