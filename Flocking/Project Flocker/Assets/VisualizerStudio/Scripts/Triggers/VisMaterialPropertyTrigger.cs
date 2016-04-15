using System;
using UnityEngine;

/// <summary>
/// This trigger is used to set a float material
/// property as a reaction to changes in the music.
/// </summary>
[AddComponentMenu("Visualizer Studio/Triggers/Material Property Trigger")]
public class VisMaterialPropertyTrigger : VisBasePropertyTrigger 
{
	#region Defaults Static Class
	
	/// <summary>
    /// This internal class holds all of the defaults of the VisMaterialPropertyTrigger class. 
	/// </summary>
	public static new class Defaults
	{
        public const string targetProperty = "";
        public const bool setAsProceduralMaterial = false;
        public const bool rebuildProceduralTexturesImmediately = false;
        public const bool applyToMaterialIndex = false;
        public const int materialIndex = 0;
	}
	
	#endregion
	
	#region Public Member Variables
	
	/// <summary>
	/// This is the target property to modify on the parent game object. 
	/// As an example of how this works:
	/// minControllerValue = 0.2
	/// maxControllerValue = 0.8
	/// minPropertyValue = 2.0
	/// maxPropertyValue = 4.0
	/// invertValue = false
	/// 
	/// controllerInputValue = 0.5 -- newPropertyValue = 3.0
	/// controllerInputVlaue = 0.35 -- newPropertyValue = 2.5
    /// </summary>
    //[HideInInspector()]
    public string targetProperty = Defaults.targetProperty;

    /// <summary>
    /// This indicates if this material property modifier should treat the target as a procedural
    /// material and attempt to set the target property as a procedural float.
    /// </summary>
    //[HideInInspector()]
    public bool setAsProceduralMaterial = false;

    /// <summary>
    /// This indicates if the procedural textures should immediately be regenerated when setting a float on the target material.
    /// </summary>
    //[HideInInspector()]
    public bool rebuildProceduralTexturesImmediately = false;

    /// <summary>
    /// This indicates if this material property modifier should apply 
    /// to a material in a specific index, or the main material.
    /// </summary>
    //[HideInInspector()]
    public bool applyToMaterialIndex = false;

    /// <summary>
    /// This is the material index to apply this property change to.
    /// </summary>
    //[HideInInspector()]
    public int materialIndex = 0;

    #endregion

    #region Private Members

    /// <summary>
    /// This indicates if there was a special target property name entrered for this material property trigger.
    /// Valid values are ColorR, ColorRed, ColorG, ColorGreen, ColorB, ColorBlue, ColorA, ColorAlpha, and Color.
    /// </summary>
    private bool specialTargetProperty = false;

    #endregion
	
	#region Init/Deinit Functions
	
	/// <summary>
	/// This is callled when this commponent is reset. 
	/// </summary>
	public override void Reset()
	{
		base.Reset();

        targetProperty = Defaults.targetProperty;
        setAsProceduralMaterial = Defaults.setAsProceduralMaterial;
        rebuildProceduralTexturesImmediately = Defaults.rebuildProceduralTexturesImmediately;
        applyToMaterialIndex = Defaults.applyToMaterialIndex;
        materialIndex = Defaults.materialIndex;
	}
	
	/// <summary>
	/// This is called when this component is started. 
	/// </summary>
	public override void Start() 
	{
        base.Start();

        //check if this is using a special value
        string lowerCaseTargetProperty = targetProperty.ToLower();
        if (lowerCaseTargetProperty == "colorr" ||
            lowerCaseTargetProperty == "colorred" ||
            lowerCaseTargetProperty == "colorg" ||
            lowerCaseTargetProperty == "colorgreen" ||
            lowerCaseTargetProperty == "colorb" ||
            lowerCaseTargetProperty == "colorblue" ||
            lowerCaseTargetProperty == "colora" ||
            lowerCaseTargetProperty == "coloralpha" ||
            lowerCaseTargetProperty == "color")
            specialTargetProperty = true;
        else
            specialTargetProperty = false;
	}
	
	#endregion

    #region VisBasePropertyTrigger Implementation

