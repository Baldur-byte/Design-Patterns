//声明一个命令接口
public interface ICommand
{
    void Execute();
}

//构建可以完成命令的角色
public class RobotAReceiver
{
    public void Action1()
    {
        Console.WriteLine("机器人A执行动作 1");
    }

    public void Action2()
    {
        Console.WriteLine("机器人A执行动作 2");
    }
}

public class RobotBReceiver
{
    public void Action3()
    {
        Console.WriteLine("机器人B执行动作 3");
    }

    public void Action4()
    {
        Console.WriteLine("机器人B执行动作 4");
    }
}

//构建各种命令
public class Action1Command : ICommand
{
    private RobotAReceiver robotA;

    public Action1Command(RobotAReceiver robotA)
    {
        this.robotA = robotA;
    }

    public void Execute()
    {
        robotA.Action1();
    }
}

public class Action2Command : ICommand
{
    private RobotAReceiver robotA;

    public Action2Command(RobotAReceiver robotA)
    {
        this.robotA = robotA;
    }

    public void Execute()
    {
        robotA.Action2();
    }
}

public class Action3Command : ICommand
{
    private RobotBReceiver robotB;

    public Action3Command(RobotBReceiver robotB)
    {
        this.robotB = robotB;
    }

    public void Execute()
    {
        robotB.Action3();
    }
}

public class Action4Command : ICommand
{
    private RobotBReceiver robotB;

    public Action4Command(RobotBReceiver robotB)
    {
        this.robotB = robotB;
    }

    public void Execute()
    {
        robotB.Action4();
    }
}

//构建命令调用者
public class RobotInvoker
{
    private List<ICommand> commands = new List<ICommand>();

    public void clearCommand()
    {
        commands.Clear();
    }

    public void addCommands(ICommand command)
    {
        commands.Add(command);
    }

    public void executeCommand()
    {
        foreach(ICommand command in commands)
            command.Execute();
    }
}

public static class Program
{
    public static void Main()
    {
        RobotInvoker robotInvoker = new RobotInvoker();

        RobotAReceiver robotA = new RobotAReceiver();
        Action1Command action1Command = new Action1Command(robotA);
        Action2Command action2Command = new Action2Command(robotA);

        RobotBReceiver robotB = new RobotBReceiver();
        Action3Command action3Command = new Action3Command(robotB);
        Action4Command action4Command = new Action4Command(robotB);

        robotInvoker.addCommands(action1Command);
        robotInvoker.addCommands(action4Command);
        robotInvoker.addCommands(action3Command);
        robotInvoker.addCommands(action2Command);
        robotInvoker.executeCommand();
    }
}
