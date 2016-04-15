using UnityEngine;
using System.Collections;

public class ControlNote4 : MonoBehaviour {

    public int startingPitch = 1;
    public int timeToDecrease = 5;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Hand"))
        {
            Debug.Log("banana");
            //GetComponent("audio");
            GetComponent<AudioSource>().Play();
           // GetComponent<AudioSource>().Loop();


            // Sende la OSC
        }
    }

    void OnTriggerExit(Collider other)
    {
        GetComponent<AudioSource>().Pause();
    }
}

