using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Myextensions;

//TODO Possible Reuse of Direction to Angle Algorithm for Yum.io clone

[RequireComponent(typeof(Rigidbody2D))]
public class CustomRigid : MonoBehaviour
{
    Rigidbody2D body;
    int Combotime;
    int BounceCount = 0;
    RigidHitData rigidHitData;
    Vector2 senderLocation;
    Vector2 LaunchVelocity;
    bool OnHitCooldown;

    RigidState CurrentRigidState;
    private enum RigidState
    {
        //Active: can be launched, Inactive can no longer trigger colliderlaunch events (on wall hit and shit)
        Standby,Active, Inactive
    }
    //state cycle: standby>active>active *n> inactive > standby
    private void Awake()
    {
        if (GetComponent<Rigidbody2D>() == null)
            gameObject.AddComponent<Rigidbody2D>();
        body = GetComponent<Rigidbody2D>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentRigidState = RigidState.Standby;
        Combotime = 0;
    }
    public void ForcedReset()
    {
        //force rigidbody to reset to nohitmode
    }
    //TODO getting rid of acceleration interpolation
    //TODO juggle hit and neutral standing hit seperation
    public void ProcessHit(Vector2 SenderLocation,RigidHitData Receievedhitdata)
    {
        rigidHitData= Receievedhitdata;
        senderLocation = SenderLocation;
        BounceCount = rigidHitData.BounceCount;
        LaunchVelocity = new Vector3(rigidHitData.LaunchVelocity.x.ScalarVectApply(ProcessScalarDirection(senderLocation)), rigidHitData.LaunchVelocity.y);
      //  Debug.Log(LaunchVelocity);
        body.velocity = LaunchVelocity;
        if (rigidHitData.rigidInteractionType != enumRigidInteraction.none)
            CurrentRigidState = RigidState.Active;
    }

    //takes the sender's location then converts scalar value(being the force) into a relative direction (direction on which the rigidbody should be moved)
    public float ProcessScalarDirection(Vector2 senderlocation)
    {
        if (this.gameObject.transform.position.x >= senderLocation.x)
        {
            return 1; //velocity direction going from the left
        }
            return -1; //velocity direction coming from the right
    }
    //tracks the num
    public void ComboTracker()
    {
       // if(body.velocity)
            //no hitstun decay, design decision: COMBO AS LONG AS YOU WANT
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CurrentRigidState == RigidState.Active)
            ContactEvent(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CurrentRigidState == RigidState.Active)
            ContactEvent(collision);
    }

    /*
    //to be replaced once hitbox system is fully clarified
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CurrentRigidState == RigidState.Active)
        ContactEvent(collision);
    }
  


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (CurrentRigidState == RigidState.Active)
            ContactEvent(collision);
    }
   private void OnCollisionExit2D(Collision2D collision)
    {

    }

    */
    //test whether or not this algorithm holds up to requirements
    private void ContactEvent(Collision2D collision)
    {
     
        //override when rigidbody hits the corner provided by the camera. ponder an approach regarding this issue later
        if (collision.collider.tag == "CameraCorner")
        {
            body.velocity = new Vector2((LaunchVelocity.x.RaisedtoZero() * -1) * 10, 8); //launch at a fixed velocity
            return;
        }
        //oh yes... here comes the issue    
        switch (rigidHitData.rigidInteractionType)
        {
            case enumRigidInteraction.bounce:
                if (collision.collider.tag == "Floor" && (rigidHitData.rigidTarget == enumRigidTarget.floor || rigidHitData.rigidTarget == enumRigidTarget.omni))
                {
                    body.velocity = new Vector2(rigidHitData.BounceVelocity.x.ScalarVectApply(LaunchVelocity.x), rigidHitData.BounceVelocity.y);
                    CurrentRigidState = RigidState.Inactive;
                    Debug.Log("Bounce");
                }
                else if (collision.collider.tag == "Corner" &&(rigidHitData.LaunchVelocity.x>0) && (rigidHitData.rigidTarget == enumRigidTarget.wall || rigidHitData.rigidTarget == enumRigidTarget.omni))
                {
                  //  body.velocity = new Vector2(rigidHitData.BounceVelocity.x.ScalarVectApply(LaunchVelocity.x *-1),LaunchVelocity.y);
                    body.velocity = new Vector2((LaunchVelocity.x.RaisedtoZero()*-1) * rigidHitData.BounceVelocity.x, rigidHitData.BounceVelocity.y);
                    CurrentRigidState = RigidState.Inactive;
                    Debug.Log("Bounce");
                }
                break;
            case enumRigidInteraction.splat:
                StartCoroutine("HoldPosition", 12);
                CurrentRigidState = RigidState.Inactive;
                break;
            case enumRigidInteraction.slide:
                break;
        }
        

    }
    //used by OnCollisionEnter
    private void ContactEvent(Collider2D collision)
    {

        //override when rigidbody hits the corner provided by the camera. ponder an approach regarding this issue later
        if (collision.tag == "CameraCorner")
        {
            body.velocity = new Vector2((LaunchVelocity.x.RaisedtoZero() * -1) * 10, 8); //launch at a fixed velocity
            return;
        }
        //oh yes... here comes the issue    
        switch (rigidHitData.rigidInteractionType)
        {
            case enumRigidInteraction.bounce:
                if (collision.tag == "Floor" && (rigidHitData.rigidTarget == enumRigidTarget.floor || rigidHitData.rigidTarget == enumRigidTarget.omni))
                {
                    body.velocity = new Vector2(rigidHitData.BounceVelocity.x.ScalarVectApply(LaunchVelocity.x), rigidHitData.BounceVelocity.y);
                    CurrentRigidState = RigidState.Inactive;
                    Debug.Log("Bounce");
                }
                else if (collision.tag == "Corner" && (rigidHitData.LaunchVelocity.x > 0) && (rigidHitData.rigidTarget == enumRigidTarget.wall || rigidHitData.rigidTarget == enumRigidTarget.omni))
                {
                    //  body.velocity = new Vector2(rigidHitData.BounceVelocity.x.ScalarVectApply(LaunchVelocity.x *-1),LaunchVelocity.y);
                    body.velocity = new Vector2((LaunchVelocity.x.RaisedtoZero() * -1) * rigidHitData.BounceVelocity.x, rigidHitData.BounceVelocity.y);
                    CurrentRigidState = RigidState.Inactive;
                    Debug.Log("Bounce");
                }
                break;
            case enumRigidInteraction.splat:
                StartCoroutine("HoldPosition", 12);
                CurrentRigidState = RigidState.Inactive;
                break;
            case enumRigidInteraction.slide:
                break;
        }


    }

    //THE holdposition coroutine
    private IEnumerator HoldPosition(int duration)
    {
        int count = duration;
        body.bodyType = RigidbodyType2D.Kinematic;
        while (count >0 || Combotime >0)
        {
            count--;
            yield return new WaitForEndOfFrame();
        }
        count = 0;
        body.bodyType = RigidbodyType2D.Dynamic;
        body.velocity = Vector2.left; //modify later when left/right orientation is figured out

    }
    private IEnumerator SlideAction()
    {
        return null;
    }

    //starts combo

}
public enum enumRigidInteraction
{
   none,bounce, slide, splat
}

//default is none
public enum enumRigidTarget
{
    floor, wall, omni, none
}
