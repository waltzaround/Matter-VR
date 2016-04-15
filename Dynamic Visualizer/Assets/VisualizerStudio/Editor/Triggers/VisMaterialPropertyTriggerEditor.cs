using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(VisMaterialPropertyTrigger))]
public class VisMaterialPropertyTriggerEditor : VisBasePropertyTriggerEditor 
{
    public VisMaterialPropertyTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisMaterialPropertyTrigger trigger = target as VisMaterialPropertyTrigger;
        if (trigger == null)
            return;

        trigger.targetProperty = EditorGUILayout.TextField("\tTarget Property", trigger.targetProperty);
        trigger.setAsProceduralMaterial = EditorGUILayout.Toggle("\tSet as Procedural Material", trigger.setAsProceduralMaterial);
        if (trigger.setAsProceduralMaterial)
            trigger.rebuildProceduralTexturesImmediately = EditorGUILayout.Toggle("\t\tRebuild Immediately", trigger.rebuildProceduralTexturesImmediately);
        trigger.applyToMaterialIndex = EditorGUILayout.Toggle("\tApply to Material Index", trigger.applyToMaterialIndex);
        if (trigger.applyToMaterialIndex)
            trigger.materialIndex = EditorGUILayout.IntField("\t\tIndex", trigger.materialIndex);
    }
}