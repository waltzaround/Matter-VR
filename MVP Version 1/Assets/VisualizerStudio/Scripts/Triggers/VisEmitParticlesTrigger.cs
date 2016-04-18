using UnityEngine;
using System.Collections;

/// <summary>
/// This trigger is used to emit particles 
/// as a reaction to changes in the music.
/// </summary>
[AddComponentMenu("Visualizer Studio/Triggers/Emit Particles Trigger")]
public class VisEmitParticlesTrigger : VisBaseTrigger
{
    #region Defaults Static Class

    /// <summary>
    /// This internal class holds all of the defaults of the VisEmitParticlesTrigger class. 
    /// </summary>
    public static new class Defaults
    {
    }

    #endregion

    #region Public Member Variables

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
    public override void OnTriggered(float current, float previous, float difference, float adjustedDifference)
    {
        if (GetComponent<ParticleEmitter>() != null)
        {
			GetComponent<ParticleEmitter>().Emit();
        }
    }

    #endregion
}
