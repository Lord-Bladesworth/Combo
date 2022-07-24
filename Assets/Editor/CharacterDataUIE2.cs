using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Ragna;
public class CharacterDataUIE2 : EditorWindow
{
    CharacterData charData;
    int charStateIndex=0;

    private void OnSelectionChange()
    {
        /*
        if (Selection.activeObject == null)
            return;

        if(Selection.activeObject.GetType() == typeof(CharacterData))
        {
            if(charData== Selection.activeObject as CharacterData)
            {
                return;
            }
            charData = Selection.activeObject as CharacterData;
            charStateIndex = 0;
            Debug.Log("Character data has been successfully loaded");
        }
        */
    }

    [MenuItem("Test Editor/ Character Data Editor")] 
    public static void OpenWindow()
    {
        GetWindow<CharacterDataUIE2>("Character Editor");

    }
    public void OnGUI()
    {
        if (charData != null)
            DrawEditor();
    }

    void DrawEditor()
    {
     /*
        charData.Alias = EditorGUILayout.TextField("Character Alias", charData.Alias);
        if(charData.CharacterStates == null)
        {
            EditorGUILayout.LabelField("character states is currently Empty");
        }
        else
        PaintCharacterStates();
        if (GUILayout.Button("Add new Element"))
            charData.AddElement();
        EditorUtility.SetDirty(charData);
     */
    }

    void DrawStateData()
    {

    }
    void PaintCharacterStates()
    {
        charData.CharacterStates[charStateIndex].StateName = EditorGUILayout.TextField("State Name ", charData.CharacterStates[charStateIndex].StateName);



    }

}
