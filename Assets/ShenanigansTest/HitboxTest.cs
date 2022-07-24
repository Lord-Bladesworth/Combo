using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace testSpace
{
    public class HitboxTest : MonoBehaviour
    {


        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Hit Detected");
            if (collision.GetComponent<HurtBoxTest>())
                collision.GetComponent<HurtBoxTest>().HurtEvent();
        }
    }
}