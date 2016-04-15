using UnityEngine;
using System.Collections;

/// <summary>
/// This class should be attached to the game object that contains an audio source.  If enabled, it will replace 
/// the current clip on the audio source with the microphone input.
/// </summary>
[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Visualizer Studio/Utility/Microphone")]
public class VisMicrophone : MonoBehaviour
{
    public string microphoneDevice = "Default";

    void Start()
    {
        //make sure it's okay to start the microphone
        if (GetComponent<AudioSource>() && Microphone.devices != null && Microphone.devices.Length > 0)
        {
            //get index
            int index = 0;
            for (int i = 0; i < Microphone.devices.Length; i++)
            {
                if (Microphone.devices[i].Equals(microphoneDevice, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            //assign and start microphone and then mute the audio source
            GetComponent<AudioSource>().clip = Microphone.Start(Microphone.devices[index], true, 999, AudioSettings.outputSampleRate);
            GetComponent<AudioSource>().mute = true;

            //Wait for microphone to be ready
            while (!(Microphone.GetPosition(Microphone.devices[index]) > 0)) { }

            //start the audio source
            GetComponent<AudioSource>().Play();
        }
        else if (GetComponent<AudioSource>())
            Debug.LogWarning("No audio source was found, can't start microphone! You must attach thise script to the same Game Object as an Audio Source.");
        else if (Microphone.devices == null || Microphone.devices.Length <= 0)
            Debug.LogWarning("No microphone devices were found, can't start microphone!");
        else
            Debug.LogWarning("Unknown issue, can't start microphone!");
    }
}