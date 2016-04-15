using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisTargetModifier))]
public class VisTargetModifierEditor : VisBaseModifierEditor 
{
    public VisTargetModifierEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisTargetModifier modifier = target as VisTargetModifier;
        if (modifier == null)
            return;

        int currentSize = modifier.targetGameObjects.Count;
        int newSize = Math.Abs(EditorGUILayout.IntField("\tNum Targets", currentSize));

        //remove excess or add new slots
        if (newSize == 0)
        {
            modifier.targetGameObjects.Clear();
        }
        else if (newSize < currentSize)
        {
            while (modifier.targetGameObjects.Count != newSize)
            {
                modifier.targetGameObjects.RemoveAt(modifier.targetGameObjects.Count - 1);
            }
        }
        else if (newSize > currentSize)
        {
            while (modifier.targetGameObjects.Count != newSize)
            {
                modifier.targetGameObjects.Add(null);
            }
        }

        //loop through all and edit
        for (int i = 0; i < modifier.targetGameObjects.Count; i++)
        {
            modifier.targetGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("\t\tTarget #" + (i + 1).ToString(), modifier.targetGameObjects[i], typeof(GameObject), true);
        }
    }
}