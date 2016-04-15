using System;
using UnityEngine;

/// <summary>
/// This trigger is used to set an emitter property as a reaction
/// to changes in the music.
/// </summary>
[AddComponentMenu("Visualizer Studio/Triggers/Emitter Property Trigger")]
public class VisEmitterPropertyTrigger : VisBasePropertyTrigger 
{
	#region Defaults Static Class
	
	/// <summary>
    /// This internal class holds all of the defaults of the VisEmitterPropertyTrigger class. 
	/// </summary>
	public static new class Defaults
	{					
		public const EmitterProperty targetProperty = EmitterProperty.EmitterVelocityScale;
	}
	
	#endregion
	
	#region Public Member Variables
	
	/// <summary>
	/// This is the target property to modify on the parent game object. 
	/// As an example of how this works:
	/// minControllerValue = 0.2
	/// maxControllerValue = 0.8
	/// minPropertyValue = 2.0
	/// maxPropertyValue = 4.0
	/// invertValue = false
	/// 
	/// controllerInputValue = 0.5 -- newPropertyValue = 3.0
	/// controllerInputVlaue = 0.35 -- newPropertyValue = 2.5
    /// </summary>
    //[HideInInspector()]
	public EmitterProperty targetProperty = Defaults.targetProperty;
	
	#endregion

    #region VisBasePropertyTrigger Implementation

    /// <summary>
    /// This function is used to call into sub classes of
    /// VisBasePropertyTrigger, in order for them to set their
    /// target property to the new value specified.
    /// </summary>
    /// <param name="propertyValue">The new value to set the property to.</param>
    public override void SetProperty(float propertyValue)
    {
        VisPropertyHelper.SetEmitterProperty(GetComponent<ParticleEmitter>(), targetProperty, propertyValue);
    }

    #endregion
}