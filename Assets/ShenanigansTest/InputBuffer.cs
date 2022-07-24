using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputBuffer: ScriptableObject
{
    private class ButtonData
    {
        public ButtonEnum button { get; }
        public float ButtonInputTime { get; }
        public ButtonData(ButtonEnum buttonInp, float time)
        {
            button = buttonInp;
            ButtonInputTime = time;

        }
    }
    private void Awake()
    {
    }
    //Stack<ButtonData> InputBuffer;
    Stack<ButtonData> InputHistory;
     
    void TallyButtonPress(ButtonEnum Button)
    {

    }
    void TallyMotion(Vector2 Motion)
    {

    }



}

public class BufferData
{
    Vector2 DirectionalInput;
    InputEnums Input;
    int FramesHeld; //how long has the buffered input been held;

}

