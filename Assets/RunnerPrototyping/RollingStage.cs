using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

namespace RunnerGame
{
    public class RollingStage : MonoBehaviour
    {
        public GameObject[] ModulePool;

        List<GameObject> ModulesinField;
        public float scrollSpeed;
        // Start is called before the first frame update
        void Start()
        {
            GenertePreLevels();
        }
        void GenertePreLevels()
        {
            ModulesinField = new List<GameObject>();
            for (int x = 0; x < 9; x++)
            {
                GameObject obj = GameObject.Instantiate(ModulePool[Random.Range(0, ModulePool.Length)]);
                ModulesinField.Add(obj);
                if (x == 0)
                {
                    ModulesinField[x].transform.position = transform.position;
                }
                else
                {
                    ModulesinField[x].transform.position = ModulesinField[x - 1].transform.Find("Endpoint").transform.position;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            RollStage();
        }

        void RollStage()
        {
            for (int x = 0; x < ModulesinField.Count; x++)
            {
                if (ModulesinField[x].activeSelf)
                {
                    ModulesinField[x].transform.Translate(scrollSpeed * -1, 0, 0);
                    if (Vector2.Distance(transform.position, ModulesinField[x].transform.position) > 10)
                    {
                        // ModulesinField[x].SetActive(false);
                    }
                }
            }
        }

    }

}