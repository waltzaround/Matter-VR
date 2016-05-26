using UnityEngine;
using System.Collections;

public class HandBehaviourV2 : MonoBehaviour
{

    //public string latestNote;
    public Renderer textRend;
    //public Renderer matterRend;
    private TextMesh textObj;
    public NoteGovernor controller;

    // Use this for initialization
    void Start()
    {
        textRend = GetComponent<Renderer>();
        //matterRend = GetComponent<Renderer> ();
        textObj = GetComponent<TextMesh>();
        NoteGovernor controller = gameObject.GetComponent<NoteGovernor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textObj.text = controller.playingNoteName;
        /*if (latestNote == " ") {
			matterRend.enabled = true;
		} else {
			matterRend.enabled = false;
		}*/

        /*if (textRend.enabled == true) {
			matterRend.enabled = false;
		} else if (textRend.enabled == false) {
			matterRend.enabled = true;
		}*/
    }
}
