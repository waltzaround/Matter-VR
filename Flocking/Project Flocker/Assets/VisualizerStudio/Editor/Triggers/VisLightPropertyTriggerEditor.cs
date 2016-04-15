using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisLightPropertyTrigger))]
public class VisLightPropertyTriggerEditor : VisBasePropertyTriggerEditor 
{
    public VisLightPropertyTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisLightPropertyTrigger trigger = target as VisLightPropertyTrigger;
        if (trigger == null)
            return;

        trigger.targetProperty = (LightProperty)EditorGUILayout.EnumPopup("\tTarget Property", (Enum)trigger.targetProperty);
    }
}