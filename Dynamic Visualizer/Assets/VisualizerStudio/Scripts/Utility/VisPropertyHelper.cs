using UnityEngine;

#region Enumerations

/// <summary>
/// This enumeration describes what basic property 
/// of the game object should be modified. 
/// </summary>
public enum GameObjectProperty
{
	/// <summary>
	/// The game object x position. 
	/// </summary>
	XPosition,
	
	/// <summary>
	/// The game object y position. 
	/// </summary>
	YPosition,
	
	/// <summary>
	/// The game object z position. 
	/// </summary>
	ZPosition,
	
	/// <summary>
	/// The game object x rotation. 
	/// </summary>
	XRotation,
	
	/// <summary>
	/// The game object y rotation. 
	/// </summary>
	YRotation,
	
	/// <summary>
	/// The game object z rotation. 
	/// </summary>
	ZRotation,
	
	/// <summary>
	/// The game object x velocity. 
	/// </summary>
	XVelocity,
	
	/// <summary>
	/// The game object y velocity. 
	/// </summary>
	YVelocity,
	
	/// <summary>
	/// The game object z velocity. 
	/// </summary>
	ZVelocity,
	
	/// <summary>
	/// The game object x angular velocity. 
	/// </summary>
	XAngularVelocity,
	
	/// <summary>
	/// The game object y angular velocity. 
	/// </summary>
	YAngularVelocity,
	
	/// <summary>
	/// The game object z angular velocity. 
	/// </summary>
	ZAngularVelocity,
	
	/// <summary>
	/// The game object overall scale. 
	/// </summary>
	UniformScale,
	
	/// <summary>
	/// The game object x scale. 
	/// </summary>
	XScale,
	
	/// <summary>
	/// The game object y scale. 
	/// </summary>
	YScale,
	
	/// <summary>
	/// The game object z scale. 
	/// </summary>
	ZScale
}

public enum EmitterProperty
{
    AngularVelocity,
    RandomAngularVelocity,
    EmitterVelocityScale,
    MinSize,
    MaxSize,
    MinEnergy,
    MaxEnergy,
    MinEmission,
    MaxEmission  
}

public enum LightProperty
{
    ColorRed,
    ColorGreen,
    ColorBlue,
    ColorRGB,
    ColorAlpha,
    Intensity,
    Range,
    SpotAngle,
    ShadowBias,
    ShadowSoftness,
    ShadowSoftnessFade,
    ShadowStrength
}

public enum AnimationStateProperty
{
    Speed,
    NormalizedTime,
    Weight
}

#endregion

/// <summary>
/// This static class is used to provide helper functions for Visualizer Studio. 
/// </summary>
public static class VisPropertyHelper
{		
    #region Setter Functions

