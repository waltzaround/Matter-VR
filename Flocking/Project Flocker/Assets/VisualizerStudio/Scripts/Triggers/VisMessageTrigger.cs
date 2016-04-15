using UnityEngine;
using System.Collections;

/// <summary>
/// This trigger is used to target specific game objects,
/// and then send a message to all target game objects 
/// when triggered
/// </summary>
[AddComponentMenu("Visualizer Studio/Triggers/Message Trigger")]
public class VisMessageTrigger : VisTargetTrigger 
{
	#region Defaults Static Class
	
	/// <summary>
    /// This internal class holds all of the defaults of the VisMessageTrigger class. 
	/// </summary>
	public static new class Defaults
	{			
		public const string messageName = "TriggerMessage";
		public const ControllerSourceValue messageParameter = ControllerSourceValue.Current; 
	}
	
	#endregion
	
	#region Enumerations
	
	/// <summary>
	/// This enumeration defines what controller value should be sent as 
	/// a parameter of the message that this component sends. 
	/// </summary>
	public enum ControllerSourceValue
	{
		/// <summary>
		/// Indicates that no parameter should be sent. 
		/// </summary>
		None,
		
		/// <summary>
		/// Indicates the current controller value should be sent as the parameter. 
		/// </summary>
		Current,
		
		/// <summary>
		/// Indicates the previous controller value should be sent as the parameter. 
		/// </summary>
		Previous,
		
		/// <summary>
		/// Indicates the controller value difference should be sent as the parameter. 
		/// </summary>
		Difference
	}
	
	#endregion
	
	#region Public Member Variables
	
	/// <summary>
	/// This is the name of the message to send. 
	/// </summary>
    //[HideInInspector()]
	public string messageName = "TriggerMessage";
	
	/// <summary>
	/// This is the parameter to send with the message. 
    /// </summary>
    //[HideInInspector()]
	public ControllerSourceValue messageParameter = ControllerSourceValue.Current; 
	
	#endregion
	
	#region Init/Deinit Functions
	
	/// <summary>
	/// This is called when this script component is reset. 
	/// </summary>
	public override void Reset()
	{
		base.Reset();
		
		messageName = Defaults.messageName;
		messageParameter = Defaults.messageParameter;
	}
	
	/// <summary>
	/// This is called when this script component is started. 
	/// </summary>
	public override void Start() 
	{
		base.Start();
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
		
	#region VisTargetTrigger Implementation

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
		base.OnTriggered(current, previous, difference, adjustedDifference);
		
		for (int i = 0; i < targetGameObjects.Count; i++)
		{
			switch (messageParameter)
			{
				case ControllerSourceValue.None:
					targetGameObjects[i].SendMessage(messageName);
					break;
				case ControllerSourceValue.Current:
					targetGameObjects[i].SendMessage(messageName, current);
					break;
				case ControllerSourceValue.Previous:
					targetGameObjects[i].SendMessage(messageName, previous);
					break;
				case ControllerSourceValue.Difference:
					targetGameObjects[i].SendMessage(messageName, adjustedDifference);
					break;
			}			
		}
	}
	
	#endregion
}
