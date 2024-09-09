using UnityEngine;
using System.Collections;

public class AudioFader : MonoBehaviour
{
    public AudioSource audioSource1; // Il primo AudioSource
    public AudioSource audioSource2; // Il secondo AudioSource
    public float fadeDuration = 2.0f; // Durata del fade in secondi
    public float maxVolume = 1.0f; // Volume massimo

    public void Fade()
    {
        // Avvia il fade tra i due AudioSource
        StartCoroutine(FadeBetweenAudioSources(audioSource1, audioSource2, fadeDuration));
    }

    private IEnumerator FadeBetweenAudioSources(AudioSource fromSource, AudioSource toSource, float duration)
    {
        float currentTime = 0.0f;
        float startVolumeFrom = fromSource.volume;
        float startVolumeTo = toSource.volume;

        // Assicurati che il secondo AudioSource inizi a suonare
        if (!toSource.isPlaying)
        {
            toSource.Play();
        }

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            fromSource.volume = Mathf.Lerp(startVolumeFrom, 0, currentTime / duration);
            toSource.volume = Mathf.Lerp(startVolumeTo, maxVolume, currentTime / duration);
            yield return null;
        }

        // Assicurati che il volume sia esattamente quello desiderato alla fine
        fromSource.volume = 0;
        toSource.volume = maxVolume;

        // Ferma il primo AudioSource se necessario
        fromSource.Stop();
    }
}
