using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//a data container that creates a tree based on the associated string of a TreeableData
public class StringTree<T>
{
    TreeNode<T> TreeNode;
    /*
     * tree creation:
     * create the super root node
     *
     * for(x=0; x< treeableData parameter length)
     *       create a dummy treenode for treeableData
     *       send created Treenode to SuperRoot and assign it as it's children
     *       
     *TreeNode Edge Creation
     *        TreeNode receieves treeNode
     *        if receieved Key string element[0] is present on Child Edges
     *             not:
     *                  {
     *                 if(Keystring End of String)
     *                  End, store assign receieved Data as The treenode's data
     *                 
     *                 else
     *                  create Child TreeNode
     *                  child TreeNode.TreeNode Edge Creation (TreeNode Data, Keystring ([0] excluded) recurse and repeat
     *                  }
     *              else
     *                  
     *              
     *                  
     *
     *
     */
    public void addNode(string keypath, T data)
    {
        if (TreeNode == null) TreeNode = new TreeNode<T>();

        TreeNode.Add(keypath, data);
    }
    public T GetNode(string keypath)
    {
        var node = TreeNode.getData(keypath, null);
        if (node == null)
            Debug.Log("Tree retuns a null");
        return node.Data;
        
    }
}

//maybe consider on using a generic data type instead? in case an int data type is going to be used for AI related shenanigans
// ^ create a new tree instead just for the AI behaviour tree
// tree is LazyGet by default
public class TreeNode<T>
{
    char Key;
    List<TreeNode<T>> ChildNodes;
    public bool isNodeEmpty => IsNodeEmpty;

    protected bool IsNodeEmpty;
    private T _Data { get; set; }
    public T Data { get { return _Data; } }
    /*
    public TreeNode(string key, T Data)
    {
        Key = key;
        _Data = Data;
    }
    */
    public TreeNode()
    {
        ChildNodes = new List<TreeNode<T>>();
        IsNodeEmpty = false;
    }
    public TreeNode(char key,T nodeData)
    {
        Key = key;
        _Data = nodeData;
        IsNodeEmpty = false;
        
    }
    public TreeNode(char key)
    {
        Key = key;
        IsNodeEmpty = false;
    }

    public TreeNode<T> Add(string KeyString, T NodeData)
    {
        //Debug.Log(KeyString+" "+ KeyString.Length);
        if (KeyString.Length < 1)
        { 
            _Data = NodeData;
            return this;
        }
        if (ChildNodes == null) ChildNodes = new List<TreeNode<T>>();
        TreeNode<T> node = ChildNodes.Find(x => x.Key == KeyString[0]);

        if(node == null)
        {
            node = new TreeNode<T>(KeyString[0]);
            ChildNodes.Add(node.Add(KeyString.AppendIndex(0),NodeData)); //oh boy, we're in for a bumpy ride
        }
        else
        {
            node.Add(KeyString.AppendIndex(0), NodeData);
        }
        
        return this;
    }
    public TreeNode<T> getData(string keypath)
    {
        return getData(keypath, null);
    }
   
    //assume that we're still dealing with Movedata, initial
    public TreeNode<T> getData(string keypath,TreeNode<T> currentData)
    {
        //here goes...
        if(keypath.Length < 1)
        {
            if (_Data == null)
                return currentData;
            else
                return this;
        }
        for(int x=0;x< ChildNodes.Count; x++)
        {
            if(keypath[0] == ChildNodes[x].Key)
            {
                return ChildNodes[x].getData(keypath.AppendIndex(0), this);
            }
        }
        return null;
        //figure out how to make this nullable (?)
        // algorithm, go and search for this stringpath. if it is a lazyGet, track what data you have encountered on the way,
        // if there is no data located at the specified keypath, return the tracked data 
    }
   
    bool ContainsNodeWithKey(char key) 
    {
        for( int x=0; x< ChildNodes.Count;x++)
            if(ChildNodes[x].Key == key)
            {
                return true;
            }
        return false;
    }
    void ChildLookup()
    {

    }

    public void RemoveBranch()
    {

    }
}
public class EmptyNode<T>:TreeNode<T>
{
    public EmptyNode(): base()
    {
        IsNodeEmpty = true;
        
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




static class CharStringsOperationsExtension
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
    public static string AppendIndex(this string str, int index)
    {
        //maybe fix a better exception here...
        if (index >= str.Length)
            Debug.LogError("Index to be appended exceeds string length");
        if (index < 0)
            Debug.LogError("Index to be appended should not be less than 0");

        string _str = "";
        for(int x=0; x< str.Length;x++)
        {
            if (x == index)
                continue;
            _str += str[x];
        }
        return _str;
    }
}
public class AppenedIndexExceedingStringException : Exception
{
    public AppenedIndexExceedingStringException()
    {

    }
}

