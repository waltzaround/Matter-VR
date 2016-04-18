using System;
using UnityEngine;

/// <summary>
/// This trigger is used to apply forces to physics objects 
/// as a reaction to changes in the music.
/// </summary>
[AddComponentMenu("Visualizer Studio/Triggers/Add Force Trigger")]
public class VisAddForceTrigger : VisBaseTrigger
{
    #region Defaults Static Class

    /// <summary>
    /// This internal class holds all of the defaults of the VisAddForceTrigger class. 
    /// </summary>
    public static new class Defaults
    {

        public const ControllerSourceValue controllerValue = ControllerSourceValue.Current;
        public const float minControllerValue = 0.0f;
        public const float maxControllerValue = 1.0f;
        public const float minForceValue = 10.0f;
        public const float maxForceValue = 200.0f;
        public const bool invertValue = false;
        public const bool randomValue = false;
        public static readonly Vector3 forceDirection = Vector3.up;
        public const ForceMode forceMode = ForceMode.Impulse;
    }

    #endregion

    #region Public Member Variables

    /// <summary>
    /// This indicates what source value from the target controller should be used with this trigger. 
    /// </summary>
    //[HideInInspector()]
    public ControllerSourceValue controllerValue = Defaults.controllerValue;

    /// <summary>
    /// This is the min controller value that should be looked at 
    /// to determine how much force to add. 
    /// </summary>  
    //[HideInInspector()]
    public float minControllerValue = Defaults.minControllerValue;

    /// <summary>
    /// This is the max controller value that should be looked at 
    /// to determine how much force to add. 
    /// </summary>
    //[HideInInspector()]
    public float maxControllerValue = Defaults.maxControllerValue;

    /// <summary>
    /// This is the min value of the force to add.
    /// </summary>
    //[HideInInspector()]
    public float minForceValue = Defaults.minForceValue;

    /// <summary>
    /// This is the max value of the force to add.
    /// </summary>
    //[HideInInspector()]
    public float maxForceValue = Defaults.maxForceValue;

    /// <summary>
    /// This indicates if the forde to add should be applied in reverse, 
    /// for example, it starts at maxForceValue when the controller is 
    /// at minControllerValue, and then moves to minForceValue when the 
    /// maxControllerValue is set on the controller. 
    /// </summary>
    //[HideInInspector()]
    public bool invertValue = Defaults.invertValue;

    /// <summary>
    /// This indicates if, when triggered, this trigger should
    /// pick a random value in the range specified, or if it should
    /// try to map/convert the value based on ranges specified.
    /// </summary>
    //[HideInInspector()]
    public bool randomValue = Defaults.randomValue;

    /// <summary>
    /// This is the direction in which to apply the force.
    /// </summary>
    //[HideInInspector()]
    public Vector3 forceDirection = Defaults.forceDirection;

    /// <summary>
    /// This is the mode of force to apply.
    /// </summary>
    //[HideInInspector()]
    public ForceMode forceMode = Defaults.forceMode;

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
	public override void OnTriggered (float current, float previous, float difference, float adjustedDifference)
	{
        if (GetComponent<Rigidbody>() != null)
        {
            //get normalized direction
            Vector3 normalDir = forceDirection.normalized;

            //get the source value
            float value = current;
            if (controllerValue == ControllerSourceValue.Previous)
                value = previous;
            else if (controllerValue == ControllerSourceValue.Difference)
                value = adjustedDifference;

            //calc the property value
            float forceValue = VisHelper.ConvertBetweenRanges(value,
                                                              minControllerValue,
                                                              maxControllerValue,
                                                              minForceValue,
                                                              maxForceValue,
                                                              invertValue);

            //add force
            GetComponent<Rigidbody>().AddForce(normalDir * forceValue, forceMode);
        }
	}
	
	#endregion
}

