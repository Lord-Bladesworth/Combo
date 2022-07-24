using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(SpriteRenderer))]
public class FGAnimationComp : MonoBehaviour
{
    SpriteRenderer sprRenderer;
    
    Dictionary<string, FGAnimationStateData> Animations; //check for another way to ID a state later aside from string
    /// <summary>
    /// Delegate for storing events when the a state's animation is finished playing. Note: State transition decisions is to be handled by the Agent Component
    /// </summary>
    public Action<string> StatePlayEndAction;
    public Action<string> AnimationTransitionAction;
    string CurrentState;
    public string GetCurrentState { get { return CurrentState; } }
    private string SetAnimation { 
        set {
            ResetAnimation();
            CurrentState = value;
        } 
    }

    int delayCounter = 0;
    int Timer = 0;
    bool IsHeld = false;

    //build the animation passed by the caller
    public void BuildAnimations(Blip[] anims, string DefaultState = "Idle")
    {
        if (Animations == null)
            Animations = new Dictionary<string, FGAnimationStateData>();

        for (int x = 0; x < anims.Length; x++)
        {
            if (!Animations.ContainsKey(anims[x].StateName))
            {
                Animations.Add(anims[x].StateName, null);
            }
        }
        for (int y = 0; y < anims.Length; y++)
        {
            Animations[anims[y].StateName] = anims[y].Statedata;
        }
        CurrentState = DefaultState;
    }

    public void BuildAnimation(FGAnimationData data, string DefaultState = "Idle")
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        MasterRunner.addtoCallback(AnimationPlay);
    }
    void AnimationPlay()
    {
        if (!IsHeld)
        {
            sprRenderer.sprite = Animations[CurrentState].Play(Timer);
            Timer++;
            if (Timer > Animations[CurrentState].stateReelLength)
            {
                IsHeld = true;
                Timer = 0;
                if (Animations[CurrentState].IsLoop)
                {
                    IsHeld = false;
                }
                if (StatePlayEndAction != null)
                    StatePlayEndAction(CurrentState);
            }
        }
    }
    public void SwitchState(string State, bool AnimationCancel = true)
    {
        if (!Animations.ContainsKey(State))
        {
            Debug.Log("Warning, Animations dictionary does contain a state named " + State);
            return;
        }
        if ((State == CurrentState) && !AnimationCancel)
        {
            return;
        }
        CurrentState = State;
        IsHeld = false;
        Timer = 0;

     
    }
    public void ChangeState(string state, PlaybackSwitchMode switchMode)
    {
        //cancel state process if state is not found
        if(!Animations.ContainsKey(state))
        {
            Debug.Log("Warning, Animations dictionary does not contain a state named " + state);
            return;
        }
        switch(switchMode)
        {
            case PlaybackSwitchMode.Interrupt:
                SetAnimation = state;
                break;
            case PlaybackSwitchMode.DontInterrupt:
                //i have no idea what the fuck is this for.... reconsider later
                //do not interrupt the current state if the target state is the currently playing state.
                if (Timer > Animations[CurrentState].stateReelLength)
                    ResetAnimation();
                break;
            case PlaybackSwitchMode.OnAnimationFinish:
                break;
            case PlaybackSwitchMode.OnSpecificFrame:
                break;
            
        }
    }
    public void ResetAnimation()
    {
        
        IsHeld = false;
        Timer = 0;
    }
    public void ChangeStateOnSpecificFrame(int Frame)
    {

    }
    IEnumerator FrameTracker()
    {
        yield return null;
    }
}
public enum PlaybackSwitchMode
{
    Interrupt,DontInterrupt,OnAnimationFinish,OnSpecificFrame
}
