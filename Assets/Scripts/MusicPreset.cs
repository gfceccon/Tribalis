using UnityEngine;
using System.Collections;

public class MusicPreset : MonoBehaviour
{
    public GameMusic music;
    public GameMusic musicPrefab;
    public Society.StyleChoices style;

    public void Set()
    {
        if (musicPrefab.timestamps.Length > musicPrefab.mixerPattern.Length)
        {
            Vector3[] newMixerPattern = new Vector3[musicPrefab.timestamps.Length];

            for (int i = 0; i < musicPrefab.mixerPattern.Length; i++)
                newMixerPattern[i] = musicPrefab.mixerPattern[i];
            for (int i = musicPrefab.mixerPattern.Length; i < musicPrefab.timestamps.Length; i++)
                newMixerPattern[i] = new Vector3(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));

            musicPrefab.mixerPattern = newMixerPattern;
        }
        else if (musicPrefab.timestamps.Length < musicPrefab.mixerPattern.Length)
        {

            Vector3[] newMixerPattern = new Vector3[musicPrefab.timestamps.Length];

            for (int i = 0; i < musicPrefab.mixerPattern.Length; i++)
                newMixerPattern[i] = musicPrefab.mixerPattern[i];

            musicPrefab.mixerPattern = newMixerPattern;
        }
        if(music)
        {
            music.timestamps = musicPrefab.timestamps;
            music.mixerPattern = musicPrefab.mixerPattern;
            music.fadeDuration = musicPrefab.fadeDuration;
            music.style = musicPrefab.style;

        }
    }
}
