using UnityEngine;
using System.Collections;

/// <summary>
/// This is a non music based controller that will pick random values
/// between 0.0 and 1.0 after set intervals of time.
/// </summary>
[AddComponentMenu("Visualizer Studio/Controllers/Random Controller")]
public class VisRandomController : VisBaseController 
{
    #region Defaults Static Class

    /// <summary>
    /// This internal class holds all of the defaults of the VisRandomController class. 
    /// </summary>
    public new static class Defaults
    {
        public const float delayTime = 1.0f;
    }

    #endregion

    #region Public Member Variables

    /// <summary>
    /// This is the amount of time to wait before picking random values.
    /// </summary>
    //[HideInInspector()]
    public float delayTime = Defaults.delayTime;

    #endregion

    #region Private Member Variables

    /// <summary>
    /// This is the current random value.
    /// </summary>
    private float m_fCurrentRandomValue = 0.0f;

    /// <summary>
    /// This is the timer used to determine when to get a new value.
    /// </summary>
    private float m_fNewValueTimer = 0.0f;

    #endregion

    #region Init/Deinit Functions

    /// <summary>
    /// This function resets this controller to default values 
    /// </summary>
    public override void Reset()
    {
        base.Reset();
    }

    /// <summary>
    /// The main start function.
    /// </summary>
    public override void Start()
    {
        base.Start();
    }

    #endregion

    #region VisBaseController Implementation

    /// <summary>
    /// This function returns the current value for this controller.
    /// TO IMPLEMENT A CUSTOM CONTROLLER, override this function 
    /// to return the current target value.
    /// </summary>
    /// <returns>
    /// The custom controller value.
    /// </returns>
    public override float GetCustomControllerValue()
    {
        m_fNewValueTimer -= Time.deltaTime;
        if (m_fNewValueTimer <= 0.0f)
        {
            m_fNewValueTimer = delayTime;
            m_fCurrentRandomValue = Random.Range(0.0f, 1.0f);
        }

        return m_fCurrentRandomValue;
    }

    #endregion
}