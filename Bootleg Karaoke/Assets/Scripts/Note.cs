using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;

    // Start is called before the first frame update
    void Start()
    {
        timeInstantiated = SongManager.GetaudioSourceTime();        
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstatiated = SongManager.GetaudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstatiated / (SongManager.songManagerInstance.noteTime * 2));

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.Lerp(Vector3.right * SongManager.songManagerInstance.noteSpawnX, Vector3.right * SongManager.songManagerInstance.noteDespawnX, t);
        }
    }
}
 