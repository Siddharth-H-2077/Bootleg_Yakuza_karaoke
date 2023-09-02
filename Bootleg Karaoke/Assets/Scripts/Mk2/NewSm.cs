using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

public class NewSm : MonoBehaviour
{
    public MidiFile midiFile;
    //public AudioSource audioSource;
    public string fileLocation;

    // Start is called before the first frame update
    void Start()
    {
        ReadFromFile(fileLocation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReadFromFile(string fileLocation)
    {
        using (var tokensReader = MidiFile.ReadLazy(Application.streamingAssetsPath + '/' + fileLocation))
        {
            for (MidiToken token; (token = tokensReader.ReadToken()) != null;)
            {
                switch (token)
                {
                    case MidiEventToken midiEventToken:
                        Debug.Log($"Event {midiEventToken.Event}");
                        break;
                }
            }
        }
    }
}
