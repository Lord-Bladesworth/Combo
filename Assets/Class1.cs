using System;
using System.Collections.Generic;
using UnityEngine;
using Ragna;
using testGarbage;
namespace Assets
{
    //class that's mainly to test components
    public class Class1:MonoBehaviour
    {
        [SerializeField]
        List<TestAnimData> animations;

        RagnaAnimation animComp;
        private void Awake()
        {
            if (!GetComponent<RagnaAnimation>())
                gameObject.AddComponent<RagnaAnimation>();
            animComp = GetComponent<RagnaAnimation>();
            animComp.FrameExecutionAction += listener;
            animComp.StatePlayFinishAction += Stalker;

            if (animations != null || animations.Count >0)
                BuildData();
            
        }
        void BuildData()
        {

        }
        private void listener(string str, int Time)
        {
            if(str == "Attk1")
            {
                if (Time == 10)
                    Debug.Log("Wack!");
            }
        }
        void Stalker(string AnimationName)
        {
            Debug.Log(AnimationName + " Animation is finished");
        }


        private void OnGUI()
        {
            if(GUI.Button(new Rect(10,10,50,50),"Attack"))
            {
            }
            if(GUI.Button(new Rect(10,60,50,50),"Jesus Kick"))
            {
            }
        }

    }

    [System.Serializable]
    public class TestAnimData
    {
        public string name;
        public bool IsDefault;
        public spritesData[] sprites;
    }
}