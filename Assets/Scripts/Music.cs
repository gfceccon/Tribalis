using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Music : MonoBehaviour
{
    public AudioMixerGroup mercantile;
    public AudioMixerGroup mercantileBeat;
    public AudioMixerGroup military;
    public AudioMixerGroup militaryBeat;
    public AudioMixerGroup religious;
    public AudioMixerGroup religiousBeat;

    public float[] timestamps;
    public bool random = true;
    public Vector3[] mixerPattern;
    public float volume = 0.5f;
    public float fadeDuration = 5f;

    void Start()
    {
        if(timestamps.Length > mixerPattern.Length)
        {
            Vector3[] newMixerPattern = new Vector3[timestamps.Length];

            for (int i = 0; i < mixerPattern.Length; i++)
                newMixerPattern[i] = mixerPattern[i];
            for (int i = mixerPattern.Length; i < timestamps.Length; i++)
                newMixerPattern[i] = new Vector3(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));

            mixerPattern = newMixerPattern;
        }
        else if(timestamps.Length < mixerPattern.Length)
        {

        }
    }


}
