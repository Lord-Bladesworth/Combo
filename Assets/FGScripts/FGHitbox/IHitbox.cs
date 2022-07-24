using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHitbox 
{
    public void Activate(Hitdata data, BoxRectStruct BoxRect);
    public void DeActivate();
    public void HitboxHit();

}
