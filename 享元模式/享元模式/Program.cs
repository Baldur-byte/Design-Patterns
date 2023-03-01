//定义一个共享对象通用的接口
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

public interface IChess
{
    void draw (int x, int y);
}

//实现需要共享的对象类
public class BlackChess : IChess
{
    //内部状态共享
    private const string color = "黑";

    private const string shape = "圆形";

    private string getColor()
    {
        return color;
    }

    public void draw(int x, int y)
    {
        Console.WriteLine(color + "棋落在(" + x + "," + y + ")处");
    }
}

public class WhiteChess : IChess
{
    //内部状态共享
    private const string color = "白";

    private const string shape = "圆形";

    private string getColor()
    {
        return color;
    }

    public void draw(int x, int y)
    {
        Console.WriteLine(color + "棋落在(" + x + "," + y + ")处");
    }
}

//共享对象工厂
public class ChessFactory
{
    private static Dictionary<string, IChess> chessMap = new Dictionary<string, IChess>();

    public static IChess getChess(string color)
    {
        IChess chess;
        try
        {
            chess = chessMap[color];
        }
        catch
        {
            chess = color == "白" ? new WhiteChess() : new BlackChess();
            chessMap.Add(color, chess);
        }
        return chess;
    }
}

public static class Program
{
    public static void Main()
    {
        IChess blackChess1 = ChessFactory.getChess("黑");
        blackChess1.draw(2, 5);

        IChess whiteChess1 = ChessFactory.getChess("白");
        whiteChess1.draw(3, 3);

        IChess blackChess2 = ChessFactory.getChess("黑");
        blackChess2.draw(7, 5);

        Console.WriteLine(blackChess1.GetHashCode() + "  ：" 
            + whiteChess1.GetHashCode() + "  ：" + blackChess2.GetHashCode());
    }
}