using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a data container that creates a tree based on the associated string of a TreeableData
public class StringTree<T>
{
    TreeNode<T> TreeNode;

    public void BuildTree()
    {
    }
    public void BuildTree(TreeableData<T>[] NodeData)
    {
        for(int x=0; x< NodeData.Length;x++)
        {

        }
    }


}


class TreeNode<T>
{
    char Key;
    Dictionary<char, TreeNode<T>> ChildNodes;
    public T _Data { get; private set; }
    bool IsSuperRoot;
    /*
    public TreeNode(string key, T Data)
    {
        Key = key;
        _Data = Data;
    }
    */
    public void AddChildBranches(string Keys,T data)
    {
        if(Keys.Length <1)
        {

        }
    }

    public void AddChild(char Key, TreeNode<T> data)
    {
        if(ChildNodes == null)
        {
            ChildNodes = new Dictionary<char, TreeNode<T>>();
        }
        ChildNodes.Add(Key, data);
    }
    public void RemoveLink()
    {

    }
}

class NodeEqualityComparer<T>:IEqualityComparer<T>
{
    public new bool Equals(T x, T y)
    {
        throw new System.NotImplementedException();
    }

    public int GetHashCode(T obj)
    {
        throw new System.NotImplementedException();
    }
}

public class TreeableData<T>
{
    public string Key { private set; get; }
    public T Data { private set; get; }

    public TreeableData(string key, T data)
    {
        Key = key;
        Data = data;
    }
}


static class CharArrayExtension
{
    public static string ConvertToString(this char[] chars)
    {
        string str = "";
        for (int n = 0; n < chars.Length; n++)
        {
            str += chars[n];
        }
        return str;
    }

}
