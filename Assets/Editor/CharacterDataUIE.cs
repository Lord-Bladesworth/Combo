using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using Ragna;
using System;
[CustomEditor(typeof(CharacterData))]
public class CharacterDataUIE : Editor
{
    Sprite TestSprite;
    
    

    //TODO add an undo recorder for certain actions such as create, edit, or save
    CharacterData charData;
    int StateIndex=0;
    string ButtonString="";
    string TestString = "";
   // CharacterData charData;
    private void OnEnable()
    {
        
        /*
        CharacterData charData = (CharacterData)target;
        if(charData)
        {
            Debug.Log("Successful load of " + charData.CharacterName);
        }
        */ 
        //Selection.selectionChanged += SelectionChanged;


    }
    void SelectionChanged()
    {
     //  if(((CharacterData))
    }
   
  
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        charData = (CharacterData)serializedObject.targetObject;
        if (StateIndex > charData.CharacterStates.Count || StateIndex < 0)
            StateIndex = 0;
        charData.Alias = EditorGUILayout.TextField("Character Alias",charData.Alias);
        PaintMovementStats();
        PaintStateManipulationButtons();

        if (charData.CharacterStates == null || charData.CharacterStates.Count < 1)
        {
            EditorGUILayout.LabelField("Character states is currently empty, please add new elements");
            
        }
        if (charData.CharacterStates != null && charData.CharacterStates.Count > 0)
        {
            PaintCharacterStates(charData.CharacterStates[StateIndex]);
        }

        EditorUtility.SetDirty(charData);
        serializedObject.ApplyModifiedProperties();
    
    }

    void PaintMovementStats()
    {
        if(charData.moveStats == null)
        {
            charData.moveStats = new MovementStats() { Acceleration = 1, BackSpeed = 1, JumpForce = 1, MoveSpeed = 1 };
        }
        charData.moveStats.MoveSpeed = EditorGUILayout.IntField("Character speed",charData.moveStats.MoveSpeed);
    }

    void PaintStateManipulationButtons()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add new State"))
        {
            charData.AddElement();
            StateIndex = charData.CharacterStates.Count - 1;
            Debug.Log("New state created, list size is now " + charData.CharacterStates.Count);
        }
        if (GUILayout.Button("Delete State"))
        {
            //create a prompt first before executing the deletion for security
            charData.DeleteElement(charData.CharacterStates[StateIndex]);
            if (StateIndex > charData.CharacterStates.Count - 1)
                StateIndex = charData.CharacterStates.Count - 1;
        }
        EditorGUILayout.EndHorizontal();

    }
    void PaintCharacterStates(CharacterState charStates)
    {
        charStates.StateName= EditorGUILayout.TextField("State Name ", charStates.StateName);
        charStates.Category = (StateCategory)EditorGUILayout.EnumPopup("State Category", charStates.Category);
        if (charStates.Category != StateCategory.Movement)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Corresponding Input");
            charStates.StateKey.DirectionalPrefix = EditorGUILayout.IntPopup(charStates.StateKey.DirectionalPrefix, new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" }, new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            charStates.StateKey.Button = (ButtonEnum)EditorGUILayout.EnumPopup(charStates.StateKey.Button);
            EditorGUILayout.EndHorizontal();
        }
        /*
        if (!charData.CharacterStates[StateIndex].IsDefaultIdle)
        {
            charStates.StateKey = new DirectionalButton(EditorGUILayout.TextField("Corresponding Button", charData.CharacterStates[StateIndex].StateKey.ToString()));
           //paint expanding cancel to's
        }
        */
        PaintAnimator(charStates);
        PaintRigidHitData(charStates.HitRigidData);
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        PaintNavigationButtons();
    }

    //TODO open a preview window to preview the animation
    void PaintAnimator(CharacterState charstates)
    {
        Sprite sprite = null; 
        EditorGUILayout.BeginFoldoutHeaderGroup(true, "Animations");
        for(int x=0; x<charstates.AnimationData.Count;x++)
        {
            EditorGUILayout.BeginHorizontal();
           
            charstates.AnimationData[x].spr = EditorGUILayout.ObjectField(charstates.AnimationData[x].spr, typeof(Sprite),false) as Sprite;
            charstates.AnimationData[x].time = EditorGUILayout.IntField(charstates.AnimationData[x].time);
            if (GUILayout.Button("-"))
                charstates.AnimationData.Remove(charstates.AnimationData[x]);
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        sprite = EditorGUILayout.ObjectField(sprite, typeof(Sprite), false) as Sprite;
        if(sprite != null)
        {
            charstates.AnimationData.Add(new AnimCel() { spr = sprite, time = charstates.AnimationData.Count });
        }

        EditorGUILayout.EndFoldoutHeaderGroup();
    }
    void PaintNavigationButtons()
    {
        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Previous Element"))
        {
            if (StateIndex > 0)
                StateIndex--;
        }
        if(GUILayout.Button("Next Element"))
        {
            if (StateIndex < charData.CharacterStates.Count - 1)
                StateIndex++;
        }
        EditorGUILayout.EndHorizontal();
    }
    void PaintRigidHitData(RagnaRigidData rigidData)
    {
        EditorGUILayout.Foldout(true, "Rigid Data");
        rigidData.Launch = EditorGUILayout.Vector2Field("Launch Velocity", rigidData.Launch);
        rigidData.Bounce = EditorGUILayout.Vector2Field("Bounce Velocity", rigidData.Bounce);
        rigidData.InteractionType = (enumRigidInteraction)EditorGUILayout.EnumPopup("Interaction Type", rigidData.InteractionType);
        if (!((rigidData.InteractionType == enumRigidInteraction.none) || (rigidData.InteractionType == enumRigidInteraction.splat)))
        {
            rigidData.Target = (enumRigidTarget)EditorGUILayout.EnumPopup("Bounce Target", rigidData.Target);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }
    void TestButton()
    {
       TestString = EditorGUILayout.TextField("Directional Button",TestString);
       if( GUILayout.Button("directionalbutton create"))
        {
            DirectionalButton button = new DirectionalButton(TestString);
            
        }
    }
}
