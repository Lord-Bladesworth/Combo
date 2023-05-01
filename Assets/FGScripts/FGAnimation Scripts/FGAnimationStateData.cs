 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGAnimations;

[System.Serializable]
public class FGAnimationStateData
{
    public string StateName;
    public bool IsLoop;
    ReelData<Sprite> spriteFrames;
    //public FGAnimationCel[] AnimationCels; //for use mainly for the editor
    public int stateReelLength { get {return spriteFrames.ReelLength; } }
    
    public FGAnimationStateData()
    {

    }

    public void BuildStateData()
    {
        
    }
    public FGAnimationStateData(Sprite[] sprites,bool AnimationOnCycle= false)
    {
        spriteFrames.Add(sprites);
        IsLoop = AnimationOnCycle;
    }
    //TODO modify later for better optimization
    public Sprite Play(int clock)
    {
        return spriteFrames.ReadReelData(clock);
    }
}
[System.Serializable]
public class FGAnimationCel
{
    public Sprite FrameSprite;
    public int TimeMark;

}
//name subject to change. placeholder data for FGAnimationData along with the animationstate identifier
public class Blip
{
    public string StateName;
    public FGAnimationStateData Statedata;
}
