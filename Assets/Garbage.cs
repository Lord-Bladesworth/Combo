using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public datastuff[] stuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class datastuff
{
    public int number;
    public string strings;
    public int[] numberology;
    public shite shit;
}
[System.Serializable]
public class shite
{
    public int x, y;
    Testenums test;

    public enum Testenums
    {
        fi,fie,fo,fum
    }
}
