using System.Collections;

namespace LeetcodePractice.Implementation.Neetcode.Core;

//https://neetcode.io/problems/dynamicArray
public class DynamicArray : IEnumerable<int>
{
    private int[] data;
    private int size;

    public DynamicArray(int capacity)
    {
        data = new int[capacity];
        size = 0;
    }

    public DynamicArray(ICollection<int> initialData)
    {
        data = initialData.ToArray();
        size = initialData.Count;
    }

    public int Get(int i)
    {
        return data[i];
    }

    public void Set(int i, int n)
    {
        data[i] = n;
    }

    public void PushBack(int n)
    {
        if (size >= data.Length)
        {
            Resize();
        }

        data[size++] = n;
    }

    public int PopBack()
    {
        if (size <= 0)
        {
            throw new IndexOutOfRangeException();
        }
        return data[--size];
    }

    private void Resize()
    {
        var newData = new int[data.Length * 2];
        data.CopyTo(newData, 0);
        data = newData;
    }

    public int GetSize()
    {
        return size;
    }

    public int GetCapacity()
    {
        return data.Length;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return data.Take(size).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return data.Take(size).GetEnumerator();
    }
}
