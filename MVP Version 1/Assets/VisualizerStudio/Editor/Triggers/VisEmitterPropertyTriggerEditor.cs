using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisEmitterPropertyTrigger))]
public class VisEmitterPropertyTriggerEditor : VisBasePropertyTriggerEditor 
{
    public VisEmitterPropertyTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisEmitterPropertyTrigger trigger = target as VisEmitterPropertyTrigger;
        if (trigger == null)
            return;

        trigger.targetProperty = (EmitterProperty)EditorGUILayout.EnumPopup("\tTarget Property", (Enum)trigger.targetProperty);
    }
}