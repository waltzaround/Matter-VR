using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisAddForceTrigger))]
public class VisAddForceTriggerEditor : VisBaseTriggerEditor
{
    private enum PropertyValueType
    {
        NormalRange,
        InvertedRange,
        RandomRange,
    };

    public VisAddForceTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    /// <summary>
    /// This function is called by the base editor to display normal custom inspector gui.
    /// </summary>
    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisAddForceTrigger trigger = target as VisAddForceTrigger;
        if (trigger == null)
            return;

        trigger.controllerValue = (ControllerSourceValue)EditorGUILayout.EnumPopup("\tController Source Value", (Enum)trigger.controllerValue);

        PropertyValueType rules = PropertyValueType.NormalRange;
        if (trigger.randomValue)
            rules = PropertyValueType.RandomRange;
        else if (trigger.invertValue)
            rules = PropertyValueType.InvertedRange;

        rules = (PropertyValueType)EditorGUILayout.EnumPopup("\tProperty Value Type", (Enum)rules);
        if (rules == PropertyValueType.NormalRange || rules == PropertyValueType.InvertedRange)
        {
            trigger.minControllerValue = EditorGUILayout.FloatField("\t\tMin Controller Value", trigger.minControllerValue);
            trigger.maxControllerValue = EditorGUILayout.FloatField("\t\tMax Controller Value", trigger.maxControllerValue);
        }
        trigger.minForceValue = EditorGUILayout.FloatField("\t\tMin Force Value", trigger.minForceValue);
        trigger.maxForceValue = EditorGUILayout.FloatField("\t\tMax Force Value", trigger.maxForceValue);

        if (rules == PropertyValueType.NormalRange)
        {
            trigger.invertValue = false;
            trigger.randomValue = false;
        }
        else if (rules == PropertyValueType.InvertedRange)
        {
            trigger.invertValue = true;
            trigger.randomValue = false;
        }
        else if (rules == PropertyValueType.RandomRange)
        {
            trigger.invertValue = false;
            trigger.randomValue = true;
        }

        trigger.forceMode = (ForceMode)EditorGUILayout.EnumPopup("\tForce Mode", (Enum)trigger.forceMode);
        EditorGUIUtility.LookLikeControls();
        trigger.forceDirection = EditorGUILayout.Vector3Field("\tForce Direction", trigger.forceDirection);
        EditorGUIUtility.LookLikeInspector();
    }
}