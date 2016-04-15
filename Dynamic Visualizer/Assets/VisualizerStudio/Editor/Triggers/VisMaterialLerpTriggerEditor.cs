using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(VisMaterialLerpTrigger))]
public class VisMaterialLerpTriggerEditor : VisBasePropertyTriggerEditor 
{
    public VisMaterialLerpTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisMaterialLerpTrigger trigger = target as VisMaterialLerpTrigger;
        if (trigger == null)
            return;

        trigger.lerpFromMaterial = (Material)EditorGUILayout.ObjectField("\tLerp from Material", trigger.lerpFromMaterial, typeof(Material), false);
        trigger.lerpToMaterial = (Material)EditorGUILayout.ObjectField("\tLerp to Material", trigger.lerpToMaterial, typeof(Material), false);
    }
}