    /// <summary>
    /// This function is used to call into sub classes of
    /// VisBasePropertyTrigger, in order for them to set their
    /// target property to the new value specified.
    /// </summary>
    /// <param name="propertyValue">The new value to set the property to.</param>
    public override void SetProperty(float propertyValue)
    {
        //create var to store target material
        Material targetMaterial = null;

        //get the target material
        if (setAsProceduralMaterial &&
            applyToMaterialIndex &&
            GetComponent<Renderer>() != null &&
            materialIndex >= 0 &&
            materialIndex < GetComponent<Renderer>().sharedMaterials.Length &&
#if (!UNITY_3_3 && !UNITY_3_2 && !UNITY_3_1 && !UNITY_3_0_0 && !UNITY_3_0 && !UNITY_2_6_1 && !UNITY_2_6) && (UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER || UNITY_EDITOR)
 GetComponent<Renderer>().sharedMaterials[materialIndex] as ProceduralMaterial)
        {//get indexed material as procedural material
            targetMaterial = GetComponent<Renderer>().sharedMaterials[materialIndex];
        }
#else
            true)
        {//can't sure procedural materials on IOS or Android!            
            Debug.LogWarning("Procedural Materials cannot be used on IOS or Android, and also requires Unity 3.4 or later!");
        }
#endif
        else if (setAsProceduralMaterial &&
                 GetComponent<Renderer>() != null &&
                 GetComponent<Renderer>().sharedMaterial != null &&
#if (!UNITY_3_3 && !UNITY_3_2 && !UNITY_3_1 && !UNITY_3_0_0 && !UNITY_3_0 && !UNITY_2_6_1 && !UNITY_2_6) && (UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER || UNITY_EDITOR)
 GetComponent<Renderer>().sharedMaterial as ProceduralMaterial)
        {//get main material as procedural material
            targetMaterial = GetComponent<Renderer>().sharedMaterial;
        }
#else
                 true)
        {//can't sure procedural materials on IOS or Android!            
            Debug.LogWarning("Procedural Materials cannot be used on IOS or Android, and also requires Unity 3.4 or later!");
        }
#endif
        else if (applyToMaterialIndex &&
            GetComponent<Renderer>() != null &&
            materialIndex >= 0 &&
            materialIndex < GetComponent<Renderer>().materials.Length)
        {//get indexed material as normal material
            targetMaterial = GetComponent<Renderer>().materials[materialIndex];
        }
        else if (GetComponent<Renderer>() != null &&
                 GetComponent<Renderer>().material != null)
        {//get main material as procedural material
            targetMaterial = GetComponent<Renderer>().material;
        }

        //make sure a target material was found
        if (targetMaterial != null)
        {
#if (!UNITY_3_3 && !UNITY_3_2 && !UNITY_3_1 && !UNITY_3_0_0 && !UNITY_3_0 && !UNITY_2_6_1 && !UNITY_2_6) && (UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER || UNITY_EDITOR)
            //check if this should be set as a procedural material and it actual is on
            if (setAsProceduralMaterial &&
                targetMaterial as ProceduralMaterial)
            {
                //get procedural material
                ProceduralMaterial procMat = targetMaterial as ProceduralMaterial;

                //make sure the value has changed
                float current = procMat.GetProceduralFloat(targetProperty);
                if (current != propertyValue)
                {
                    //set float and rebuild texture
                    procMat.SetProceduralFloat(targetProperty, propertyValue);
                    if (rebuildProceduralTexturesImmediately)
                        procMat.RebuildTexturesImmediately();
                    else
                        procMat.RebuildTextures();
                }
            }
            else
#endif
            {
                //check if there is a special target property set
                if (specialTargetProperty)
                {
                    //check for special float
                    switch (targetProperty.ToLower())
                    {
                        case "colorr":
                        case "colorred":
                            float clampedValue = Mathf.Clamp(propertyValue, 0.0f, 1.0f);
                            Color newColor = new Color(clampedValue,
                                                       targetMaterial.color.g,
                                                       targetMaterial.color.b,
                                                       targetMaterial.color.a);
                            targetMaterial.color = newColor;
                            break;
                        case "colorg":
                        case "colorgreen":
                            clampedValue = Mathf.Clamp(propertyValue, 0.0f, 1.0f);
                            newColor = new Color(targetMaterial.color.r,
                                                 clampedValue,
                                                 targetMaterial.color.b,
                                                 targetMaterial.color.a);
                            targetMaterial.color = newColor;
                            break;
                        case "colorb":
                        case "colorblue":
                            clampedValue = Mathf.Clamp(propertyValue, 0.0f, 1.0f);
                            newColor = new Color(targetMaterial.color.r,
                                                 targetMaterial.color.g,
                                                 clampedValue,
                                                 targetMaterial.color.a);
                            targetMaterial.color = newColor;
                            break;
                        case "colora":
                        case "coloralpha":
                            clampedValue = Mathf.Clamp(propertyValue, 0.0f, 1.0f);
                            newColor = new Color(targetMaterial.color.r,
                                                 targetMaterial.color.g,
                                                 targetMaterial.color.b,
                                                 clampedValue);
                            targetMaterial.color = newColor;
                            break;
                        case "color":
                            clampedValue = Mathf.Clamp(propertyValue, 0.0f, 1.0f);
                            newColor = new Color(clampedValue,
                                                 clampedValue,
                                                 clampedValue,
                                                 targetMaterial.color.a);
                            targetMaterial.color = newColor;
                            break;
                        default:
                            //set float
                            targetMaterial.SetFloat(targetProperty, propertyValue);
                            break;
                    }
                }
                else
                {
                    //set float
                    targetMaterial.SetFloat(targetProperty, propertyValue);
                }
            }
        }
    }

    #endregion
}

