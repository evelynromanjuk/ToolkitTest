using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioManager : MonoBehaviour
{
    private bool isOn = false;
    private int soundID;
    private int trackNumber = 3;

    public string track1 = "Never gonna give you up, never gonna let you doooown";
    public string track2 = "Caaan you feeel the loooove toniiiiight";
    public string track3 = "I say disco, you say party! Disco disco party party!";

    public AudioSource radio1;
    public AudioSource radio2;
    public AudioSource morseCode;

    private AudioSource currentTrack;

    private Dictionary<int, string> tracks;
    private Dictionary<int, AudioSource> radioTracks;
    // Start is called before the first frame update
    void Start()
    {
        tracks = new Dictionary<int, string>();
        radioTracks = new Dictionary<int, AudioSource>();

        tracks.Add(1, track1);
        tracks.Add(2, track2);
        tracks.Add(3, track3);

        radioTracks.Add(1, radio1);
        radioTracks.Add(2, radio2);
        radioTracks.Add(3, morseCode);

        currentTrack = radio1;
    }

    public void skipForward()
    {
        soundID += 1;
        if (soundID > trackNumber)
        {
            soundID = 1;
        }
        playTrack();
    }

    public void skipBack()
    {
        soundID -= 1;
        if (soundID < 1)
        {
            soundID = trackNumber;
        }
        playTrack();
    }

    public void playTrack()
    {
        if(isOn)
        {
            if(currentTrack != null)
                currentTrack.Stop();
            currentTrack = radioTracks[soundID];
            Debug.Log("Current Track: " + currentTrack.name);
            currentTrack.Play();
            Debug.Log(tracks[soundID]);
        }
    }

    public void turnOnOff()
    {
        if (isOn)
        {
            isOn = false;
            currentTrack.Stop();
            Debug.Log("Radio turned off");
        }
        else
        {
            isOn = true;
            if (currentTrack != null)
                currentTrack.Play();
            Debug.Log("Radio turned on");
        }
    }
   
}
