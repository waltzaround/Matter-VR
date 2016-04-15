using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// This class is used as a base class for any trigger that
/// is going to be generically setting properties on some
/// object.
/// </summary>
public abstract class VisBasePropertyTrigger : VisBaseTrigger
{
    #region Defaults Static Class

    /// <summary>
    /// This internal class holds all of the defaults of the VisBasePropertyTrigger class. 
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
        public const bool limitIncreaseRate = false;
        public const float increaseRate = 1.0f;
        public const bool limitDecreaseRate = false;
        public const float decreaseRate = 1.0f;
        public const bool returnToRest = false;
        public const float restValue = 0.0f;
    }

    #endregion

    #region Public Member Variables

    /// <summary>
    /// This indicates what source value from the target controller should be used with this modifier. 
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

    /// <summary>
    /// This indicates if, when triggered, this property trigger should
    /// pick a random value in the range specified, or if it should
    /// try to map/convert the value based on ranges specified.
    /// </summary>
    //[HideInInspector()]
    public bool randomValue = Defaults.randomValue;

    /// <summary>
    /// This indicates if the increase rate of the target property value should be limited. 
    /// </summary>
    //[HideInInspector()]
    public bool limitIncreaseRate = Defaults.limitIncreaseRate;

    /// <summary>
    /// This is the rate at which the target property value can increase per second. 
    /// </summary>
    //[HideInInspector()]
    public float increaseRate = Defaults.increaseRate;

    /// <summary>
    /// This indicates if the decrease rate of the target property value should be limited. 
    /// </summary>
    //[HideInInspector()]
    public bool limitDecreaseRate = Defaults.limitDecreaseRate;

    /// <summary>
    /// This is the rate at which the target property value can decrease per second. 
    /// </summary>
    //[HideInInspector()]
    public float decreaseRate = Defaults.decreaseRate;

    /// <summary>
    /// This indicates if this property trigger should return to rest after it reaches it's current target value.
    /// </summary>
    //[HideInInspector()]
    public bool returnToRest = Defaults.returnToRest;

    /// <summary>
    /// This is the "rest" value that this property trigger should return to if "Return to Rest" is active.
    /// </summary>
    //[HideInInspector()]
    public float restValue = Defaults.restValue;

    #endregion

    #region Protected Member Variables

    /// <summary>
    /// This is the target property value that should be approached.
    /// </summary>
    protected float m_fTargetPropertyValue = float.PositiveInfinity;

    /// <summary>
    /// This is the target property value that is currently set.  
    /// If this is INFINITY, the value to approach will be set immediately!
    /// </summary>
    protected float m_fCurrentPropertyValue = float.PositiveInfinity;

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
        limitIncreaseRate = Defaults.limitIncreaseRate;
        increaseRate = Defaults.increaseRate;
        limitDecreaseRate = Defaults.limitDecreaseRate;
        decreaseRate = Defaults.decreaseRate;
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
        increaseRate = VisHelper.Validate(increaseRate, 0.00001f, 10000.0f, Defaults.increaseRate, this, "increaseRate", false);
        decreaseRate = VisHelper.Validate(decreaseRate, 0.00001f, 10000.0f, Defaults.decreaseRate, this, "decreaseRate", false);

        //check if return to rest is set
        if (returnToRest)
        {
            //make sure either limitting flag is checked
            if (!limitIncreaseRate && !limitDecreaseRate)
            {//warn and set to false
                Debug.LogWarning("If \"Return to Rest\" is true, you must have \"Limit Increase Rate\" or \"Limit Decrease Rate\" set to true. Resetting it to false!");
                returnToRest = false;
            }
        }
    }

    #endregion

    #region Update Functions

    /// <summary>
    /// This is called when this base property trigger needs to update.
    /// </summary>
    public override void Update()
    {
        base.Update();

        //update the current property value based on target property value
        if (float.IsPositiveInfinity(m_fCurrentPropertyValue) == false)
        {
            if (m_fCurrentPropertyValue != m_fTargetPropertyValue)
            {//approach value
                if (limitIncreaseRate && m_fCurrentPropertyValue < m_fTargetPropertyValue)
                {//limit increase
                    //increase current value
                    m_fCurrentPropertyValue += increaseRate * Time.deltaTime;
                    if (m_fCurrentPropertyValue > m_fTargetPropertyValue)
                        m_fCurrentPropertyValue = m_fTargetPropertyValue;

                    //set current value
                    SetProperty(m_fCurrentPropertyValue);
                }
                else if (limitDecreaseRate && m_fCurrentPropertyValue > m_fTargetPropertyValue)
                {//limit decrease
                    //decrease current value
                    m_fCurrentPropertyValue -= decreaseRate * Time.deltaTime;
                    if (m_fCurrentPropertyValue < m_fTargetPropertyValue)
                        m_fCurrentPropertyValue = m_fTargetPropertyValue;

                    //set current value
                    SetProperty(m_fCurrentPropertyValue);
                }
                else
                {//no limiting, set instantly
                    m_fCurrentPropertyValue = m_fTargetPropertyValue;
                    SetProperty(m_fCurrentPropertyValue);
                }
            }
            else if (returnToRest && m_fCurrentPropertyValue != restValue)
            {//return to rest
                m_fTargetPropertyValue = restValue;
            }
        }
        else if (returnToRest)
        {
            //set initial rest value
            m_fCurrentPropertyValue = m_fTargetPropertyValue = restValue;
            SetProperty(m_fCurrentPropertyValue);
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
        //check if this should be a random value
        if (randomValue)
        {//get random value
            m_fTargetPropertyValue = UnityEngine.Random.Range(minPropertyValue, maxPropertyValue);
        }
        else
        {//get value from ranges
            //get the source value
            float value = current;
            if (controllerSourceValue == ControllerSourceValue.Previous)
                value = previous;
            else if (controllerSourceValue == ControllerSourceValue.Difference)
                value = adjustedDifference;

            //calc the property value
            m_fTargetPropertyValue = VisHelper.ConvertBetweenRanges(value,
                                                                    minControllerValue,
                                                                    maxControllerValue,
                                                                    minPropertyValue,
                                                                    maxPropertyValue,
                                                                    invertValue);
        }

        //check if the value needs to be limited
        if (float.IsPositiveInfinity(m_fCurrentPropertyValue))
        {//the current value is infinity, set instantly no matter what
            m_fCurrentPropertyValue = m_fTargetPropertyValue;
            SetProperty(m_fCurrentPropertyValue);
        }
        else if (limitIncreaseRate && m_fCurrentPropertyValue < m_fTargetPropertyValue)
        {//limit increase
            SetProperty(m_fCurrentPropertyValue);
        }
        else if (limitDecreaseRate && m_fCurrentPropertyValue > m_fTargetPropertyValue)
        {//limit decrease
            SetProperty(m_fCurrentPropertyValue);
        }
        else
        {//no limiting, set instantly
            m_fCurrentPropertyValue = m_fTargetPropertyValue;
            SetProperty(m_fCurrentPropertyValue);
        }
    }

    #endregion

    #region Property Abstract Functions

    /// <summary>
    /// This function is used to call into sub classes of
    /// VisBasePropertyTrigger, in order for them to set their
    /// target property to the new value specified.
    /// </summary>
    /// <param name="propertyValue">The new value to set the property to.</param>
    public abstract void SetProperty(float propertyValue);

    #endregion
}