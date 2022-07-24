using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
namespace Ragna {
    //receieves button commands from controllers and executes state data into other components
    public class RagnaScript : MonoBehaviour
    {
        HitboxMaster hitboxMaster;
        BodyController body;
        RagnaAnimation animation;

     

        CharacterState CurrentState;
        CharacterState DefaultState;
        [SerializeField]
        CharacterData RagnaData;

        bool CancelFlag; //checks if the current state is now cancellable

        DirectionalButton LastReceievedCommand;

        //RagnaRigidData[] Hitdata;
        RigidHitData[] OnhitRigidata;
        private void Awake()
        {
            if (!GetComponent<HitboxMaster>())
            {
                gameObject.AddComponent<HitboxMaster>();
            }           
            hitboxMaster = GetComponent<HitboxMaster>();
        }

        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<BodyController>();
            animation = GetComponent<RagnaAnimation>();
            RagnaData.FinalizeData();
            body.Build(RagnaData.moveStats);

            animation.FrameExecutionAction += OnFrameStart;
            animation.StatePlayFinishAction += OnAnimationFinish;
            CancelFlag = false;
            CurrentState = RagnaData.CharacterStates[0];
            animation.CurrentState = CurrentState;
        }

  
        private void OnGUI()  
        {
            if(RagnaData != null)
            {
                GUI.Label(new Rect(50, 50, 230, 130), LastReceievedCommand.ToString());
            }
        }
        private void RagnaCallback()
        {

        }
        private void Update()
        {

        }

        /// TASK re-evaluate data composition and how it will be handled in the statemachine(ragnascript)
        public void ReceieveButton(DirectionalButton button)
        {
            LastReceievedCommand = button;
            ProcessCommand();
       
        }
        void ProcessCommand()
        {
            if(LastReceievedCommand.Button != ButtonEnum.N)
            {

            }
            else
            {

            }


            for(int x=0; x< RagnaData.CharacterStates.Count;x++)
            {
                if(RagnaData.CharacterStates[x].StateKey.Equals(LastReceievedCommand))
                {
                    if(RagnaData.CharacterStates[x].Category == StateCategory.Movement)
                    {
                        if(LastReceievedCommand.DirectionalPrefix ==1|| LastReceievedCommand.DirectionalPrefix == 4 || LastReceievedCommand.DirectionalPrefix == 7)
                        {
                            SwitchState(RagnaData.CharacterStates[x], true);
                        }
                        if (LastReceievedCommand.DirectionalPrefix == 1 || LastReceievedCommand.DirectionalPrefix == 4 || LastReceievedCommand.DirectionalPrefix == 7)
                        {
                            SwitchState(RagnaData.CharacterStates[x],false);
                        }
                    }
                    SwitchState(RagnaData.CharacterStates[x]);
                    return;
                }
               
            }
        }
        void SwitchState(CharacterState state)
        {
            CurrentState = state;
            animation.SwitchState(CurrentState);
            
        }
        void SwitchState(CharacterState state, bool flipDir)
        {
            CurrentState = state;
            animation.SwitchState(CurrentState, flipDir);
        }
        public void OnAnimationFinish(string StateName)
        {
            if (CurrentState.StateKey.Equals(LastReceievedCommand))
            {
                return;
            }
            switch (CurrentState.Category)
            {
                case StateCategory.Idle:
                    break;
                case StateCategory.Button:
                    for(int x=0; x<RagnaData.CharacterStates.Count;x++)
                    {
                        if(RagnaData.CharacterStates[x].Category == StateCategory.Idle)
                        {
                            Debug.Log("Idle process has been found");
                            SwitchState(RagnaData.CharacterStates[x]);  
                        }
                    }
                    break;
            }
        }

        void SwitchtoState()
        {

        }
        //yeah, definitely should work on avoiding this. streamline the whole process
        public void OnFrameStart(string StateName,int FrameNumber)
        {
            if (CurrentState == null)
                return;

            switch(CurrentState.Category)
            {
                case StateCategory.Idle:
                    break;
                case StateCategory.Button:
                    if (CurrentState.CancellableTime == FrameNumber)
                        CancelFlag = true;
                    break;
                case StateCategory.Movement:
                    
                    break;
            }
        }
      
    }
    
    public static class CharaterStateExtensions
    {
        public static void BuildStates(this CharacterState[] States)
        {
            for(int x=0; x< States.Length;x++)
            {
                States[x].Build();
            }
        }
    }

    [System.Serializable]
    public class RagnaRigidData
    {
        public Vector2 Launch;
        public Vector2 Bounce;
        public enumRigidInteraction InteractionType;
        public enumRigidTarget Target;
        public int ActivationTime;
        public int ActivationEnd;
        public RigidHitData rigidHitData { get; private set; }
        public void Build()
        {
            rigidHitData = new RigidHitData(Launch, Bounce, InteractionType, Target);
        }
        
    }
    [System.Serializable]
    public class RagnaAnimationData
    {
        public AnimationClip clip;
        public float CancellableAt; //at which time can the animation be transitioned into another animation state
        public bool isAnimationDone()
        {
            return false;
        }

    }

}