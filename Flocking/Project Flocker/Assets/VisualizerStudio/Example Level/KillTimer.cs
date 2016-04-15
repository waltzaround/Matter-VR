using UnityEngine;
using System.Collections;

/// <summary>
/// This is a utility kill timer to kill game objects after a time has expired.
/// </summary>
[AddComponentMenu("Visualizer Studio/Utility/Kill Timer")]
public class KillTimer : MonoBehaviour
{
    /// <summary>
    /// This is the delay before killing this game object.
    /// </summary>
    public float killDelay = 10.0f;

    /// <summary>
    /// This is the internal timer for killing this game object.
    /// </summary>
    private float killTimer = 0;

    // Use this for initialization
    void Start()
    {
        killTimer = killDelay;
    }

    // Update is called once per frame
    void Update()
    {
        killTimer -= Time.deltaTime;
        if (killTimer <= 0.0f)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
