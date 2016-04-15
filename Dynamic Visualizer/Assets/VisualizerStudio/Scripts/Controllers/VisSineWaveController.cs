using UnityEngine;
using System.Collections;

/// <summary>
/// This is a non music based controller that will use a sine wave function to
/// oscillate between 0.0 and 1.0.
/// </summary>
[AddComponentMenu("Visualizer Studio/Controllers/Sine Wave Controller")]
public class VisSineWaveController : VisBaseController 
{
    #region Defaults Static Class

    /// <summary>
    /// This internal class holds all of the defaults of the VisSineWaveController class. 
    /// </summary>
    public new static class Defaults
    {
        public const float speedScalar = 1.0f;
    }

    #endregion

    #region Public Member Variables

    /// <summary>
    /// This is the speed scalar that controls how fast this controller oscillate between min and max values.
    /// </summary>
    //[HideInInspector()]
    public float speedScalar = Defaults.speedScalar;

    #endregion

    #region Init/Deinit Functions

    /// <summary>
    /// This function resets this controller to default values 
    /// </summary>
    public override void Reset()
    {
        base.Reset();

        speedScalar = Defaults.speedScalar;
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
        return (Mathf.Sin(Time.time * speedScalar) + 1.0f) * 0.5f;
    }

    #endregion
}
