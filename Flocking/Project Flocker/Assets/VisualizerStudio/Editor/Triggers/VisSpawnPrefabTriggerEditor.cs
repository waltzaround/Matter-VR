using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(VisSpawnPrefabTrigger))]
public class VisSpawnPrefabTriggerEditor : VisBaseTriggerEditor 
{
    public VisSpawnPrefabTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisSpawnPrefabTrigger trigger = target as VisSpawnPrefabTrigger;
        if (trigger == null)
            return;

        trigger.prefab = (GameObject)EditorGUILayout.ObjectField("\tPrefab", trigger.prefab, typeof(GameObject), false);
        EditorGUIUtility.LookLikeControls();
        trigger.randomOffset = EditorGUILayout.Vector3Field("\tRandom Offset", trigger.randomOffset);
        EditorGUIUtility.LookLikeInspector();
    }
}