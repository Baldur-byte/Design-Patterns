//访问者接口
public interface IVisitor
{
    void Visit(ElementA elementA);
    void Visit(ElementB elementB);
    void Visit(ElementC elementC);
}

//元素接口
public interface IElement
{
    void accept(IVisitor visitor);
}

//元素实现类
public class ElementA : IElement
{
    private string _name;

    public ElementA(string name)
    {
        _name = name;
    }

    public string Name { get { return _name; } }

    public void accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ElementB : IElement
{
    private string _name;

    public ElementB(string name)
    {
        _name = name;
    }

    public string Name { get { return _name; } }

    public void accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ElementC : IElement
{
    private string _name;

    public ElementC(string name)
    {
        _name = name;
    }

    public string Name { get { return _name; } }

    public void accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

//访问者实现类
public class VisitorA : IVisitor
{
    public void Visit(ElementA elementA)
    {
        Console.WriteLine("访问者A   获取名字" + elementA.Name);
    }

    public void Visit(ElementB elementB)
    {
        Console.WriteLine("访问者A   获取名字" + elementB.Name);
    }

    public void Visit(ElementC elementC)
    {
        Console.WriteLine("访问者A   获取名字" + elementC.Name);
    }
}

public class VisitorB : IVisitor
{
    public void Visit(ElementA elementA)
    {
        Console.WriteLine("访问者B   获取名字" + elementA.Name);
    }

    public void Visit(ElementB elementB)
    {
        Console.WriteLine("访问者B   获取名字" + elementB.Name);
    }

    public void Visit(ElementC elementC)
    {
        Console.WriteLine("访问者B   获取名字" + elementC.Name);
    }
}

//对象结构类
public class ObjectStructure
{
    private List<IElement> elements = new List<IElement> ();

    public void AddElements()
    {
        elements.Add(new ElementA("A_1"));
        elements.Add(new ElementA("A_2"));
        elements.Add(new ElementB("B"));
        elements.Add(new ElementC("C_1"));
        elements.Add(new ElementC("C_2"));
        elements.Add(new ElementC("C_3"));
    }

    public void Accept(IVisitor visitor)
    {
        foreach(IElement element in elements)
        {
            element.accept(visitor);
        }
    }
}

public static class Program
{
    public static void Main()
    {
        ObjectStructure objectStructure = new ObjectStructure();
        IVisitor visitorA = new VisitorA();
        IVisitor visitorB = new VisitorB();
        objectStructure.AddElements();
        objectStructure.Accept(visitorA);
        objectStructure.Accept(visitorB);
    }
}