using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This delegate is used to call into targeted game objects to notify a trigger has been triggered. 
/// </summary>
public delegate void TriggeredDelegate(float current, float previous, float difference, float adjustedDifference); 

/// <summary>
/// This trigger is used to target specific game objects, and to notify any 
/// components within that implement IVisTriggerTarget.  
/// </summary>
[AddComponentMenu("Visualizer Studio/Triggers/Target Trigger")]
public class VisTargetTrigger : VisBaseTrigger
{
	#region Public Member Variables
	
	/// <summary>
	/// This is the event to call when the this trigger has been triggered. 
	/// </summary>
	public event TriggeredDelegate Triggered;
	
	/// <summary>
	/// This is the list of game objects that are currently targeted 
	/// by this trigger, and will be notified when the trigger has 
	/// been triggered. ONLY a component implementing IVisTriggerTarget 
	/// will be notified. 
    /// </summary>
    //[HideInInspector()]
	public List<GameObject> targetGameObjects = new List<GameObject>();
	
	#endregion
	
	#region Init/Deinit Functions
	
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
	
	#region Update Functions
	
	/// <summary>
	/// This is the main update function.  THE BASE CLASS UPDATE MUST BE CALLED! 
	/// </summary>
	public override void Update ()
	{
		base.Update ();
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
					//make sure the found behavior is not this behavior, and it is a IVisTriggerTarget
					if (behaviours[j] != this && behaviours[j] is IVisTriggerTarget)
					{
						//get the modifier target and add to the Triggered event
						IVisTriggerTarget triggerTarget = behaviours[j] as IVisTriggerTarget;
						if (triggerTarget != null)
							Triggered += triggerTarget.OnTriggered;
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
					//make sure the found behavior is not this behavior, and it is a IVisTriggerTarget
					if (behaviours[j] != this && behaviours[j] is IVisTriggerTarget)
					{
						//get the modifier target and remove from the Triggered event
						IVisTriggerTarget triggerTarget = behaviours[j] as IVisTriggerTarget;
						if (triggerTarget != null)
							Triggered -= triggerTarget.OnTriggered;
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
				//make sure the found behavior is not this behavior, and it is a IVisTriggerTarget
				if (behaviours[j] != this && behaviours[j] is IVisTriggerTarget)
				{
					//get the modifier target and add to the Triggered event
					IVisTriggerTarget triggerTarget = behaviours[j] as IVisTriggerTarget;
					if (triggerTarget != null)
						Triggered += triggerTarget.OnTriggered;
				}
			}
		}
	}
	
	/// <summary>
	/// This remove a new target game object. 
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
				//make sure the found behavior is not this behavior, and it is a IVisTriggerTarget
				if (behaviours[j] != this && behaviours[j] is IVisTriggerTarget)
				{
					//get the modifier target and remove from the Triggered event
					IVisTriggerTarget triggerTarget = behaviours[j] as IVisTriggerTarget;
					if (triggerTarget != null)
						Triggered -= triggerTarget.OnTriggered;
				}
			}
		}
	}
	
	#endregion
	
	#region VisBaseTrigger Implementation
		
	/// <summary>
	/// This function is called by the trigger whenever 
	/// this trigger has been TRIGGERED.
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
	public override void OnTriggered(float current, float previous, float difference, float adjustedDifference) 
	{
		if (Triggered != null)
			Triggered(Controller.GetCurrentValue(),
		              Controller.GetPreviousValue(),
		              Controller.GetValueDifference(),
		              Controller.GetAdjustedValueDifference());
	}
	
	#endregion
}


