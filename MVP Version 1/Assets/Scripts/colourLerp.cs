using UnityEngine;
using System.Collections;

public class colourLerp : MonoBehaviour {
    private Color colorStart;
    private Color colorEnd;
    public Renderer rend;
    public int countDown;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        colorStart = new Color(Random.value, Random.value, Random.value);
        colorEnd = new Color(Random.value, Random.value,Random.value);
        countDown = 6;
	}
	
	// Update is called once per frame
	void Update () {
        countDown--;

      /*  if(countDown == 0)
        {
        rend.material.color = Color.Lerp(colorStart, colorEnd, Mathf.PingPong(Time.time, 1));
            countDown = 6;
        }
       */
	}
}
