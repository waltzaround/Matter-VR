using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(VisRandomController))]
public class VisRandomControllerEditor : VisBaseControllerEditor
{
    public VisRandomControllerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    /// <summary>
    /// This function is called by the base editor to display normal custom inspector gui.
    /// </summary>
    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisRandomController controller = target as VisRandomController;
        if (controller == null)
            return;

        controller.delayTime = EditorGUILayout.FloatField("\tDelay Time", controller.delayTime);
    }
}