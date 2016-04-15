using System;
using UnityEngine;

/// <summary>
/// This trigger is used to set an animation state property as a reaction
/// to changes in the music.
/// </summary>
[AddComponentMenu("Visualizer Studio/Triggers/Animation State Property Trigger")]
public class VisAnimationStatePropertyTrigger : VisBasePropertyTrigger
{
	#region Defaults Static Class
	
	/// <summary>
    /// This internal class holds all of the defaults of the VisAnimationStatePropertyTrigger class. 
	/// </summary>
	public static new class Defaults
	{					
		public const AnimationStateProperty targetProperty = AnimationStateProperty.NormalizedTime;
		public const string targetAnimation = "Idle";
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
	public AnimationStateProperty targetProperty = Defaults.targetProperty;
	
	/// <summary>
	/// This is the target animation to set the animation state for. 
	/// This must be playing in order to modify its state. 
    /// </summary>
    //[HideInInspector()]
	public string targetAnimation = Defaults.targetAnimation;
	
	#endregion
	
	#region Init/Deinit Functions
	
	/// <summary>
	/// This is callled when this commponent is reset. 
	/// </summary>
	public override void Reset()
	{
		base.Reset();
			
		targetProperty = Defaults.targetProperty;	
		targetAnimation = Defaults.targetAnimation;
	}
	
	/// <summary>
	/// This is called when this component is started. 
	/// </summary>
	public override void Start() 
	{
		base.Start();		
	}
	
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
		if (GetComponent<Animation>() != null && GetComponent<Animation>().IsPlaying(targetAnimation))
		{
			VisPropertyHelper.SetAnimationStateProperty(GetComponent<Animation>()[targetAnimation], targetProperty, propertyValue);
		}
    }

    #endregion
}

