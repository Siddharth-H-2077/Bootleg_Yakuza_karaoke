using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;
using UnityEditor.PackageManager;

public class SongManager : MonoBehaviour
{
    public SongManager instance;
    public AudioSource audioSource;
    public float songDelayInSeconds;
    public float inputDelayInMilliseconds;
    public string fileLocation;
    public float noteTime;
    public float noteSpawnX;
    public float noteTapX;
    public float noteDespawnX;
    public static MidiFile midiFile;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //Check if file path is url
        if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        {
            StartCoroutine(ReadFromWebsite());
        }
        else
        {
            ReadFromFile();
        }
    }

    //If file path is not a url
    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + '/' + fileLocation);
        GetDataFromMidi();
    }

    //If file path is a url
    private IEnumerator ReadFromWebsite()
    {
        using(UnityWebRequest www = UnityWebRequest.Get(Application.streamingAssetsPath + '/' + fileLocation))
        {
            yield return www.SendWebRequest();
            
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.result);
            }
            else
            {
                //Load dowmloaded data into array
                byte[] results = www.downloadHandler.data;
                //Load array into memory stream
                using (var stream = new MemoryStream(results))
                {
                    midiFile = MidiFile.Read(stream);
                    GetDataFromMidi();
                }
            }
        }

    }

    private void GetDataFromMidi()
    {
        //This stores the data in an iCollection
        var notes = midiFile.GetNotes(); 

        //creating an array to store notes instead of iCollection
        var array = new Note[notes.Count];

        notes.CopyTo(array, 0);
        Invoke(nameof(StartSong), songDelayInSeconds);
    }

    public void StartSong()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
