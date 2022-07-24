using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace testGarbage
{
    public class ClassB : MonoBehaviour
    {

        public spritesData[] sprites;
        public stringdata[] strs;
        [SerializeField]
        Sprite[] IzanamiSprites;
        ReelData<string> strTimelineData;
        ReelData<Sprite>[] AnimationData;
        SpriteRenderer rend;
        string prevStr, currentStr;
        int x, activeTimeline;

        // Start is called before the first frame update
        void Start()
        {
            prevStr = "";
            x = 0;
            activeTimeline = 0;
            AnimationData = new ReelData<Sprite>[2];
            strTimelineData = new ReelData<string>();
            if (!GetComponent<SpriteRenderer>())
            {
                gameObject.AddComponent<SpriteRenderer>();

            }
            AnimationData[0] = new ReelData<Sprite>();
            AnimationData[1] = new ReelData<Sprite>();
            rend = GetComponent<SpriteRenderer>();
            for (int i = 0; i < sprites.Length; i++)
            {
                AnimationData[0].Add(sprites[i].spr, sprites[i].TimeMark);
            }
            for (int x = 0; x < strs.Length; x++)
            {
                strTimelineData.Add(strs[x].str, strs[x].timeMark);
            }
            AnimationData[1].Add(IzanamiSprites, 2);

            //f
            MasterRunner.addtoCallback(action: PlayAnimation);
        }

        void PlayAnimation()
        {
            rend.sprite = AnimationData[activeTimeline].ReadReelData(x);
            currentStr = strTimelineData.ReadReelData(x);
            x++;

            if (currentStr != prevStr)
            {
                // Debug.Log("change state to " + currentStr + " at Index: " + x);
                prevStr = currentStr;
            }
            if (x > AnimationData[activeTimeline].ReelLength)
                x = 0;

        }
        // Update is called once per frame
        void Update()
        {


        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(240, 100, 70, 40), "Azrael"))
            {
                activeTimeline = 0;
            }
            if (GUI.Button(new Rect(240, 140, 70, 40), "Izanami"))
            {
                activeTimeline = 1;
            }
            if (GUI.Button(new Rect(240, 180, 70, 40), "DELET"))
            {
                AnimationData[activeTimeline].Delete(0);
            }
            GUI.Label(new Rect(50, 70, 100, 100), currentStr);
            GUI.Label(new Rect(50, 30, 100, 100), x + " ");
        }


    }
    [System.Serializable]
    public class spritesData
    {
        public Sprite spr;
        public int TimeMark = 1;
    }

    [System.Serializable]
    public class stringdata
    {
        public string str;
        public int timeMark;

    }
}