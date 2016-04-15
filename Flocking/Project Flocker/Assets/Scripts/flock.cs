using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {
    public float speed = 0.1f;
    float rotSpeed = 4.0f;
    Vector3 averageHeading;
    Vector3 averagePos;
    float neighbourDist = 40.0f;

	// Use this for initialization
	void Start () {
        speed = Random.Range(0.5f, 3);
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0, 5) < 1)
            flockRules();
        transform.Translate(0, 0, Time.deltaTime * speed);
	}

    void flockRules()
    {
        GameObject[] gos;
        gos = globalFlock.allFlockers;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalpoint = globalFlock.goalPoint;

        float dist;
        float camDist;
        int groupSize = 0;
        foreach(GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                
                if(dist <= neighbourDist)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    if(dist<3.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    camDist = Vector3.Distance(Camera.main.transform.position, this.transform.position);
                    if (camDist < 30.0f)
                    {
                        vavoid = vavoid + (this.transform.position - Camera.main.transform.position);
                    }
                    if (camDist > 40.0f)
                    {

                        vavoid = vavoid * -1;
                    }

                    flock anotherFlock = go.GetComponent<flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }

              
            }
        }

       


        if (groupSize > 0)
        {
            vcenter = vcenter / groupSize + (goalpoint - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcenter + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    rotSpeed * Time.deltaTime);
        }

    }
}
