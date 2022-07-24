using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FGAnimationData
{
    public List<StateData> stateData;

}

[System.Serializable]
public class StateData
{
    public string StateName="";
    public ReelCel<Sprite> sprites;
    public bool IsLoop;

    public StateData()
    {
       // sprites = new ReelData<Sprite>();
    }
}