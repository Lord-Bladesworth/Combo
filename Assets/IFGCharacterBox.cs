using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFGCharacterBox 
{
    void Activate();
    void Activate(Vector2 offset);
    void Activate(float x=0, float y=0);
    void DeActivate();
}
