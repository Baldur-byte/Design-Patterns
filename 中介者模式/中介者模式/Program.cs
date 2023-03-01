// 抽象中介者   抽象中介者角色定义统一的接口，用于各同事角色之间的通信
public abstract class Mediator
{
    public abstract void send(String message, Colleague colleague);
}

//抽象同事类   
public abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator) { this.mediator = mediator; }
}

//具体同事类
public class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator) : base(mediator) { }

    public void send(string message)
    {
        mediator.send(message, this);
    }

    public void notify(string message)
    {
        Console.WriteLine("同事1收到消息" + message);
    }
}

public class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator) : base(mediator) { }

    public void send(string message)
    {
        mediator.send(message, this);
    }

    public void notify(string message)
    {
        Console.WriteLine("同事1收到消息" + message);
    }
}

//具体中介者类    具体中介者角色通过协调各同事角色实现协作行为，因此它必须依赖于各个同事角色。
public class ConcreteMediator : Mediator
{
    private ConcreteColleague1 colleague1;
    private ConcreteColleague2 colleague2;

    public void setColleague1(ConcreteColleague1 colleague1)
    {
        this.colleague1 = colleague1;
    }

    public void setColleague2(ConcreteColleague2 colleague2)
    {
        this.colleague2 = colleague2;
    }

    public override void send(string message, Colleague colleague)
    {
        if(colleague == colleague1)
        {
            colleague2.notify(message);
        }
        else
        {
            colleague1.notify(message);
        }
    }
}

public static class Program
{
    public static void Main()
    {

    }
}