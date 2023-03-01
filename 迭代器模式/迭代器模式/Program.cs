//迭代器抽象类
public interface Iterator
{
    bool moveNext();
    Object getCurrent();
    void next();
    void reset();
}

//抽象聚合类
public interface IListCollection 
{
    Iterator GetIterator();
}

//具体迭代器类   引用聚合对象
public class ConcreteIterator : Iterator
{
    private ConcreteList collection;
    private int _index;

    public ConcreteIterator(ConcreteList collection)
    {
        this.collection = collection;
        _index = 0;
    }

    public object getCurrent()
    {
        return collection.GetElement(_index);
    }

    public bool moveNext()
    {
        if(_index<collection.Length) return true;
        return false;
    }

    public void next()
    {
        if(_index < collection.Length) _index++;
    }

    public void reset()
    {
        _index = 0;
    }
}

//具体聚合类
public class ConcreteList : IListCollection
{
    int[] collection;

    public ConcreteList(int[] ints)
    {
        collection = ints;
    }

    public Iterator GetIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Length
    {
        get { return collection.Length; }
    }

    public int GetElement(int index)
    {
        return collection[index];
    }
}



public static class Program
{
    public static void Main()
    {
        Iterator iterator;
        IListCollection ilist = new ConcreteList(new int[] { 1, 2, 4, 7, 9, 6, 8 });
        iterator = ilist.GetIterator();

        while (iterator.moveNext())
        {
            Console.WriteLine(iterator.getCurrent());
            iterator.next();
        }
    }
}