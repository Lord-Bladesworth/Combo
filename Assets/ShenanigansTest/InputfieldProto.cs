using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputfieldProto : MonoBehaviour
{
    currentSequenceStruct currentSequence = new currentSequenceStruct();
    Dictionary<ButtonEnum, MoveInputData> inputRigidData= new Dictionary<ButtonEnum, MoveInputData>();
    Queue<ButtonEnum> InputBufferQueue = new Queue<ButtonEnum>();
    Stack<ButtonEnum> InputHistory = new Stack<ButtonEnum>();
    HitboxMaster HBMaster;
    private bool PressActivated(InputAction.CallbackContext cont)
    {
        return cont.phase == InputActionPhase.Performed;
    }

    // Start is called before the first frame update
    void Start()
    {
        HBMaster = GetComponent<HitboxMaster>();
        //oh boy...
        inputRigidData.Add(ButtonEnum.A,new MoveInputData(new RigidHitData(new Vector2(4,0),Vector2.zero),
            new MoveInputData(new RigidHitData(Vector2.left * 9,Vector2.zero), 
            new MoveInputData(new RigidHitData(new Vector2(-4,9),Vector2.zero),
            new MoveInputData(new RigidHitData(Vector2.down *3,Vector2.zero)))))); //yeah definitely not the definite solution
        inputRigidData.Add(ButtonEnum.B, new MoveInputData(new RigidHitData(new Vector2(-12, 1), new Vector2(12,9),enumRigidInteraction.bounce,enumRigidTarget.wall)));


    }
    void FixedUpdate()
    { 
    //tally stuff
    }
    /*
   public void ButtonA(InputAction.CallbackContext context)
    {
        if(PressActivated(context))
        {
            if (currentSequence.currentData == null)
            {
                HBMaster.ActivateHitbox(new Hitdata(this.transform.position, new SourceEntityData(), inputRigidData[ButtonEnum.A].rigidData, new MoveHitData()), 1, new BoxRectStruct(0, 0, 3f, 1.4f), 6);
                if (inputRigidData[ButtonEnum.A].isSequence)
                    currentSequence.setCurrentData(ButtonEnum.A, inputRigidData[ButtonEnum.A].nextSequence);
            }
            else
            {
                HBMaster.ActivateHitbox(new Hitdata(this.transform.position, new SourceEntityData(), currentSequence.currentData.rigidData, new MoveHitData()), 1, new BoxRectStruct(0, 0, 3f, 1.4f), 6);
                currentSequence.currentData = currentSequence.currentData.nextSequence;
            }
           
        }
    }
    */
    public void ButtonA(InputAction.CallbackContext context)
    {

    }
   public void ButtonB(InputAction.CallbackContext context)
    {
        if (PressActivated(context))
            HBMaster.ActivateHitbox(new Hitdata(this.transform.position, new SourceEntityData(), inputRigidData[ButtonEnum.B].rigidData, new MoveHitData()), 1, new BoxRectStruct(0, 0, 3f, 1.4f), 6);
    }
   public void ButtonC(InputAction.CallbackContext context)
    {
        if (PressActivated(context))
            Debug.Log("C has been performed");
    }
    class currentSequenceStruct
    {
        ButtonEnum buttonEnum;
        MoveInputData MoveInputData;
        public MoveInputData currentData
        {
            set
            {
                MoveInputData = value;
                if (MoveInputData == null)
                {
                    buttonEnum = ButtonEnum.N;
                }

            }
            get
            {
                return MoveInputData;
            }
        }
        public void setCurrentData(ButtonEnum button, MoveInputData data)
        {
            buttonEnum = button;
            currentData = data;

        }
        public currentSequenceStruct()
        {
            buttonEnum = ButtonEnum.N;
            MoveInputData = null;
        }
        
    }
}

//refactor a bit, solution not compatible with a flexible sequences
class MoveInputData
{
   public RigidHitData rigidData { get; }
   public MoveInputData nextSequence { get; }
   public bool isSequence { get { return nextSequence != null; } }
    public MoveInputData(RigidHitData hitData, MoveInputData SequenceData=null)
    {
        rigidData = hitData;
        nextSequence = SequenceData;
    }
    public MoveInputData(RigidHitData[] sequences)
    {
        rigidData = sequences[0];
    }
    
}


