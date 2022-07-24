using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterRunner : MonoBehaviour
{ 
    static MasterRunner _instance;
    Dictionary<string, CallbackGroup> Callbacks;
    int time = 0;
    public static MasterRunner instance{
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject("MasterRunner").AddComponent<MasterRunner>();
            }
            return _instance;
        }
    }

    class CallbackGroup
    {
        public System.Action callback;
        public bool isRunning;
        public CallbackGroup()
        {
            isRunning = true;
        }
    }
    public static void ToggleCallbackUpdate(string CallbackName, bool toggleState)
    {
        if (instance.Callbacks.ContainsKey(CallbackName))
            instance.Callbacks[CallbackName].isRunning = toggleState;
    }
    public static void addtoCallback(System.Action action, string CallbackGroupName = "Default")
    {
        instance.InitGroups();
        if (!instance.Callbacks.ContainsKey(CallbackGroupName))
            instance.Callbacks.Add(CallbackGroupName,new CallbackGroup());
        instance.Callbacks[CallbackGroupName].callback += action;
       
    }
    void InitGroups()
    {
        if (Callbacks != null) return;
        Callbacks = new Dictionary<string, CallbackGroup>();
        Callbacks.Add("Default", new CallbackGroup());
    }
  
    public void FixedUpdate()
    {
        time++;
        if (time > 2)
        {
            foreach(var acts in Callbacks)
            {
                if(acts.Value.isRunning)
                acts.Value.callback();
            }
            time = 0;
        }
    }

    /// <summary>
    /// start a slow mo event to affected callbackgroups with a fixed rate
    /// </summary>
    /// <param name="DelayRate"></param>
    /// <param name="AffectedGroups"></param>
    void StartSlowmoEvent(int DelayRate,string[] AffectedGroups)
    {
        //note, Possibly replace "Group" into a bit mask similar to layermask group
        StartCoroutine("SlowmoTimer");
    }
    /// <summary>
    /// start a slow mo event to affected callbackgroups with an interpolating rate
    /// </summary>
    /// <param name="InitialRate">starting rate</param>
    /// <param name="FinalRate">the final rate</param>
    /// <param name="AffectedGroups"></param>
    void StartSlowmoEvent(float InitialRate, float FinalRate,string[] AffectedGroups)
    {

    }
    IEnumerator SlowmoTimer()
    {
        yield return null;
    }

}

