using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
    Hitbox[] hitBoxes;

    void InitializeHitboxes(int HitboxCount)
    {
            hitBoxes = new Hitbox[HitboxCount];
            GameObject DummyHitbox;
            GameObject DummyParentBox;
            DummyParentBox = new GameObject("Hitboxes");
            for (int i = 0; i < HitboxCount; i++)
            {
                DummyHitbox = new GameObject("Hitbox_" + i, typeof(Hitbox), typeof(BoxCollider2D), typeof(SpriteRenderer));
                DummyHitbox.transform.parent = this.transform;
              //  DummyHitbox.GetComponent<SpriteRenderer>().sprite = blanktexture;
                DummyHitbox.GetComponent<SpriteRenderer>().color = Color.red;
                DummyHitbox.GetComponent<BoxCollider2D>().isTrigger = true;
                DummyHitbox.layer = 2;
                hitBoxes[i] = DummyHitbox.GetComponent<Hitbox>();
            }
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*
//stores shit along such as framedata
public class CharacterData
{

    Dictionary<string, Framedata> frameData;

    public void BuildCharacterData()
    {

    }

}
*/
public class HitboxAnimationData
{
    Hitdata[] hitData;

    Hitdata PlayHitData(int playbackTime)
    {
        return hitData[playbackTime];
        return null;
    }

}
public class Framedata
{
    HitboxData hitboxData;
    FGAnimationStateData frameAnimData;

}


