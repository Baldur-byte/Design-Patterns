public interface ILawSuit
{
    void submit(string proof);
    void defend();
}

public class Person : ILawSuit
{
    public void submit(string proof)
    {
        Console.WriteLine("提起诉讼");
    }

    public void defend()
    {
        Console.WriteLine("辩护");
    }
}

public class ProxyLawyer : ILawSuit
{
    ILawSuit plaintiff;
    public ProxyLawyer(ILawSuit plaintiff)
    {
        this.plaintiff = plaintiff;
    }

    public void defend()
    {
        plaintiff.defend();
    }

    public void submit(string proof)
    {
        plaintiff.submit(proof);
    }
}

public static class Program
{
    public static void Main()
    {
        Person plaintiff = new Person();
        ProxyLawyer plaintiff2 = new ProxyLawyer(plaintiff);
        plaintiff2.submit("");
        plaintiff2.defend();
    }
}