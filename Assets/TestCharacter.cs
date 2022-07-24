using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//TODO be able to play wall tennis
//TODO input feed for inputs
public class TestCharacter : MonoBehaviour
{
    HitboxMaster hitboxmanager;
    string horizonvaltext = "";
    MoveHitData[] moves = new MoveHitData[4];
    RigidHitData[] movesRigidData = new RigidHitData[4];
    Rigidbody2D testbody;
    BoxRectStruct selfRectPosition;
    float playerVelocity = 0;
    [SerializeField]
    float speedmodifier;
    [SerializeField]
    float JumpForce;
    // Start is called before the first frame update
    private void Awake()
    {
        if (GetComponent<Rigidbody2D>())
        {
            this.gameObject.AddComponent<Rigidbody2D>();
        }
    }
    void Start()
    {
        selfRectPosition = new BoxRectStruct(0, 0, 1.4f, 1.4f);
        testbody = GetComponent<Rigidbody2D>();
        hitboxmanager = GetComponent<HitboxMaster>();
        //5a
        movesRigidData[0] = new RigidHitData(Vector2.one*4, Vector2.zero, enumRigidInteraction.none, enumRigidTarget.none);
        //5b
        movesRigidData[1] = new RigidHitData(new Vector2(12,0), Vector2.zero, enumRigidInteraction.none, enumRigidTarget.none);
        //5c
        movesRigidData[2] = new RigidHitData(new Vector2(12,3), new Vector2(3,9), enumRigidInteraction.bounce, enumRigidTarget.wall);
        //3c
        movesRigidData[3] = new RigidHitData(Vector2.one, Vector2.zero, enumRigidInteraction.none, enumRigidTarget.floor);
    }

    // Update is called once per frame
    void Update()
    {
    

    }
    private void LateUpdate()
    {
        if (playerVelocity != 0)
        {
            testbody.velocity = new Vector2(playerVelocity, testbody.velocity.y);
        }
    }
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, (transform.localScale.y/2) +0.02f, 1);
       // Debug.DrawRay(transform.position,new Vector3(hit.point.x,hit.point.y,transform.position.z) - transform.position, Color.red, 1);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                playerVelocity = speedmodifier * context.ReadValue<Vector2>().x;
                break;
            case InputActionPhase.Canceled:
                testbody.velocity = testbody.velocity = new Vector2(0, testbody.velocity.y);
                playerVelocity = 0;
                break;
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Started && IsGrounded())
            testbody.AddForce(new Vector2(playerVelocity, JumpForce), ForceMode2D.Impulse);
    }

    public void AttackA(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            hitboxmanager.ActivateHitbox(new Hitdata(this.transform.position, new SourceEntityData(), movesRigidData[0], new MoveHitData()), 1, selfRectPosition, 6);
        }
    }
    public void AttackB(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            hitboxmanager.ActivateHitbox(new Hitdata(this.transform.position, new SourceEntityData(), movesRigidData[1], new MoveHitData()), 1, selfRectPosition, 6);
        }
    }
    public void AttackC(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            hitboxmanager.ActivateHitbox(new Hitdata(this.transform.position, new SourceEntityData(), movesRigidData[2], new MoveHitData()), 1, selfRectPosition, 6);
        }
    }
    float horizontalInput()
    {
        if (Input.GetAxis("Horizontal") < 0)
            return -1;
        if (Input.GetAxis("Horizontal") > 0)
            return 1;
        return 0;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(50, 50, 100, 50), "player speed: " + playerVelocity + "grounded " + IsGrounded());
    }
}