using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
namespace Ragna {
    //receieves button commands from controllers and executes state data into other components
    public class RagnaScript2 : MonoBehaviour
    {
        HitboxMaster hitboxMaster;
        BodyController body;
        RagnaAnimation2 animation;

     

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
           // Debug.Log("Checking " + LastReceievedCommand.ToString() + " with current " + CurrentState.StateKey);
            if(CurrentState.StateKey.Equals(LastReceievedCommand))
            {
                return;
            }
            for(int x=0; x< RagnaData.CharacterStates.Count;x++)
            {
              //  Debug.Log("currently checking " + RagnaData.CharacterStates[x].StateKey + " with " +LastReceievedCommand +" Results "+ (RagnaData.CharacterStates[x].StateKey.Equals(LastReceievedCommand)));
                if(RagnaData.CharacterStates[x].StateKey.Equals(LastReceievedCommand))
                {           
                    CurrentState = RagnaData.CharacterStates[x];
                    CancelFlag = false;
                    break;
                }
               
            }
        }
        void SwitchState(CharacterState state)
        {
            CurrentState = state;

        }
        public void OnAnimationFinish(string StateName)
        {
            switch(CurrentState.Category)
            {
                case StateCategory.Idle:
                    break;
                case StateCategory.Button:
                    for(int x=0; x<RagnaData.CharacterStates.Count;x++)
                    {
                        if(RagnaData.CharacterStates[x].Category == StateCategory.Idle)
                        {
                            CurrentState = RagnaData.CharacterStates[x];

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
            }
        }
      
    }


}