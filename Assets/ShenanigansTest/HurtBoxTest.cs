using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace testSpace
{
    public class HurtBoxTest : MonoBehaviour
    {
        public Action<string> ParentNotify;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void HurtEvent()
        {
            ParentNotify(this.name);
        }
    }
}
