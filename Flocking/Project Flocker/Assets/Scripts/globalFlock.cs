using UnityEngine;
using System.Collections;

public class globalFlock : MonoBehaviour
{

    public GameObject flockerPrefab;
    
    public static int flockerPop = 500;
    public static GameObject[] allFlockers;
    public static int fieldSize = 20;
    public static Vector3 goalPoint = Vector3.zero;
	// Use this for initialization
	void Start ()
    {
        allFlockers = new GameObject[flockerPop];
        for (int i = 0; i < flockerPop; i++)
        {
            // random starting locations
            Vector3 pos = new Vector3(Random.Range(-fieldSize, fieldSize),
                                      Random.Range(-fieldSize, fieldSize),
                                      Random.Range(-fieldSize, fieldSize));
            //create with set rotation and random location
            allFlockers[i] = (GameObject)Instantiate(flockerPrefab, pos, Quaternion.identity);
            Debug.Log("burterfry spawn");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        




        if (Random.Range(0,10000)< 50)
        {
            goalPoint = new Vector3(gameObject.transform.position.x, 
                                    gameObject.transform.position.y, 
                                    gameObject.transform.position.z);
        }
    }
}
