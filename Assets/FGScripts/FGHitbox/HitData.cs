using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO turn into structures
//Umbrella Data stored by hitboxes and sent when it hits an object
public class Hitdata
{
    public SourceEntityData EntityData { get; }
    public RigidHitData rigidHitdata { get; }
    public MoveHitData MoveInputData { get; }
    public Vector2 SenderPosition { get; }

    public int HitCooldown;
    public float SenderPositionX { get { return SenderPosition.x; } }
    public float SenderPositionY { get { return SenderPosition.y; } }
   

    public Hitdata(Vector2 sourcePosition,SourceEntityData entityData,RigidHitData rigidData,MoveHitData moveHitData)
    {
        SenderPosition = sourcePosition;
        EntityData = entityData;
        rigidHitdata = rigidData;
        MoveInputData = moveHitData;
    }

}

//data about the source entity (the player/enemy), still don't know what the fuck is this for
public class SourceEntityData{
    public int HealthDamage; //basically what's needed for now
}

//Data that is to be processed by the CustomRigid Component
[System.Serializable]
public class RigidHitData
{
    public Vector2 LaunchVelocity { get; }
    public Vector2 BounceVelocity { get; }
    public enumRigidInteraction rigidInteractionType { get; }
    public enumRigidTarget rigidTarget{get;}
    public int BounceCount { get; }

    public RigidHitData(Vector2 launchVel, Vector2 bounceVel, enumRigidInteraction interactionType, enumRigidTarget target, int bounces =0)
    {
        LaunchVelocity = launchVel;
        BounceVelocity = bounceVel;
        rigidInteractionType = interactionType;
        rigidTarget = target;
        BounceCount = bounces;
    }
    public RigidHitData(Vector2 launchVel, Vector2 bounceVel)
    {
        LaunchVelocity = launchVel;
        BounceVelocity = bounceVel;
        rigidInteractionType = enumRigidInteraction.none;
        rigidTarget = enumRigidTarget.none;
        BounceCount = 0;
    }
}

//
public class MoveHitData
{
  
}

