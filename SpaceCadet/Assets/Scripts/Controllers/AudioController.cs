using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioMixerGroup mixerGroup;
    public string exposedParam;
    public float targetVolume = 1f;

    private float duration = .8f;
    public bool muted = false;

    private void Start()
    {
        muted = PlayerPrefs.GetInt("MutedValue") == 1 ? true : false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            muted = !muted;            

            if (muted)
                targetVolume = 0;
            else
                targetVolume = 1;

            PlayerPrefs.SetInt("MutedValue", muted ? 1 : 0);

            StartCoroutine(StartFade());
        }
    }

    public IEnumerator StartFade()
    {
        float currentTime = 0;
        float currentVol;
        mixerGroup.audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            mixerGroup.audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }
}
