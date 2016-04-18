using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(VisEmitParticlesTrigger))]
public class VisEmitParticlesTriggerEditor : VisBaseTriggerEditor 
{
    public VisEmitParticlesTriggerEditor()
    {
        showAutomaticInspectorGUI = false;
    }
}