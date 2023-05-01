using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FGAnimations;
namespace Ragna {
    [RequireComponent(typeof(SpriteRenderer))]
    public class RagnaAnimation2 : MonoBehaviour
    {
        SpriteRenderer spr;
        ReelData<Sprite> _reel;
        Action<int> OnFrameDrawAction;
        Action OnAnimationDoneAction;

        int Clock;
        // Start is called before the first frame update
        void Start()
        {
            MasterRunner.addtoCallback(AnimationUpdate);
            spr = GetComponent<SpriteRenderer>();
            Clock = 0;
        }
        void SwitchReel(ReelData<Sprite> reel)
        {
            _reel = reel;
            Clock = 0;
        }
        void SubscribetoFrameDraw(Action<int> act)
        {
            OnFrameDrawAction += act;
        }
        void SubscribeAnimationFinish(Action act)
        {
            OnAnimationDoneAction += act;
        }
        void ResetClock(int Offset=0)
        {
            Clock = 0 + Offset; 
        }
        void AnimationUpdate()
        {
            if (Clock > _reel.ReelLength)
            {
                Clock = 0;

                if (OnAnimationDoneAction != null)
                    OnAnimationDoneAction(); 
            }

            spr.sprite = _reel[Clock].Celdata;
            if(OnFrameDrawAction != null)
                OnFrameDrawAction(Clock);
            Clock++;
        }

    }
}

