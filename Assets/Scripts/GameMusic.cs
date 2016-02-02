using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

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
    private bool[] currentPlaying = new bool[(int)Society.StyleChoices.None];
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

        StartCoroutine(Crossfade(mixerPattern[0]));
    }

    private void SetStyle(Society.StyleChoices value)
    {
        _style = value;

        if (value == Society.StyleChoices.None)
            return;

        Vector3 vec = new Vector3(value == Society.StyleChoices.Mercantile ? 1f : 0f,
                                    value == Society.StyleChoices.Military ? 1f : 0f,
                                    value == Society.StyleChoices.Religious ? 1f : 0f);

        StartCoroutine(WaitCoroutineStop(vec));
    }

    float Cos(float x)
    {
        float cos;
        x += 1.57079632f;
        if (x > Mathf.PI)
            x -= 6.28318531f;

        cos = 1.27323954f * x + (x > 0f ? -0.405284735f : +0.405284735f) * x * x;

        if (cos < 0)
            cos = .225f * (cos * -cos - cos) + cos;
        else
            cos = .225f * (cos * cos - cos) + cos;
        return cos;
    }

    float CosineInterpolate(float y1, float y2, float mu)
    {
        float mu2;

        mu2 = (1 - Cos(mu * Mathf.PI)) / 2;
        return (y1 * (1 - mu2) + y2 * mu2);
    }

    private IEnumerator WaitCoroutineStop(Vector3 vec)
    {
        yield return new WaitUntil(() => ready);
        StartCoroutine(Crossfade(vec));
    }
    private IEnumerator WaitForNextTimestamp()
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
        Vector3 vec = new Vector3(0f, 0f, 0f);
        if (index != -1)
        {
            vec = vec + mixerPattern[index];
            while (least - mercantile.time > 0.25f)
                yield return null;
        }
        else
        {
            vec = vec + mixerPattern[0];
            while (mercantile.time > 0.25f)
                yield return null;
        }

        if (crossfading)
        {
            crossfading = false;
            StartCoroutine(WaitCoroutineStop(vec));
        }
        else
            StartCoroutine(Crossfade(vec));
    }

    IEnumerator Crossfade(Vector3 volumes)
    {
        crossfading = true;
        ready = false;

        float time = 0f;
        float mercantileVolume = mercantile.volume;
        float militaryVolume = military.volume;
        float religiousVolume = religious.volume;

        while (crossfading && time < fadeDuration)
        {
            if (!currentPlaying[(int)Society.StyleChoices.Mercantile] && !Mathf.Approximately(volumes.x, 0f))
            {
                float volumeUp = CosineInterpolate(0f, volumes.x, time / fadeDuration);
                mercantile.volume = volumeUp;
                mercantileBeat.volume = volumeUp;
            }
            else if (currentPlaying[(int)Society.StyleChoices.Mercantile] && Mathf.Approximately(volumes.x, 0f))
            {
                float volumeDown = CosineInterpolate(mercantileVolume, 0f, time / fadeDuration);
                mercantile.volume = volumeDown;
                mercantileBeat.volume = volumeDown;
            }

            if (!currentPlaying[(int)Society.StyleChoices.Military] && !Mathf.Approximately(volumes.y, 0f))
            {
                float volumeUp = CosineInterpolate(0f, volumes.y, time / fadeDuration);
                military.volume = volumeUp;
                militaryBeat.volume = volumeUp;
            }
            else if (currentPlaying[(int)Society.StyleChoices.Military] && Mathf.Approximately(volumes.y, 0f))
            {
                float volumeDown = CosineInterpolate(militaryVolume, 0f, time / fadeDuration);
                military.volume = volumeDown;
                militaryBeat.volume = volumeDown;
            }

            if (!currentPlaying[(int)Society.StyleChoices.Religious] && !Mathf.Approximately(volumes.z, 0f))
            {
                float volumeUp = CosineInterpolate(0f, volumes.z, time / fadeDuration);
                military.volume = volumeUp;
                militaryBeat.volume = volumeUp;
            }
            else if (currentPlaying[(int)Society.StyleChoices.Religious] && Mathf.Approximately(volumes.z, 0f))
            {
                float volumeDown = CosineInterpolate(religiousVolume, 0f, time / fadeDuration);
                religious.volume = volumeDown;
                religiousBeat.volume = volumeDown;
            }

            yield return null;
        }

        for (int i = 0; i < currentPlaying.Length; i++)
            currentPlaying[i] = false;

        currentPlaying[(int)Society.StyleChoices.Mercantile] = !Mathf.Approximately(volumes.x, 0f);
        currentPlaying[(int)Society.StyleChoices.Military] = !Mathf.Approximately(volumes.y, 0f);
        currentPlaying[(int)Society.StyleChoices.Religious] = !Mathf.Approximately(volumes.z, 0f);

        crossfading = false;
        ready = true;
    }


}
