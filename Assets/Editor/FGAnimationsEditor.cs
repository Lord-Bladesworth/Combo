using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
//[CustomEditor(typeof(FGAnimationData))]
public class FGAnimationsEditor :Editor
{

    public override void OnInspectorGUI()
    {
        Debug.Log(target.GetType());
    }

}
