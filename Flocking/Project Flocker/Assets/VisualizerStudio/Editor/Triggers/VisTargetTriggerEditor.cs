using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;

[CustomEditor(typeof(VisTargetTrigger))]
public class VisTargetTriggerEditor : VisBaseTriggerEditor 
{
    public VisTargetTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisTargetTrigger trigger = target as VisTargetTrigger;
        if (trigger == null)
            return;

        int currentSize = trigger.targetGameObjects.Count;
        int newSize = Math.Abs(EditorGUILayout.IntField("\tNum Targets", currentSize));

        //remove excess or add new slots
        if (newSize == 0)
        {
            trigger.targetGameObjects.Clear();
        }
        else if (newSize < currentSize)
        {
            while (trigger.targetGameObjects.Count != newSize)
            {
                trigger.targetGameObjects.RemoveAt(trigger.targetGameObjects.Count - 1);
            }
        }
        else if (newSize > currentSize)
        {
            while (trigger.targetGameObjects.Count != newSize)
            {
                trigger.targetGameObjects.Add(null);
            }
        }

        //loop through all and edit
        for (int i = 0; i < trigger.targetGameObjects.Count; i++)
        {
            trigger.targetGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("\t\tTarget #" + (i + 1).ToString(), trigger.targetGameObjects[i], typeof(GameObject), true);
        }
    }
}