using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.ObjectModel;
using System;

[CustomEditor(typeof(VisFrequencyController))]
public class VisFrequencyControllerEditor : VisBaseControllerEditor
{
    public VisFrequencyControllerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override bool TargetInspectorGUI()
	{
        return base.TargetInspectorGUI() && DisplayIVisDataGroupTargetGUI(target as IVisDataGroupTarget);
	}

    /// <summary>
    /// This function is called by the base editor to display normal custom inspector gui.
    /// </summary>
    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisFrequencyController controller = target as VisFrequencyController;
        if (controller == null)
            return;

        controller.subValueType = (VisDataValueType)EditorGUILayout.EnumPopup("\tSub Value Type", (Enum)controller.subValueType);
        controller.finalValueType = (VisDataValueType)EditorGUILayout.EnumPopup("\tFinal Value Type", (Enum)controller.finalValueType);
    }
} 