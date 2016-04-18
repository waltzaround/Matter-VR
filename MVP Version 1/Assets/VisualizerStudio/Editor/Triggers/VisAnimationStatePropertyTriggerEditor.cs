using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisAnimationStatePropertyTrigger))]
public class VisAnimationStatePropertyTriggerEditor : VisBasePropertyTriggerEditor 
{
    public VisAnimationStatePropertyTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisAnimationStatePropertyTrigger trigger = target as VisAnimationStatePropertyTrigger;
        if (trigger == null)
            return;

        trigger.targetProperty = (AnimationStateProperty)EditorGUILayout.EnumPopup("\tTarget Property", (Enum)trigger.targetProperty);
        trigger.targetAnimation = EditorGUILayout.TextField("\tTarget Animation", trigger.targetAnimation);
    }
}