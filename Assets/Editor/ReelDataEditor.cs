using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FGAnimations;
using System;
namespace FGAnimations.ReelEditor {
    [CustomPropertyDrawer(typeof(ReelData<System.Object>))]
    public class ReelDataEditor : Editor
    {
        ReelData<System.Object> SelectedReelData;
 
        private void Awake()
        {
            
        }
        void OnEnable()
        {
            Selection.selectionChanged += this.OnSelectionChange;

        }
        private void OnDisable()
        {
            Selection.selectionChanged -= this.OnSelectionChange;
           
        }
        void OnSelectionChange()
        {
           
        }
        public override void OnInspectorGUI()
        {
            //SelectedReelData = (ReelData<System.Object>)serializedObject.targetObject;
            base.OnInspectorGUI();
        }

    }
}
