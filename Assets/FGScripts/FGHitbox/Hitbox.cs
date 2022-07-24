using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Hitbox : MonoBehaviour, IHitbox
{
    //Delegate for any events that might happen when a proper hit has been registered 
    Action OnHitboxHitAction;
    //consider splitting up rigidbody hitbox and entity hitbox data?
    Hitdata HitboxHitdata;
    
    private void Start()
    {
        gameObject.SetActive(false); //gameobject is not active by default
    }
    public void Activate(Hitdata MoveInputData,BoxRectStruct boxposition)
    {
        this.gameObject.transform.localPosition = new Vector2(boxposition.OffsetX, boxposition.OffsetY);
        this.gameObject.transform.localScale = new Vector2(boxposition.OffsetScaleX, boxposition.OffsetScaleY);
        HitboxHitdata = MoveInputData;
        this.gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        HitboxHitdata = null;
        this.gameObject.SetActive(false);
    }

    public void HitboxHit()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.GetComponent<CustomRigid>() && (HitboxHitdata != null))
        {
            if (OnHitboxHitAction != null)
                OnHitboxHitAction();
            collision.gameObject.GetComponent<CustomRigid>().ProcessHit(this.HitboxHitdata.SenderPosition, this.HitboxHitdata.rigidHitdata);
        }
    }

}
