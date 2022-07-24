using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Ragna
{

    /// <summary>
    /// converts raw inputs into commands then passes the commands into RagnaScript
    /// </summary>
    public class RagnaController : MonoBehaviour
    {
        RagnaScript ragnaScript;
        DirectionalButton buttonBuffer;
        Vector2 MovementBuffer;

        bool isAHold, isBHold, isCHold, isDHold, isMovementHold;


        List<contButton> buttons;
        class contButton
        {
            public string buttonLabel;
            public bool IsHold;
           
        } // the lazy way

    

        void ProcessHorizontal(Vector2 vect)
        {
            
        }
        void ProcessVertical(Vector2 vect)
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
            ragnaScript = GetComponent<RagnaScript>();
            buttonBuffer = new DirectionalButton("5N");
            buttons = new List<contButton>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        private void LateUpdate()
        {
            ragnaScript.ReceieveButton(buttonBuffer);
        }
        void ProcessInputs()
        {
            //ragnaScript.ReceieveButton(buttonBuffer);
        }
        void Processbutton(string label,bool isOnHold)
        {
            if (!findButton(label))
            {
                buttons.Add(new contButton() { buttonLabel = label, IsHold = false });
            }

        }

        bool findButton(string label)
        {
            if (buttons.Count < 1)
                return false;

            for(int x=0; x< buttons.Count;x++)
            {
                if (buttons[x].buttonLabel == label)
                    return true;
            }
            return false;
        }
        private void OnGUI()
        {
      
 
        }
        public void OnButtonA(InputAction.CallbackContext cont)
        {
            if(cont.phase == InputActionPhase.Started)
            {
                buttonBuffer.Button = ButtonEnum.A;
            }
            else if(cont.phase == InputActionPhase.Canceled)
            {
                buttonBuffer.Button = ButtonEnum.N;
            }
            Debug.Log("ping!");
           
        }
        public void OnButtonB(InputAction.CallbackContext cont)
        {
            if (cont.phase == InputActionPhase.Started)
            {
                buttonBuffer.Button = ButtonEnum.B;
            }
            else if (cont.phase == InputActionPhase.Canceled)
            {
                buttonBuffer.Button = ButtonEnum.N;
            }
        }
        public void OnButtonC(InputAction.CallbackContext cont)
        {
            if (cont.phase == InputActionPhase.Started)
            {
                buttonBuffer.Button = ButtonEnum.C;
            }
            else if (cont.phase == InputActionPhase.Canceled)
            {
                buttonBuffer.Button = ButtonEnum.N;
            }
        }
        public void OnMovement(InputAction.CallbackContext cont)
        {
            buttonBuffer.setPrefixByVector = cont.ReadValue<Vector2>();
            Debug.Log("ping!");
        }
        public void OnVertical(InputAction.CallbackContext cont)
        {
         
            

        }
    }
}
