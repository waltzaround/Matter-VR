using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisGameObjectPropertyTrigger))]
public class VisGameObjectPropertyTriggerEditor : VisBasePropertyTriggerEditor 
{
    public VisGameObjectPropertyTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisGameObjectPropertyTrigger trigger = target as VisGameObjectPropertyTrigger;
        if (trigger == null)
            return;

        trigger.targetProperty = (GameObjectProperty)EditorGUILayout.EnumPopup("\tTarget Property", (Enum)trigger.targetProperty);
    }
}