using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ragna
{
    [System.Serializable]
    public class CharacterState
    {
        public string StateName;
        public StateCategory Category;
        public DirectionalButton StateKey;
        public int HitboxActivationTime;
        public RagnaRigidData HitRigidData;
        public List<AnimCel> AnimationData;
        public bool isAllCancellable; //is it Cancelkable regardless of time?
        public int CancellableTime; //at which time is the animation cancellable?
        public List<DirectionalButton> CancellablesTo; //gatling system. you know the picture
        public RigidHitData rigidHitData { get; private set; }
        public ReelData<Sprite> animationReel { get; private set; }
        public RigidHitData getRigidHitData
        {
            get { return rigidHitData; }
        }
        public void Build()
        {
            HitRigidData.Build();
            animationReel = new ReelData<Sprite>();
            for(int x=0;x< AnimationData.Count;x++)
            {
                animationReel.Add(AnimationData[x].spr, AnimationData[x].time);
            }


        }
        public int AnimationDuration
        {
            get { return AnimationData[AnimationData.Count - 1].time; }
        }

    }
    [System.Serializable]
    public class AnimCel
    {
        public int time;
        public Sprite spr;
    }
    //aux categories mainly for redundancy, possibly for use in AI later in development. by default states will fall into "Non"
    public enum StateCategory
    {
        Movement,OnHit, Jump, Button, Idle, Install,None, aux, aux1, aux2,aux3
    }
}
