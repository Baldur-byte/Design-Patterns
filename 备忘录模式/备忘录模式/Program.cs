//构建备忘录
public class GameProgressMemento
{
    private int score;

    public GameProgressMemento(int score)
    {
        this.score = score;
    }

    public int getScore()
    {
        return score;
    }
}

//定义需要保存和恢复状态的角色
public class GameOriginator
{
    private int currentScore;

    public GameProgressMemento saveProcess()
    {
        return new GameProgressMemento(currentScore);
    }

    public void restoreProcess(GameProgressMemento memento)
    {
        currentScore = memento.getScore();
    }

    public void playGame()
    {
        Console.WriteLine("开始游戏");
        Console.WriteLine("当前分数" + currentScore);
        Console.WriteLine("获得1分");
        Console.WriteLine("总分为" + ++currentScore);
    }

    public void exitGame()
    {
        Console.WriteLine("退出游戏");
        currentScore = 0;
    }
}

//备忘录操作
public class GameCareTaker
{
    private List<GameProgressMemento> mementos = new List<GameProgressMemento> ();

    public void saveMemento(GameProgressMemento memento)
    {
        this.mementos.Add(memento);
    }

    public GameProgressMemento getMemento(int index)
    {
        return mementos [index];
    }
}

public static class Program
{
    public static void Main()
    {
        GameOriginator originator = new GameOriginator();
        GameCareTaker careTaker = new GameCareTaker();
        //玩游戏
        originator.playGame();
        //保存进度
        careTaker.saveMemento(originator.saveProcess());
        //退出游戏
        originator.exitGame();

        //重新打开游戏，恢复进度
        originator.restoreProcess(careTaker.getMemento(0));
        originator.playGame();
    }
}