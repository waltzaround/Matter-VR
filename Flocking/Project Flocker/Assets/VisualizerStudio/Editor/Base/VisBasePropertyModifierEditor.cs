using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

/// <summary>
/// This class is used as the base editor for all custom property modifier editors.
/// </summary>
[CustomEditor(typeof(VisBasePropertyModifier))]
public class VisBasePropertyModifierEditor : VisBaseModifierEditor
{
    private enum PropertyValueType
    {
        NormalRange,
        InvertedRange
    };

    /// <summary>
    /// This function is called by the base editor to display normal custom inspector gui.
    /// </summary>
    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisBasePropertyModifier modifier = target as VisBasePropertyModifier;
        if (modifier == null)
            return;

        modifier.controllerSourceValue = (ControllerSourceValue)EditorGUILayout.EnumPopup("\tController Source Value", (Enum)modifier.controllerSourceValue);

        PropertyValueType rules = PropertyValueType.NormalRange;
        if (modifier.invertValue)
            rules = PropertyValueType.InvertedRange;

        rules = (PropertyValueType)EditorGUILayout.EnumPopup("\tProperty Value Type", (Enum)rules);
        if (rules == PropertyValueType.NormalRange || rules == PropertyValueType.InvertedRange)
        {
            modifier.minControllerValue = EditorGUILayout.FloatField("\t\tMin Controller Value", modifier.minControllerValue);
            modifier.maxControllerValue = EditorGUILayout.FloatField("\t\tMax Controller Value", modifier.maxControllerValue);
        }
        modifier.minPropertyValue = EditorGUILayout.FloatField("\t\tMin Property Value", modifier.minPropertyValue);
        modifier.maxPropertyValue = EditorGUILayout.FloatField("\t\tMax Property Value", modifier.maxPropertyValue);

        if (rules == PropertyValueType.NormalRange)
        {
            modifier.invertValue = false;
        }
        else if (rules == PropertyValueType.InvertedRange)
        {
            modifier.invertValue = true;
        }
    }
} 