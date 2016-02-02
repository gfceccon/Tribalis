using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameMusic))]
public class MusicPreset : MonoBehaviour
{
    public GameMusic music;
    public Society.StyleChoices style;
    private GameMusic musicPrefab;

    void Awake()
    {
        musicPrefab = GetComponent<GameMusic>();
    }

    public void Set()
    {
        if(style != Society.StyleChoices.None && music != null)
        {
            music.style = style;
            return;
        }
        if (musicPrefab)
        {
            if (musicPrefab.timestamps == null || musicPrefab.timestamps.Length == 0)
            {
                musicPrefab.timestamps = new float[1];
                musicPrefab.timestamps[0] = 0f;
                musicPrefab.mixerPattern = new Vector3[1];
                musicPrefab.mixerPattern[0] = new Vector3(1f, 1f, 1f);
            }
            else if (musicPrefab.timestamps.Length > musicPrefab.mixerPattern.Length)
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
