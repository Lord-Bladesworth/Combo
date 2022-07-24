using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Ragna {

    //Animation component that utilizes the ReelData container
    [RequireComponent(typeof(SpriteRenderer))]
    public class RagnaAnimation : MonoBehaviour
    {
        SpriteRenderer spr;

        public CharacterState CurrentState;
        /// <summary>
        /// invoke actions subscribed to this every time PlayCallback is invoked, Passes the Name of the state and Clock
        /// </summary>
        public Action<string, int> FrameExecutionAction; 
        /// <summary>
        /// Invoke this action when the animation has finished playing its action 
        /// </summary>
        public Action<string> StatePlayFinishAction;
        /// <summary>
        /// Invoke this action when transitioning to a new state (tentative if it is to keep
        /// </summary>
        public Action<string,string> AnimationTransitionAction;

        int Clock=0;
        bool isflipped;


        public string animPlaying { get; private set; } //use int to keep track of the current state?

        private void Awake()
        {
            spr = GetComponent<SpriteRenderer>();
            MasterRunner.addtoCallback(action: PlayCallback);
            animPlaying = "";
        }


        public void SwitchState(CharacterState State, int playAt=0)
        {
            CurrentState = State;
            Clock = playAt;
        }
        public void SwitchState(CharacterState state, bool isFlip)
        {
            CurrentState = state;
            spr.flipX = isFlip;
        }
        private void PlayCallback()
        {
            if (Clock > CurrentState.animationReel.ReelLength)
            {
                if (StatePlayFinishAction != null)
                {
                    StatePlayFinishAction(CurrentState.StateName);
                }
                Clock = 0;
            }

            if (FrameExecutionAction != null)
            {
                FrameExecutionAction.Invoke(CurrentState.StateName, Clock);
            }
            spr.sprite = CurrentState.animationReel.ReadReelData(Clock);   
            Clock++;

        }


    }


}

