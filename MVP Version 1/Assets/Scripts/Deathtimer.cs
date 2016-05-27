using UnityEngine;
using System.Collections;

public class Deathtimer : MonoBehaviour
{

    public float countdown;

    // Use this for initialization
    void Start()
    {
        countdown = 10.0f;

    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}