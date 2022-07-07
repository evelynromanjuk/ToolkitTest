using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioManager : MonoBehaviour
{
    private bool isOn = false;
    private int soundID;
    private int trackNumber = 3;

    public AudioSource radio1;
    public AudioSource radio2;
    public AudioSource morseCode;

    private AudioSource currentTrack;

    private Dictionary<int, string> tracks;
    private Dictionary<int, AudioSource> radioTracks;
    // Start is called before the first frame update
    void Start()
    {
        radioTracks = new Dictionary<int, AudioSource>();

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
            currentTrack.Play();
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
