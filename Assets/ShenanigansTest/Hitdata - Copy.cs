using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*

private class HitdataBACKUP
{
    public int Damage { get; }
    public DirectionEnum sourcedirection{get;}
    //sending attack's base combo time
    public float ComboTime { get; }
    public Vector2 LaunchVelocity
    {
        get;
    }
    public Vector2 SecondaryLaunch { get; }//velocity mainly referring to the bounce velocity on wallbounce, bounce, and whole other crap
    public float Hitcooldown { get; }
    public HitAttribute StandingAttribute { get; } //attribute on standing hit
    public HitAttribute JuggleAttribute { get; } //attribute when target is juggled

    /// <summary>
    /// /
    /// </summary>
    /// <param name="damage">how much health damage the move does</param>
    /// <param name="combotime">how long is the combotimer applied by the move</param>
    /// <param name="velocity">launch/displacement/knockback velocity of the move</param>
    /// <param name="standingAttribute"></param>
    /// <param name="juggleAttribute"></param>
    Hitdata(int damage, int combotime, Vector2 velocity,HitAttribute standingAttribute,HitAttribute juggleAttribute)
    {
        Damage = damage;
        ComboTime = combotime;
        LaunchVelocity = velocity;
        StandingAttribute = standingAttribute;
        JuggleAttribute = juggleAttribute;
        SecondaryLaunch = new Vector2(5, 10);
    }


    public Hitdata(int damage, int combotime, Vector2 velocity, HitAttribute universalAttribute) //for plain just knockdown juggle
    {
        Damage = damage;
        ComboTime = combotime;
        LaunchVelocity = velocity;
        StandingAttribute = universalAttribute;
        JuggleAttribute = universalAttribute;
        SecondaryLaunch = new Vector2(5, 10);

    }

}

//data about the source entity (the player/enemy)
public class SourceEntityData{
    public int HealthDamage;
}
//data about the move that's applied. 
public class MoveHitData
{
    public float ComboTime { get; }
    public HitAttribute MoveHitAttribute { get; }
    public Vector2 LaunchVelocity { get; }
    public MoveHitData(float comboTime, HitAttribute moveAttribute, Vector2 launchvelocity)
    {
        ComboTime = comboTime;
        MoveHitAttribute = moveAttribute;
        LaunchVelocity = launchvelocity;

    }
}

public enum DirectionEnum
{ 
Left, Right
}
*/
