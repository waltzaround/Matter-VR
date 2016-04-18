using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisAnimationStatePropertyModifier))]
public class VisAnimationStatePropertyModifierEditor : VisBasePropertyModifierEditor 
{
    public VisAnimationStatePropertyModifierEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisAnimationStatePropertyModifier modifier = target as VisAnimationStatePropertyModifier;
        if (modifier == null)
            return;

        modifier.targetProperty = (AnimationStateProperty)EditorGUILayout.EnumPopup("\tTarget Property", (Enum)modifier.targetProperty);
        modifier.targetAnimation = EditorGUILayout.TextField("\tTarget Animation", modifier.targetAnimation);
    }
}