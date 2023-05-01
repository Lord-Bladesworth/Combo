using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StateClock : MonoBehaviour
{
    int StateTime;
    int StateDuration;
    Action<int> TickEvent;
    Action StateFinishedAction;

    int time { get { return StateTime; } }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateTick();   
    }
    void StateTick()
    {
        TickEvent(StateTime);
        StateTime++;
        if (StateTime > StateDuration)
        {
            StateTime = 0;
            StateFinishedAction();
        }
    }

    
}
