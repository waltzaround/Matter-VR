using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This delegate is used to call into targeted game objects to notify the value has been updated. 
/// </summary>
public delegate void ValueUpdatedDelegate(float current, float previous, float difference, float adjustedDifference); 

/// <summary>
/// This modifier is used to target specific game objects, and to notify any 
/// components within that implement IVisModifierTarget.  
/// </summary>
[AddComponentMenu("Visualizer Studio/Modifiers/Target Modifier")]
public class VisTargetModifier : VisBaseModifier
{
	#region Public Member Variables
	
	/// <summary>
	/// This is the event to call when the targeted controller value has been updated. 
	/// </summary>
	public event ValueUpdatedDelegate ValueUpdated;
	
	/// <summary>
	/// This is the list of game objects that are currently targeted 
	/// by this modifier, and will be notified when the value has 
	/// changed. ONLY a component implementing IVisModifierTarget will
	/// be notified. 
	/// </summary>
    //[HideInInspector()]
	public List<GameObject> targetGameObjects = new List<GameObject>();
	
	#endregion
	
	#region Init/Deinit Function
	
	/// <summary>
	/// This is called when this script component is started. 
	/// </summary>
	public override void Start () 
	{	
		base.Start();
		CreateAllDelegates();
	}
	
	/// <summary>
	/// This is  called when this script component is destroyed. 
	/// </summary>
	public override void OnDestroy()
	{
		base.OnDestroy();
		DestroyAllDelegates();
	}	
	
	#endregion
	
	#region Game Object Target Functions
	
	/// <summary>
	/// This creates all of the delegates for all current target game objects. 
	/// </summary>
	public void CreateAllDelegates()
	{
		//loop through all game objects and add delegates
		for (int i = 0; i < targetGameObjects.Count; i++)
		{
			//make sure this game object is not null
			if (targetGameObjects[i] != null)
			{
				//get all MonoBehavior components on this target game object
				MonoBehaviour[] behaviours = targetGameObjects[i].GetComponents<MonoBehaviour>();
				for (int j = 0; j < behaviours.Length; j++)
				{
					//make sure the found behavior is not this behavior, and it is a IVisModifierTarget
					if (behaviours[j] != this && behaviours[j] is IVisModifierTarget)
					{
						//get the modifier target and add to the ValueUpdate event
						IVisModifierTarget modifierTarget = behaviours[j] as IVisModifierTarget;
						if (modifierTarget != null)
							ValueUpdated += modifierTarget.OnValueUpdated;
					}
				}
			}
		}
	}
	
	/// <summary>
	/// This destroys all of the delegates for all current target game objects. 
	/// </summary>
	public void DestroyAllDelegates()
	{		
		//loop through all game objects and remove delegates
		for (int i = 0; i < targetGameObjects.Count; i++)
		{
			//make sure this game object is not null
			if (targetGameObjects[i] != null)
			{
				//get all MonoBehavior components on this target game object
				MonoBehaviour[] behaviours = targetGameObjects[i].GetComponents<MonoBehaviour>();
				for (int j = 0; j < behaviours.Length; j++)
				{
					//make sure the found behavior is not this behavior, and it is a IVisModifierTarget
					if (behaviours[j] != this && behaviours[j] is IVisModifierTarget)
					{
						//get the modifier target and remove from the ValueUpdate event
						IVisModifierTarget modifierTarget = behaviours[j] as IVisModifierTarget;
						if (modifierTarget != null)
							ValueUpdated -= modifierTarget.OnValueUpdated;
					}
				}
			}
		}
	}
	
	/// <summary>
	/// This adds a new target game object. 
	/// </summary>
	/// <param name="gameObject">
	/// The game object to target.
	/// </param>
	public void AddGameObject(GameObject gameObject)
	{
		//make sure this game object is not null and is not already in the list
		if (gameObject != null && targetGameObjects.Contains(gameObject) == false)
		{
			//warn if the game object being added is the parent of this component
			if (gameObject == this)
			{
				Debug.LogWarning("You are adding a game object to a modifier that is the parent of this modifier.  This may have unexpected results.");
			}
			
			//add the game object			
			targetGameObjects.Add(gameObject);
			
			//get all MonoBehavior components on this target game object
			MonoBehaviour[] behaviours = gameObject.GetComponents<MonoBehaviour>();
			for (int j = 0; j < behaviours.Length; j++)
			{
				//make sure the found behavior is not this behavior, and it is a IVisModifierTarget
				if (behaviours[j] != this && behaviours[j] is IVisModifierTarget)
				{
					//get the modifier target and add to the ValueUpdate event
					IVisModifierTarget modifierTarget = behaviours[j] as IVisModifierTarget;
					if (modifierTarget != null)
						ValueUpdated += modifierTarget.OnValueUpdated;
				}
			}
		}
	}
	
	/// <summary>
	/// This removes a target game object. 
	/// </summary>
	/// <param name="gameObject">
	/// The game object to remove.
	/// </param>
	public void RemoveGameObject(GameObject gameObject)
	{
		//make sure this game object is not null and is already in the list
		if (gameObject != null && targetGameObjects.Contains(gameObject) == true)
		{
			//remove the game object			
			targetGameObjects.Remove(gameObject);
			
			//get all MonoBehavior components on this target game object
			MonoBehaviour[] behaviours = gameObject.GetComponents<MonoBehaviour>();
			for (int j = 0; j < behaviours.Length; j++)
			{
				//make sure the found behavior is not this behavior, and it is a IVisModifierTarget
				if (behaviours[j] != this && behaviours[j] is IVisModifierTarget)
				{
					//get the modifier target and add to the ValueUpdate event
					IVisModifierTarget modifierTarget = behaviours[j] as IVisModifierTarget;
					if (modifierTarget != null)
						ValueUpdated -= modifierTarget.OnValueUpdated;
				}
			}
		}
	}
	
	#endregion
	
	#region VisBaseModifier Implementation
	
	/// <summary>
	/// This function is called by the base modifier whenever 
	/// the value of the targeted controller is updated.
	/// </summary>
	/// <param name="current">
	/// The current value of the targeted controller.
	/// </param>
	/// <param name="previous">
	/// The previous value of the targeted controller.
	/// </param>
	/// <param name="difference">
	/// The value difference of the targeted controller.
    /// </param>
    /// <param name="adjustedDifference">
    /// The adjusted value difference of the targeted controller.
    /// This value is the difference value as if it took place over a 
    /// certain time period, controlled by VisBaseController.mc_fTargetAdjustedDifferenceTime.  The 
    /// default of this essientially indicates a frame rate of 60 fps to determine 
    /// the adjusted difference.  This should be used for almost all difference 
    /// calculations, as it is NOT frame rate dependent.
    /// </param>
	public override void OnValueUpdated(float current, float previous, float difference, float adjustedDifference) 
	{
		//call the event if it is not null
		if (ValueUpdated != null)
			ValueUpdated(Controller.GetCurrentValue(),
		                 Controller.GetPreviousValue(),
		                 Controller.GetValueDifference(),
		                 Controller.GetAdjustedValueDifference());
	}
	
	#endregion
}


