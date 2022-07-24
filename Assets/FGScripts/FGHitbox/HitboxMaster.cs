using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//script that manages the hitbox of the gameobject
public class HitboxMaster : MonoBehaviour
{
    [SerializeField]
    Hitbox[] hitboxes;
    [SerializeField]
    Sprite blanktexture;
   
    // Start is called before the first frame update
    void Awake()
    {
        /*
        if (GetComponent<AgentEntity>())
        {
            Debug.Log("Parent with Agent Entity Detected");
            InitiateHitboxes(7);
            return; 
        }
        Debug.Log("No parent detected");
        InitiateHitboxes(5);
    */
    }

    public void InitiateHitboxes(int Count)
    {
        hitboxes = new Hitbox[Count];
        GameObject DummyHitbox;
        GameObject DummyParentBox;
        DummyParentBox = new GameObject("Hitboxes");
        DummyParentBox.transform.parent = this.transform;
        for (int i = 0; i < hitboxes.Length; i++)
        {
            DummyHitbox = new GameObject("Hitbox_" + i, typeof(Hitbox), typeof(BoxCollider2D), typeof(SpriteRenderer));
            DummyHitbox.transform.parent = DummyParentBox.transform;
            DummyHitbox.GetComponent<SpriteRenderer>().sprite = blanktexture;
            DummyHitbox.GetComponent<SpriteRenderer>().color = Color.red;
            DummyHitbox.GetComponent<BoxCollider2D>().isTrigger = true;
            DummyHitbox.layer = 2;
            hitboxes[i] = DummyHitbox.GetComponent<Hitbox>();
        }
    }
    void InitiateHurtBoxes()
    {

    }

    //Hitbox Attack
    public void ActivateHitbox(Hitdata data,int boxes, BoxRectStruct Hitboxposition,int duration)
    {
        for(int x=0;x<boxes &&x<hitboxes.Length;x++)
        {
            hitboxes[x].Activate(data, Hitboxposition);
        }
        StartCoroutine("expirytime", duration);
    }

    //temporary measure, timeline system will be made for later once pre-prototype testing is done
    IEnumerator expirytime(int duration)
    {
        for (int t = 0; t < duration; t++) {
            yield return new WaitForEndOfFrame();
        }
        for (int i=0;i<hitboxes.Length;i++)
        {
            hitboxes[i].DeActivate();
        }
    }
    /*
    public void ActivateHitboxes(List<BoxRectData> hitboxes,int Duration)
    {
    }*/

}


