using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// This class is used as a base class for any modifier that
/// is going to be generically setting properties on some
/// object.
/// </summary>
public abstract class VisBasePropertyModifier : VisBaseModifier
{
    #region Defaults Static Class

    /// <summary>
    /// This internal class holds all of the defaults of the VisBasePropertyModifier class. 
    /// </summary>
    public static new class Defaults
    {
        public const ControllerSourceValue controllerSourceValue = ControllerSourceValue.Current;
        public const float minControllerValue = 0.0f;
        public const float maxControllerValue = 1.0f;
        public const float minPropertyValue = -1.0f;
        public const float maxPropertyValue = 1.0f;
        public const bool invertValue = false;
        public const bool randomValue = true;
    }

    #endregion

    #region Public Member Variables

    /// <summary>
    /// This indicates what source value from the target controller 
    /// should be used with this modifier. 
    /// </summary>
    //[HideInInspector()]
    public ControllerSourceValue controllerSourceValue = Defaults.controllerSourceValue;

    /// <summary>
    /// This is the min controller value that should be looked at 
    /// to determine how to modify the target property. 
    /// </summary>
    //[HideInInspector()]
    public float minControllerValue = Defaults.minControllerValue;

    /// <summary>
    /// This is the max controller value that should be looked at 
    /// to determine how to modify the target property. 
    /// </summary>
    //[HideInInspector()]
    public float maxControllerValue = Defaults.maxControllerValue;

    /// <summary>
    /// This is the min value that the target value should be set to. 
    /// </summary>
    //[HideInInspector()]
    public float minPropertyValue = Defaults.minPropertyValue;

    /// <summary>
    /// This is the max value that the target value should be set to. 
    /// </summary>
    //[HideInInspector()]
    public float maxPropertyValue = Defaults.maxPropertyValue;

    /// <summary>
    /// This indicates if the target property should be modified in reverse, 
    /// for example, it starts at maxPropertyValue when the controller is 
    /// at minControllerValue, and then moves to minPropertyValue when the 
    /// maxControllerValue is set on the controller. 
    /// </summary>
    //[HideInInspector()]
    public bool invertValue = Defaults.invertValue;

    #endregion

    #region Init/Deinit Functions

    /// <summary>
    /// This is callled when this commponent is reset. 
    /// </summary>
    public override void Reset()
    {
        base.Reset();

        controllerSourceValue = Defaults.controllerSourceValue;
        minControllerValue = Defaults.minControllerValue;
        maxControllerValue = Defaults.maxControllerValue;
        minPropertyValue = Defaults.minPropertyValue;
        maxPropertyValue = Defaults.maxPropertyValue;
    }

    /// <summary>
    /// This is called when this component is started. 
    /// </summary>
    public override void Start()
    {
        base.Start();

        maxControllerValue = VisHelper.Validate(maxControllerValue, -1000000.0f, 1000000.0f, Defaults.maxControllerValue, this, "maxControllerValue", false);
        minControllerValue = VisHelper.Validate(minControllerValue, -1000000.0f, maxControllerValue, Mathf.Min(Defaults.minControllerValue, maxControllerValue), this, "minControllerValue", false);
        maxPropertyValue = VisHelper.Validate(maxPropertyValue, -1000000.0f, 1000000.0f, Defaults.maxPropertyValue, this, "maxPropertyValue", false);
        minPropertyValue = VisHelper.Validate(minPropertyValue, -1000000.0f, maxPropertyValue, Mathf.Min(Defaults.minPropertyValue, maxPropertyValue), this, "minPropertyValue", false);
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
        //get the source value
        float value = current;
        if (controllerSourceValue == ControllerSourceValue.Previous)
            value = previous;
        else if (controllerSourceValue == ControllerSourceValue.Difference)
            value = adjustedDifference;

        //calc the property value
        float propertyValue = VisHelper.ConvertBetweenRanges(value,
                                                             minControllerValue,
                                                             maxControllerValue,
                                                             minPropertyValue,
                                                             maxPropertyValue,
                                                             invertValue);

        //call to abstract function to set the property
        SetProperty(propertyValue);
    }

    #endregion

    #region SetProperty Abstract Function

    /// <summary>
    /// This function is used to call into sub classes of
    /// VisBasePropertyModifer, in order for them to set their
    /// target property to the new value specified.
    /// </summary>
    /// <param name="propertyValue">The new value to set the property to.</param>
    public abstract void SetProperty(float propertyValue);

    #endregion
}