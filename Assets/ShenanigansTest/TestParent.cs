using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace testSpace
{
    public class TestParent : MonoBehaviour
    {
        bool IsCooldown;
        Action HitAction;


        // Start is called before the first frame update
        void Awake()
        {
            IsCooldown = false;
            HurtBoxTest[] HitArr;
            HitArr = GetComponentsInChildren<HurtBoxTest>();
            for (int x = 0; x < HitArr.Length; x++)
            {
                HitArr[x].ParentNotify = HitEvent;
            }
        }

        public void HitEvent(string hittername)
        {
            if (!IsCooldown)
            {
                StartCoroutine("HitCD");
                Debug.Log("Hit registered by " + hittername);
            }

        }

        IEnumerator HitCD()
        {
            IsCooldown = true;
            int x = 6;
            while (x > 0)
            {
                Debug.Log("Parent On Cooldown");
                x--;
                yield return new WaitForSeconds(1);
            }
            IsCooldown = false;
        }

    }
}