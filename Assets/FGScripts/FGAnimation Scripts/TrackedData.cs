using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackReel<T>
{
    TrackData<T>[] Data;

    public TrackData<T> this [int Time] { get { return null; } }

    TrackData<T> ReadData(int Time)
    {

        return null;
    }



}

public class TrackData<T>
{
    public T data;
    public int TimeMark;

}

