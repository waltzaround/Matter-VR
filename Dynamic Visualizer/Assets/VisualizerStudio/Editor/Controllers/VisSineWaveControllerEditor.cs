using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(VisSineWaveController))]
public class VisSineWaveControllerEditor : VisBaseControllerEditor
{
    public VisSineWaveControllerEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    /// <summary>
    /// This function is called by the base editor to display normal custom inspector gui.
    /// </summary>
    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisSineWaveController controller = target as VisSineWaveController;
        if (controller == null)
            return;

        controller.speedScalar = EditorGUILayout.FloatField("\tSpeed Scalar", controller.speedScalar);
    }
}