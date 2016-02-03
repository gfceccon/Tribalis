using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class GameMusic : MonoBehaviour
{
    public AudioSource mercantile;
    public AudioSource military;
    public AudioSource religious;
    public AudioSource mercantileBeat;
    public AudioSource militaryBeat;
    public AudioSource religiousBeat;

    public float[] timestamps;
    public Vector3[] mixerPattern;
    public float fadeDuration = 5f;
    public Society.StyleChoices style
    {
        set
        {
            if (_style != value)
                SetStyle(value);
        }
        get
        {
            return _style;
        }
    }


    private Society.StyleChoices _style;
    private bool crossfading = false;
    private bool ready = true;

    void Start()
    {
        if (timestamps == null || timestamps.Length == 0)
        {
            timestamps = new float[1];
            timestamps[0] = 0f;
            mixerPattern = new Vector3[1];
            mixerPattern[0] = new Vector3(1f, 1f, 1f);
        }
        else if (timestamps.Length > mixerPattern.Length)
        {
            Vector3[] newMixerPattern = new Vector3[timestamps.Length];

            for (int i = 0; i < mixerPattern.Length; i++)
                newMixerPattern[i] = mixerPattern[i];
            for (int i = mixerPattern.Length; i < timestamps.Length; i++)
                newMixerPattern[i] = new Vector3(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));

            mixerPattern = newMixerPattern;
        }
        else if (timestamps.Length < mixerPattern.Length)
        {

            Vector3[] newMixerPattern = new Vector3[timestamps.Length];

            for (int i = 0; i < mixerPattern.Length; i++)
                newMixerPattern[i] = mixerPattern[i];

            mixerPattern = newMixerPattern;
        }

        mercantile.volume = mixerPattern[0].x;
        mercantileBeat.volume = mixerPattern[0].x;

        military.volume = mixerPattern[0].y;
        militaryBeat.volume = mixerPattern[0].y;

        religious.volume = mixerPattern[0].z;
        religiousBeat.volume = mixerPattern[0].z;
        
        StartCoroutine(Crossfade());
    }

    private void SetStyle(Society.StyleChoices value)
    {
        _style = value;

        if (value == Society.StyleChoices.None)
            return;

        StartCoroutine(CrossfadeStyle());
    }

    public static float CosineInterpolate(float y1, float y2, float mu)
    {
        float mu2;

        mu2 = (1 - Mathf.Cos(mu * Mathf.PI)) / 2;
        return (y1 * (1 - mu2) + y2 * mu2);
    }

    private IEnumerator CrossfadeStyle()
    {
        crossfading = false;
        yield return new WaitUntil(() => ready);
        timestamps = null;
        mixerPattern = null;
        StartCoroutine(Crossfade());
    }

    IEnumerator Crossfade()
    {
        crossfading = true;
        ready = false;


        while (crossfading)
        {
            Vector3 volumes = new Vector3(0f, 0f, 0f);
            if(timestamps != null)
            {
                int index = -1;
                float least = Mathf.Infinity;
                for (int i = 0; i < timestamps.Length; i++)
                {
                    if (timestamps[i] - fadeDuration > mercantile.time && timestamps[i] - fadeDuration - mercantile.time < least)
                    {
                        least = timestamps[i] - fadeDuration;
                        index = i;
                    }
                }

                if (index != -1)
                {
                    volumes = volumes + mixerPattern[index];
                    while (least - mercantile.time > 0.1f)
                        yield return null;
                }
                else
                {
                    volumes = volumes + mixerPattern[0];
                    while (mercantile.time > 0.1f)
                        yield return null;
                }
            }
            else
            {
                volumes.x = style == Society.StyleChoices.Mercantile ? 1f : 0f;
                volumes.y = style == Society.StyleChoices.Military ? 1f : 0f;
                volumes.z = style == Society.StyleChoices.Religious ? 1f : 0f;
            }


            float time = 0f;
            float mercantileVolume = mercantile.volume;
            float militaryVolume = military.volume;
            float religiousVolume = religious.volume;
            
            bool[] currentPlaying = new bool[(int)Society.StyleChoices.None];
            bool[] toPlay = new bool[(int)Society.StyleChoices.None];

            currentPlaying[(int)Society.StyleChoices.Mercantile] = !Mathf.Approximately(mercantileVolume, 0f);
            currentPlaying[(int)Society.StyleChoices.Military] = !Mathf.Approximately(militaryVolume, 0f);
            currentPlaying[(int)Society.StyleChoices.Religious] = !Mathf.Approximately(religiousVolume, 0f);

            toPlay[(int)Society.StyleChoices.Mercantile] = !Mathf.Approximately(volumes.x, 0f);
            toPlay[(int)Society.StyleChoices.Military] = !Mathf.Approximately(volumes.y, 0f);
            toPlay[(int)Society.StyleChoices.Religious] = !Mathf.Approximately(volumes.z, 0f);

            while (crossfading && time < fadeDuration)
            {
                float crossfadeVolume;
                if (toPlay[(int)Society.StyleChoices.Mercantile] && toPlay[(int)Society.StyleChoices.Military] && toPlay[(int)Society.StyleChoices.Religious])
                {
                    int choose = Random.Range(0, 2);
                    if (choose == 0)
                        volumes.z = 0f;
                    else if (choose == 1)
                        volumes.y = 0f;
                    else
                        volumes.x = 0f;
                }

                crossfadeVolume = GameMusic.CosineInterpolate(mercantileVolume, volumes.x, time / fadeDuration);
                mercantile.volume = crossfadeVolume;
                mercantileBeat.volume = crossfadeVolume;

                crossfadeVolume = GameMusic.CosineInterpolate(militaryVolume, volumes.y, time / fadeDuration);
                military.volume = crossfadeVolume;
                militaryBeat.volume = crossfadeVolume;

                crossfadeVolume = GameMusic.CosineInterpolate(religiousVolume, volumes.z, time / fadeDuration);
                religious.volume = crossfadeVolume;
                religiousBeat.volume = crossfadeVolume;


                yield return null;
                time += Time.deltaTime;
            }

        }
        crossfading = false;
        ready = true;
    }



    public void Stop()
    {
        crossfading = false;
        ready = false;
        mercantile.loop = false;
        mercantileBeat.loop = false;
        military.loop = false;
        militaryBeat.loop = false;
        religious.loop = false;
        religiousBeat.loop = false;
    }
}
