using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    public Transform laneTransform;
    Vector3 spawnLocation, despawnLocation, tapLocation;
    

    // Start is called before the first frame update
    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
        spawnLocation = new Vector3(SongManager.songManagerInstance.noteSpawnX, transform.position.y, transform.position.z);
        despawnLocation = new Vector3(SongManager.songManagerInstance.noteDespawnX, transform.position.y, transform.position.z);
        tapLocation = new Vector3(SongManager.songManagerInstance.noteTapX, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstatiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstatiated / (SongManager.songManagerInstance.noteTime * 2));

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.Lerp(spawnLocation, tapLocation, (float)timeSinceInstatiated);//Vector3.Lerp(Vector3.right * SongManager.songManagerInstance.noteSpawnX, Vector3.right * SongManager.songManagerInstance.noteDespawnX, t);
            //transform.position = Vector3.Lerp(spawnLocation, despawnLocation, t);
            
        }
    }
}
 