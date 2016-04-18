using System;
using UnityEngine;

/// <summary>
/// This trigger is used to lerp between two materials 
/// as a reaction to changes in the music.
/// </summary>
[AddComponentMenu("Visualizer Studio/Triggers/Material Lerp Trigger")]
public class VisMaterialLerpTrigger : VisBasePropertyTrigger
{
    #region Defaults Static Class
	
	/// <summary>
    /// This internal class holds all of the defaults of the VisMaterialLerpTrigger class. 
	/// </summary>
	public static new class Defaults
	{	
	}
	
	#endregion
	
	#region Public Member Variables
	
	/// <summary>
	/// This is the material to lerp from. 
	/// </summary>
    //[HideInInspector()]
	public Material lerpFromMaterial = null;
	
	/// <summary>
	/// This is the material to lerp to. 
    /// </summary>
    //[HideInInspector()]
	public Material lerpToMaterial = null;
	
	#endregion
	
	#region Init/Deinit Functions
	
	/// <summary>
	/// This is callled when this commponent is reset. 
	/// </summary>
	public override void Reset()
	{
		base.Reset();
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
		if (GetComponent<Renderer>() != null &&
		    GetComponent<Renderer>().material != null &&
		    lerpFromMaterial != null &&
		    lerpToMaterial != null)
		{
			GetComponent<Renderer>().material.Lerp(lerpFromMaterial, lerpToMaterial, Mathf.Clamp(propertyValue, 0.0f, 1.0f));
		}
    }

    #endregion
}

