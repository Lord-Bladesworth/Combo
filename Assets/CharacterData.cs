using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ragna;
[SerializeField]
[CreateAssetMenu(fileName = "CharacterData", menuName = "Ragna Prototype/ Character Data Prototype")]
public class CharacterData : ScriptableObject
{
    public string Alias;
    public MovementStats moveStats;
  //  public CharacterState[] CharacterStates;
    public List<CharacterState> CharacterStates;

    public void FinalizeData()
    {
        for(int x=0;x< CharacterStates.Count;x++)
        {
            CharacterStates[x].Build();
        }
    }
    public void SaveData()
    {

    }
    public void AddElement()
    {
        if(CharacterStates == null)
        {
            CharacterStates = new List<CharacterState>();
            CharacterStates.Add(CreateStateTEmplate());
            return;
        }
        CharacterStates.Add(CreateStateTEmplate());

    }  
    public void DeleteElement(CharacterState charstate)
    {
        CharacterStates.Remove(charstate);
    }
    public CharacterState CreateStateTEmplate()
    {
        CharacterState charState = new CharacterState();
        charState.StateName = "State " + (CharacterStates.Count).ToString();
        charState.Category = StateCategory.None;
        charState.StateKey = new DirectionalButton("0N");
        charState.HitRigidData = new RagnaRigidData() { Launch = Vector2.zero, Bounce = Vector2.zero, InteractionType = enumRigidInteraction.none, Target = enumRigidTarget.none};
        charState.AnimationData = new List<AnimCel>();
        return charState;
    }

}
