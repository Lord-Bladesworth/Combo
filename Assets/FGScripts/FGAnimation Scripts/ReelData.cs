using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timeline data that sorts its entries in a time map and returns data nearest to the receieved "index"
//TODO null cases
[System.Serializable]
public class ReelData<T>
{
    
    ReelCel<T>[] _celData;
    public ReelCel<T>[] getCels { get { return _celData; } }
    /// <summary>
    /// gets the overall length duration of the reel
    /// </summary>
    public int ReelLength { get { return _celData[_celData.Length-1].TimePoint; } }

    /// <summary>
    /// get the array
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public ReelData()
    {

    }
    public ReelData(T[] data,int TimeInbetween =1)
    {
        Add(data, TimeInbetween);
    }
    /// <summary>
    /// gets data from the Reel relative to Time
    /// </summary>
    /// <returns></returns>
    public T ReadReelData(int Time)
    {
        return GetNearestData(Time);
    }
    T GetNearestData(int Time)
    {
        if (ReelLength == 1 || Time < _celData[0].TimePoint) 
            return _celData[0].Celdata; 

        ReelCel<T> temp=_celData[0];
        int Diff, BestDiff = Time - _celData[0].TimePoint , BestIndex =0;
        for(int i=1; i< _celData.Length;i++)        {
            Diff = Time- _celData[i].TimePoint;
            if(Diff >= 0)
            {
                if(i==0)
                {
                    BestDiff = Diff;
                    BestIndex = i;
                }
                else
                {
                    if(Diff < BestDiff)
                    {
                        BestDiff = Diff;
                        BestIndex = i;
                    }
                }
            }
        }
        return _celData[BestIndex].Celdata;
    }
    public void Add(T data, int TimeMark)
    {

        //refactor later
        if (_celData == null)
        {
            _celData = new ReelCel<T>[1];
            _celData[0] = new ReelCel<T>(data, TimeMark);
            return;
        }

        if (IsOverwriting(data, TimeMark))
            return;
        //create a temporary array and populate with it _celdata occupants
        ReelCel<T>[] tempCels = new ReelCel<T>[_celData.Length + 1];
        for(int a=0; a< _celData.Length;a++)
        {
            tempCels[a] = _celData[a];
        }
        tempCels[tempCels.Length - 1] = new ReelCel<T>(data, TimeMark); //adds the new element to the last index of the temporary array
        _celData = tempCels;
        SortTimeline(); //sort the array in chronological manner
    }

    //for raw additions of data without any specific time marks
    public void Add(T[] ArrayData,int FramesInbetween = 1)
    {
        //force frames inbetween to 1 if the user is trying to be cheeky
        if(FramesInbetween < 0)
        {
            FramesInbetween = 1;
        }
        ReelCel<T>[] temp = new ReelCel<T>[ArrayData.Length];
        for(int i=0, time=0; i< ArrayData.Length; i++, time+=FramesInbetween)
        {
            temp[i] = new ReelCel<T>(ArrayData[i], time);
        }
        _celData = temp;
    }
    bool IsOverwriting(T data, int TimeMark)
    {
        for(int p=0;p<_celData.Length;p++)
        {
            if(_celData[p].TimePoint == TimeMark)
            {
                _celData[p].SetData(data);
            }
        }
        return false;
    }

    void SortTimeline()
    {
        ReelCel<T> temp;
        //do a selectionsort
        for (int i = 1; i < _celData .Length; i++)
        {
            temp = _celData[i];
            for (int x = i; x >= 0; x--)
            {
                if (temp.TimePoint < _celData[x - 1].TimePoint)
                {
                    _celData[x] = _celData[x - 1];
                    _celData[x - 1] = temp;
                }
                else break;
            }
        }
    }
    
    public void Delete(int index)
    {
        _celData[index] = null;
        int ArrLength = _celData.Length-1;
        ReelCel<T>[] temp = new ReelCel<T>[ArrLength];
        for (int i = 0, v = 0; i < _celData.Length; i++)
        {
            if (_celData[i] != null)
            {
                temp[v] = _celData[i];
                v++;
              }
        }
        _celData = temp;
        SortTimeline(); //for good measure
    }

}

//base implicit class using the custom timeline system
public class ReelCel<T>
{
    public T Celdata { get; private set;}
    public int TimePoint { get; private set; }
    public ReelCel(T data, int Point)
    {
        Celdata = data;
        TimePoint = Point;
    }
    public void SetData(T data)
    {
        Celdata = data;
    }
}
