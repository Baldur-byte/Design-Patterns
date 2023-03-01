//定义观察者接口
public interface IObserver
{
    void update(string message);
}

//观察者
public class ConcreteObserver1 : IObserver
{
    public void update(string message)
    {
        
        if(message == null) return;
        if(message.Equals("action1"))
        {
            Console.WriteLine("观察者1    接收到命令1");
        }
        else if (message.Equals("action2"))
        {
            Console.WriteLine("观察者1    接收到命令2");
        }
        else
        {
            Console.WriteLine("观察者1    接收到命令");
        }
    }
}

public class ConcreteObserver2 : IObserver
{
    public void update(string message)
    {

        if (message == null) return;
        if (message.Equals("action1"))
        {
            Console.WriteLine("观察者2    接收到命令1");
        }
        else if (message.Equals("action2"))
        {
            Console.WriteLine("观察者2    接收到命令2");
        }
        else
        {
            Console.WriteLine("观察者2    接收到命令");
        }
    }
}

//定义被观察者接口
public interface IObservable 
{
    void add(IObserver observer);
    void remove(IObserver observer);
    void notifyState(string state);
}

//实现被观察者  持有观察者集合

public class Observable1 : IObservable
{
    private List<IObserver> _observers = new List<IObserver>();

    public void add(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void notifyState(string state)
    {
        foreach (IObserver observer in _observers)
        {
            observer.update(state);
        }
    }

    public void remove(IObserver observer)
    {
        _observers.Remove(observer);
    }
}

public static class Program
{
    public static void Main()
    {
        IObserver observer1 = new ConcreteObserver1();
        IObserver observer2 = new ConcreteObserver2();

        IObservable observable1 = new Observable1();
        //IObservable observable2 = new Observable2();

        observable1.add(observer1);

        observable1.notifyState("1");

        observable1.add(observer2);

        observable1.notifyState("2");

        observable1.remove(observer1);

        observable1.notifyState("1");
    }
}