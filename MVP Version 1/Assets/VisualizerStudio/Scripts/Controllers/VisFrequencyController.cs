using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This controller is driven by being directly connected to a 
/// data group, allowing it to react to the music. 
/// </summary>
[AddComponentMenu("Visualizer Studio/Controllers/Frequency Controller")]
public class VisFrequencyController : VisBaseController, IVisDataGroupTarget
{
	#region Defaults Static Class
	
	/// <summary>
	/// This internal class holds all of the defaults of the VisFrequencyController class. 
	/// </summary>
	public new static class Defaults
	{			
		public const VisDataValueType subValueType = VisDataValueType.Sum;
		public const VisDataValueType finalValueType = VisDataValueType.Average; 
	}
	
	#endregion
		
	#region IVisDataGroupTarget Implementation
	
	/// <summary>
	///	This is the data group that this controller is targeting.
	/// </summary>
	//[HideInInspector()]
	[SerializeField()]
    private VisDataGroup dataGroup = null;

    /// <summary>
    /// This is the name of the last data group that was set to this base modifier
    /// </summary>
    [HideInInspector()]
    [SerializeField()]
    private string m_szLastDataGroupName = null;
	
	/// <summary>
	/// This property gets/sets the target data group for this controller. 
	/// </summary>
	public VisDataGroup DataGroup
	{
        get { return dataGroup; }
        set
        {
            dataGroup = value;
            if (dataGroup != null)
                m_szLastDataGroupName = dataGroup.dataGroupName;
            else
                m_szLastDataGroupName = null;
        }
    }

    /// <summary>
    /// This gets the name of the last data group that was set to this target.
    /// </summary>
    public string LastDataGroupName
    {
        get { return m_szLastDataGroupName; }
    }
	
	#endregion
	
	#region Public Member Variables
	
	/// <summary>
	/// This is the value type to pull from all of the sub data 
	/// groups on the target data group.  Such as the Maximum 
	/// of each sub data group values.  
    /// </summary>
    //[HideInInspector()]
	public VisDataValueType subValueType = Defaults.subValueType;
	
	/// <summary>
	/// This is the final value type to pull from the result of the 
	/// sub data groups.  Such as, the Average (final value type) 
	/// of the Maximums (sub value type).
    /// </summary>
    //[HideInInspector()]
	public VisDataValueType finalValueType = Defaults.finalValueType; 
	
	#endregion
	
	#region Init/Deinit Functions
	
	/// <summary>
	/// This function resets this controller to default values 
	/// </summary>
	public override void Reset()
	{
		base.Reset();		
		
		subValueType = Defaults.subValueType;
		finalValueType = Defaults.finalValueType; 
	}
	
	/// <summary>
	/// The main start function.
	/// </summary>
	public override void Start() 
	{
		base.Start();
		
		if (base.Manager == null)
				Debug.LogError("This controller must have a VisManager assigned to it in order to function.");
		if (dataGroup == null)
			Debug.LogError("This controller must have a VisDataGroup assigned to it in order to function. Please double check the spelling of the target data group.");
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
		if (dataGroup != null)
		{
			return dataGroup.GetValue(finalValueType, subValueType);
		}
		return base.GetCustomControllerValue();
	}
	
	#endregion
	
	#region Debug Functions
							
	/// <summary>
	/// This displays the debug information of this controller. 
	/// </summary>
	/// <param name="x">
	/// The x location to display this data group.
	/// </param>
	/// <param name="y">
	/// The y location to display this data group.
	/// </param>
	/// <param name="barWidth">
	/// This is the width in pixels of the debug bars.
	/// </param>
	/// <param name="barHeight">
	/// This is the height in pixels of the debug bars.
	/// </param>
	/// <param name="separation">
	/// This is the separation in pixels of the debug bars.
	/// </param>
	/// <param name="debugTexture">
	/// This is the texture used to display the debug information.
	/// </param>
	/// <returns>
	/// This is the rect of the of the debug information that was displayed.
	/// </returns>
	public override Rect DisplayDebugGUI(int x, int y, int barWidth, int barHeight, int separation, Texture debugTexture)
	{
		if (debugTexture != null)
		{
			int labelWidth = 150;
			int labelHeight = 20;
			int padding = 5;		
			int frameWidth = Mathf.Max(barWidth, labelWidth) + padding * 2;
			int frameHeight = padding * 2 + labelHeight * 5 + barHeight;	
			Rect frameRect = new Rect(x - padding, y - padding, frameWidth, frameHeight);

            GUI.BeginGroup(frameRect);
            GUI.color = new Color(0, 0, 0, 0.5f);
            GUI.DrawTexture(new Rect(0, 0, frameRect.width, frameRect.height), debugTexture);
            GUI.color = Color.white;
			GUI.Label(new Rect(padding, padding, labelWidth, labelHeight + 3), "Controller: \"" + controllerName + "\"");
			GUI.Label(new Rect(padding, padding + labelHeight, labelWidth, labelHeight + 3), "Data Group: \"" + (dataGroup != null ? dataGroup.dataGroupName : "NONE") + "\"");
			GUI.Label(new Rect(padding, padding + labelHeight * 2, labelWidth, labelHeight + 3), "Sub Type: \"" + subValueType + "\"");
			GUI.Label(new Rect(padding, padding + labelHeight * 3, labelWidth, labelHeight + 3), "Final Type: \"" + finalValueType + "\"");
			GUI.Label(new Rect(padding, padding + labelHeight * 4, labelWidth, labelHeight + 3), "VALUE: " + GetCurrentValue().ToString("F4"));
			
			float perc = ((m_fValue - MinValue) / (MaxValue - MinValue)) * 0.975f + 0.025f;
			if (dataGroup != null)
				GUI.color = dataGroup.debugColor;
			GUI.DrawTexture(new Rect(padding, padding + labelHeight * 5, (int)(((float)barWidth)*perc), barHeight), debugTexture);
				
			GUI.color = Color.white;
			GUI.DrawTexture(new Rect(0, 0, frameWidth, 1), debugTexture);
			GUI.DrawTexture(new Rect(0, frameHeight - 1, frameWidth, 1), debugTexture);
			GUI.DrawTexture(new Rect(0, 0, 1, frameHeight), debugTexture);
			GUI.DrawTexture(new Rect(frameWidth - 1, 0, 1, frameHeight), debugTexture);
			GUI.EndGroup();		
			
			return frameRect;
		}
		return new Rect(0,0,0,0);
	}
	
	#endregion
}
