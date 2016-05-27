using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float countdown;
    
    public GameObject flockerPrefab;
    public GameObject[] newFlockers;
    void Start()
    {
        countdown = 5.0f;
         newFlockers = new GameObject[100];
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
        {
            for (int i = 0; i < 80; i++)
            {
                // random starting locations
                Vector3 pos = new Vector3(Random.Range(globalFlock.fieldSize*-1, globalFlock.fieldSize),
                                          Random.Range(globalFlock.fieldSize * -1, globalFlock.fieldSize),
                                          Random.Range(globalFlock.fieldSize * -1, globalFlock.fieldSize));
                //create with set rotation and random location
                newFlockers[i] = (GameObject)Instantiate(flockerPrefab, pos, Quaternion.identity);
                Debug.Log("burterfry spawn");

                
            }

             countdown = Random.value * 5;
            
        }
    }
}
