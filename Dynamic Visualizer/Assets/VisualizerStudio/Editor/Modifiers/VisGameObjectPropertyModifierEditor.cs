using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisGameObjectPropertyModifier))]
public class VisGameObjectPropertyModifierEditor : VisBasePropertyModifierEditor 
{
    public VisGameObjectPropertyModifierEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisGameObjectPropertyModifier modifier = target as VisGameObjectPropertyModifier;
        if (modifier == null)
            return;

        modifier.targetProperty = (GameObjectProperty)EditorGUILayout.EnumPopup("\tTarget Property", (Enum)modifier.targetProperty);
    }
}