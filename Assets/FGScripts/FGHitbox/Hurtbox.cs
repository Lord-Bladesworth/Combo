using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hurtbox : MonoBehaviour
{
    Action OnHitAction;
    public void ChangeRect(Vector2 Position, Vector2 Size)
    {

    }


    public void HurtBoxHit()
    {
        OnHitAction();
    }
}
