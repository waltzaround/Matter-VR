using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

/// <summary>
/// This class is used as the base editor for all custom property modifier editors.
/// </summary>
[CustomEditor(typeof(VisBasePropertyTrigger))]
public class VisBasePropertyTriggerEditor : VisBaseTriggerEditor
{
    private enum PropertyValueType
    {
        NormalRange,
        InvertedRange,
        RandomRange,
    };

    /// <summary>
    /// This function is called by the base editor to display normal custom inspector gui.
    /// </summary>
    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisBasePropertyTrigger trigger = target as VisBasePropertyTrigger;
        if (trigger == null)
            return;

        trigger.controllerSourceValue = (ControllerSourceValue)EditorGUILayout.EnumPopup("\tController Source Value", (Enum)trigger.controllerSourceValue);

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
        trigger.minPropertyValue = EditorGUILayout.FloatField("\t\tMin Property Value", trigger.minPropertyValue);
        trigger.maxPropertyValue = EditorGUILayout.FloatField("\t\tMax Property Value", trigger.maxPropertyValue);

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

        trigger.limitIncreaseRate = EditorGUILayout.Toggle("\tLimit Increase Rate", trigger.limitIncreaseRate);
        if (trigger.limitIncreaseRate)
            trigger.increaseRate = EditorGUILayout.FloatField("\t\tIncrease Rate", trigger.increaseRate);
        trigger.limitDecreaseRate = EditorGUILayout.Toggle("\tLimit Decrease Rate", trigger.limitDecreaseRate);
        if (trigger.limitDecreaseRate)
            trigger.decreaseRate = EditorGUILayout.FloatField("\t\tDecrease Rate", trigger.decreaseRate);

        trigger.returnToRest = EditorGUILayout.Toggle("\tReturn to Rest", trigger.returnToRest);
        if (trigger.returnToRest)
            trigger.restValue = EditorGUILayout.FloatField("\t\tRest Value", trigger.restValue);
    }
}