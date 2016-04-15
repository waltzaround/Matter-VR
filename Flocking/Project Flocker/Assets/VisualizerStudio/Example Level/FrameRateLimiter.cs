using UnityEngine;
using System.Collections;

public class FrameRateLimiter : MonoBehaviour 
{
	void Start ()
    {
        //make sure the target frame rate is only 60 at most
        if (Application.targetFrameRate <= 0 || Application.targetFrameRate > 60)
            Application.targetFrameRate = 60;
	}
}
