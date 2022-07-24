using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Ragna
{

    //not in use. uses a legacy animation system, not even going to bother
    //component that handles communication with the animation component
    public class RagnaAnimator : MonoBehaviour
    {
        public Action AnimationDoneAction;
        public Func<DirectionalButton> AnimationDone;
        
        AnimationClipsIndex AnimData;
        List<AnimationClipsIndex> animations;

        class AnimationClipsIndex
        {
            public DirectionalButton buttonIdentifier { get; }
            public RagnaAnimationData animClip { get; } //posible to just save the hash instead and navigate through the animation clips to save the additional overhead
            public int AssocAnimHash;
            public AnimationClipsIndex(DirectionalButton button, RagnaAnimationData animData)
            {
                buttonIdentifier = button;
                animClip = animData;
            }
        }
        //yeah there's no saving this one. trash it and use the custom animation component by using spriterenderer image replacement
        Animator animComp;
        private void Awake()
        {
            if (!GetComponent<Animation>())
            {
                gameObject.AddComponent<Animation>();
            }
            animComp = gameObject.GetComponent<Animator>();
        }
        // Start is called before the first frame update
        void Start()
        {
            animations = new List<AnimationClipsIndex>();
          
        }
        public void AddAnimation(DirectionalButton button,RagnaAnimationData animation)
        {
            animations.Add(new AnimationClipsIndex(button, animation));

            //animComp.set
            Debug.Log(button.ToString() + " Animation data has been added");
        }
        // Update is called once per frame
        void Update()
        {

        }

        void ChangeCurrentAnimation()
        {
           
            
        }
        void OnAnimationFinish()
        {

        }
    }

}
