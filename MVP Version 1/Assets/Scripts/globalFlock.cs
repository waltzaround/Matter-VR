using UnityEngine;
using System.Collections;

public class globalFlock : MonoBehaviour
{

    public GameObject flockerPrefab;
    
    public static int flockerPop = 150;
    public static GameObject[] allFlockers;
    public  static int fieldSize = 400;
    public static Vector3 goalPoint = Vector3.zero;
	// Use this for initialization
	void Start ()
    {
        allFlockers = new GameObject[flockerPop];
        for (int i = 0; i < flockerPop; i++)
        {
            // random starting locations
            Vector3 pos = new Vector3(Random.Range(-fieldSize+1100, fieldSize+1500),
                                      Random.Range(-fieldSize-395, fieldSize-395),
                                      Random.Range(-fieldSize+999, fieldSize+999));
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
            goalPoint = new Vector3 (Random.Range(-fieldSize+1300, fieldSize+1500),
                                      Random.Range(-15, fieldSize-15),
                                      Random.Range(-fieldSize+999, fieldSize+999));
        }
    }
}
