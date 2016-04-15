using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisEmitterPropertyModifier))]
public class VisEmitterPropertyModifierEditor : VisBasePropertyModifierEditor 
{
    public VisEmitterPropertyModifierEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisEmitterPropertyModifier modifier = target as VisEmitterPropertyModifier;
        if (modifier == null)
            return;

        modifier.targetProperty = (EmitterProperty)EditorGUILayout.EnumPopup("\tTarget Property", (Enum)modifier.targetProperty);
    }
}