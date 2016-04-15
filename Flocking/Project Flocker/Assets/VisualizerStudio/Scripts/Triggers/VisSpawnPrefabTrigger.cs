using UnityEngine;
using System.Collections;

/// <summary>
/// This trigger is used to spawn a prefab as a 
/// reaction to changes in the music.
/// </summary>
[AddComponentMenu("Visualizer Studio/Triggers/Spawn Prefab Trigger")]
public class VisSpawnPrefabTrigger : VisBaseTrigger 
{
    #region Defaults Static Class

    /// <summary>
    /// This internal class holds all of the defaults of the VisSpawnPrefabTrigger class. 
    /// </summary>
    public static new class Defaults
    {
        public static readonly Vector3 randomOffset = Vector3.zero;
    }

    #endregion

    #region Public Member Variables

    /// <summary>
    /// This is the prefab to spawn when this trigger is triggered.
    /// </summary>
    //[HideInInspector()]
    public GameObject prefab = null;

    /// <summary>
    /// This is the random offset to apply to the position when spawning
    /// </summary>
    //[HideInInspector()]
    public Vector3 randomOffset = Defaults.randomOffset;

    #endregion

    #region Init/Deinit Functions

    /// <summary>
    /// This is callled when this commponent is reset. 
    /// </summary>
    public override void Reset()
    {
        randomOffset = Defaults.randomOffset;

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
        if (prefab != null && transform != null)
        {
            Vector3 offset = new Vector3(UnityEngine.Random.Range(-randomOffset.x, randomOffset.x),
                                         UnityEngine.Random.Range(-randomOffset.y, randomOffset.y),
                                         UnityEngine.Random.Range(-randomOffset.z, randomOffset.z));

            //spawn the new object
            Object newObj = Instantiate(prefab, transform.position + offset, transform.rotation);
            
            //check if it is a game object
            if (newObj is GameObject)
            {
                //get all mono behaviors
                MonoBehaviour[] behaviors = (newObj as GameObject).GetComponents<MonoBehaviour>();

                //loop through and find all IVisPrefabSpawnedTarget objects
                for (int i = 0; i < behaviors.Length; i++)
                {
                    //check if it is a IVisPrefabSpawnedTarget
                    if (behaviors[i].enabled && behaviors[i] is IVisPrefabSpawnedTarget)
                    {
                        //notify spawned
                        (behaviors[i] as IVisPrefabSpawnedTarget).OnSpawned(current, previous, difference, adjustedDifference);
                    }
                }
            }
        }
	}
	
	#endregion
}
