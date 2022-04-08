using System.Collections;
using System.Text.Json;
using System.Globalization;

namespace Generics;

public class MyList<T>
{
    private const int DefaultCapacity = 1;
    
    private int _count;
    private int _capacity;
    private T[] _array;

    public int Count => _count;

    public int Capacity
    {
        get => _capacity;
        set => _capacity = value;
    }

    public MyList() : this(DefaultCapacity){}
    
    

    public MyList(int capacity)
    {
        _capacity = capacity;
        _array = new T[_capacity];
    }

    public void Add(T value)
    {
        if (_count >= _capacity)
        {
            _capacity += 1;
            Array.Resize(ref _array, _capacity);
        }
        _array[_count] = value;
        _count++;
    }

    public T Get(int index)
    {
        return _array[index];
    }

    public void Cclear()
    {
        Array.Clear(_array);
    }

    // public T this[int index]
    // {
    //     get { return Get(index); }
    // }

    public T this[int index] => _array[index];
}