using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//base class for all the FGBoxes of the game
public abstract class FGBoxClass : MonoBehaviour
{
    public Vector2 BoxTransform
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public virtual void ActivateBox()
    {

    }

    public virtual void DeactivateBox()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void OnBoxHit();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