    /// <summary>
    /// This function is used to help set basic properties on a game object
    /// in a generic way.
    /// </summary>
    /// <param name="gameObject">The game object whose properties are to be set.</param>
    /// <param name="targetProperty">The target property to set.</param>
    /// <param name="propertyValue">The value to set the target property to.</param>
    public static void SetGameObjectProperty(GameObject gameObject, GameObjectProperty targetProperty, float propertyValue)
	{
		//check if the game object is null
		if (gameObject == null)
		{
			return;
		}
		
		//set the property
        switch (targetProperty)
        {
            case GameObjectProperty.XPosition:
                if (gameObject.transform != null)
                    gameObject.transform.position = new Vector3(propertyValue, 
							                                 	gameObject.transform.position.y, 
							                                 	gameObject.transform.position.z);
                break;
            case GameObjectProperty.YPosition:
                if (gameObject.transform != null)
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 
							                                 	propertyValue, 
							                                 	gameObject.transform.position.z);
                break;
            case GameObjectProperty.ZPosition:
                if (gameObject.transform != null)
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 
							                                 	gameObject.transform.position.y, 
							                                  	propertyValue);
                break;
            case GameObjectProperty.XRotation:
                if (gameObject.transform != null)
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(propertyValue, 
							                                                  	 gameObject.transform.rotation.eulerAngles.y, 
							                                                  	 gameObject.transform.rotation.eulerAngles.z));
                break;
            case GameObjectProperty.YRotation:
                if (gameObject.transform != null)
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.eulerAngles.x, 
							                                                  	 propertyValue, 
							                                                     gameObject.transform.rotation.eulerAngles.z));
                break;
            case GameObjectProperty.ZRotation:
                if (gameObject.transform != null)
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.eulerAngles.x, 
							                                                 	 gameObject.transform.rotation.eulerAngles.y, 
							                                                 	 propertyValue));
                break;
            case GameObjectProperty.XVelocity:
                if (gameObject.GetComponent<Rigidbody>() != null)
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(propertyValue, 
							                                 	gameObject.GetComponent<Rigidbody>().velocity.y, 
							                                 	gameObject.GetComponent<Rigidbody>().velocity.z);
				else if (gameObject.transform !=  null)
					gameObject.transform.Translate(propertyValue * Time.deltaTime, 0.0f, 0.0f);
                break;
            case GameObjectProperty.YVelocity:
                if (gameObject.GetComponent<Rigidbody>() != null)
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, 
							                                 	propertyValue, 
							                                 	gameObject.GetComponent<Rigidbody>().velocity.z);
				else if (gameObject.transform !=  null)
					gameObject.transform.Translate(0.0f, propertyValue * Time.deltaTime, 0.0f);
                break;
            case GameObjectProperty.ZVelocity:
                if (gameObject.GetComponent<Rigidbody>() != null)
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, 
							                                 	gameObject.GetComponent<Rigidbody>().velocity.y, 
							                                 	propertyValue);
				else if (gameObject.transform !=  null)
					gameObject.transform.Translate(0.0f, 0.0f, propertyValue * Time.deltaTime);
                break;
            case GameObjectProperty.XAngularVelocity:
                if (gameObject.GetComponent<Rigidbody>() != null)
                    gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(propertyValue, 
							                                           gameObject.GetComponent<Rigidbody>().angularVelocity.y, 
							                                           gameObject.GetComponent<Rigidbody>().angularVelocity.z);
				else if (gameObject.transform != null)
					gameObject.transform.Rotate(propertyValue * Time.deltaTime, 0.0f, 0.0f);
                break;
            case GameObjectProperty.YAngularVelocity:
                if (gameObject.GetComponent<Rigidbody>() != null)
                    gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(gameObject.GetComponent<Rigidbody>().angularVelocity.x, 
							                                        	propertyValue, 
							                                        	gameObject.GetComponent<Rigidbody>().angularVelocity.z);
				else if (gameObject.transform != null)
					gameObject.transform.Rotate(0.0f, propertyValue * Time.deltaTime, 0.0f);
                break;
            case GameObjectProperty.ZAngularVelocity:
                if (gameObject.GetComponent<Rigidbody>() != null)
                    gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(gameObject.GetComponent<Rigidbody>().angularVelocity.x, 
							                                           gameObject.GetComponent<Rigidbody>().angularVelocity.y, 
							                                           propertyValue);
				else if (gameObject.transform != null)
					gameObject.transform.Rotate(0.0f, 0.0f, propertyValue * Time.deltaTime);
                break;
            case GameObjectProperty.UniformScale:
                if (gameObject.transform)
                    gameObject.transform.localScale = new Vector3(propertyValue, 
							                                   	  propertyValue, 
							                                   	  propertyValue);
                break;
            case GameObjectProperty.XScale:
                if (gameObject.transform)
                    gameObject.transform.localScale = new Vector3(propertyValue, 
							                                   	  gameObject.transform.localScale.y, 
							                                   	  gameObject.transform.localScale.z);
                break;
            case GameObjectProperty.YScale:
                if (gameObject.transform)
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, 
							                                   	  propertyValue, 
							                                   	  gameObject.transform.localScale.z);
                break;
            case GameObjectProperty.ZScale:
                if (gameObject.transform)
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, 
							                                   	  gameObject.transform.localScale.y, 
							                                   	  propertyValue);
                break;
            default:
                break;
        }
	}

    /// <summary>
    /// This function is used to help set basic properties on a particle emitter
    /// in a generic way.
    /// </summary>
    /// <param name="emitter">The particle emitter whose properties are to be set.</param>
    /// <param name="targetProperty">The target property to set.</param>
    /// <param name="propertyValue">The value to set the target property to.</param>
	public static void SetEmitterProperty(ParticleEmitter emitter, EmitterProperty targetProperty, float propertyValue)
	{
		//check if the emitter is null
		if (emitter == null)
		{
			return;
		}
		
        //set the property
        switch (targetProperty)
        {
            case EmitterProperty.AngularVelocity:
                emitter.angularVelocity = propertyValue;
                break;
            case EmitterProperty.RandomAngularVelocity:
                emitter.rndAngularVelocity = propertyValue;
                break;
            case EmitterProperty.EmitterVelocityScale:
                emitter.emitterVelocityScale = propertyValue;
                break;
            case EmitterProperty.MinSize:
                emitter.minSize = propertyValue;
                break;
            case EmitterProperty.MaxSize:
                emitter.maxSize = propertyValue;
                break;
            case EmitterProperty.MinEnergy:
                emitter.minEnergy = propertyValue;
                break;
            case EmitterProperty.MaxEnergy:
                emitter.maxEnergy = propertyValue;
                break;
            case EmitterProperty.MinEmission:
                emitter.minEmission = propertyValue;
                break;
            case EmitterProperty.MaxEmission:
                emitter.maxEmission = propertyValue;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// This function is used to help set basic properties on a light
    /// in a generic way.
    /// </summary>
    /// <param name="light">The light whose properties are to be set.</param>
    /// <param name="targetProperty">The target property to set.</param>
    /// <param name="propertyValue">The value to set the target property to.</param>
	public static void SetLightProperty(Light light, LightProperty targetProperty, float propertyValue)
	{
		//check if the light is null
		if (light == null)
		{
			return;
		}

        //set the property
        switch (targetProperty)
        {
            case LightProperty.ColorRed:
                light.color = new Color(propertyValue,
                                        light.color.g,
                                        light.color.b,
                                        light.color.a);
                break;
            case LightProperty.ColorGreen:
                light.color = new Color(light.color.r,
                                        propertyValue,
                                        light.color.b,
                                        light.color.a);
                break;
            case LightProperty.ColorBlue:
                light.color = new Color(light.color.r,
                                        light.color.g,
                                        propertyValue,
                                        light.color.a);
                break;
            case LightProperty.ColorRGB:
                light.color = new Color(propertyValue,
                                        propertyValue,
                                        propertyValue,
                                        light.color.a);
                break;
            case LightProperty.ColorAlpha:
                light.color = new Color(light.color.r,
                                        light.color.g,
                                        light.color.b,
                                        propertyValue);
                break;
            case LightProperty.Intensity:
                light.intensity = propertyValue;
                break;
            case LightProperty.Range:
                light.range = propertyValue;
                break;
            case LightProperty.SpotAngle:
                light.spotAngle = propertyValue;
                break;
            case LightProperty.ShadowBias:
                light.shadowBias = propertyValue;
                break;
            case LightProperty.ShadowSoftness:
                light.shadowSoftness = propertyValue;
                break;
            case LightProperty.ShadowSoftnessFade:
                light.shadowSoftnessFade = propertyValue;
                break;
            case LightProperty.ShadowStrength:
                light.shadowStrength = propertyValue;
                break;
            default:
                break;
        }
	}

    /// <summary>
    /// This function is used to help set basic properties on a animation state
    /// in a generic way.
    /// </summary>
    /// <param name="animationState">The animation state whose properties are to be set.</param>
    /// <param name="targetProperty">The target property to set.</param>
    /// <param name="propertyValue">The value to set the target property to.</param>
	public static void SetAnimationStateProperty(AnimationState animationState, AnimationStateProperty targetProperty, float propertyValue)
	{
		//check if the animation is null
        if (animationState == null)
		{
			return;
		}

        //set the property
        switch (targetProperty)
        {
            case AnimationStateProperty.Speed:
                animationState.speed = propertyValue;
                break;
            case AnimationStateProperty.NormalizedTime:
                animationState.normalizedTime = propertyValue;
                break;
            case AnimationStateProperty.Weight:
                animationState.weight = propertyValue;
                break;
            default:
                break;
        }
	}

    #endregion
}

