using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BodyController : MonoBehaviour
{
    Rigidbody2D rbody;
    MovementStats Stats;
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();

    }
    public void Build(MovementStats stats)
    {
        Stats = stats;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Move(float Horizontal)
    {

        if (Horizontal >= 1 || Horizontal <= -1)
            rbody.velocity = new Vector2(Stats.MoveSpeed * Horizontal, rbody.velocity.y);
        else
            rbody.velocity = new Vector2(0, rbody.velocity.y);
    }
    public void Jump()
    {
        rbody.AddForce(new Vector2(rbody.velocity.x, Stats.JumpForce), ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
[System.Serializable]
public class MovementStats
{
    public int MoveSpeed;
    public int BackSpeed;
    public int JumpForce;
    public int Acceleration;
    //LightspeedData lightspeedData;
}

class LightspeedData
{
    int StartupDuration;
    int StartupAction;
    int Distance;
    int EndDeceleration;
    int EndSpeed;
    int DecelerationDistance;

}
enum MovementType
{
    normal, dash, lightspeed, acceleration
}
