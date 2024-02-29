using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour, IHandle<SoundUIMessage>
{

    public static SoundController instance;

    public AudioSource mainMusicAudioSource;
    public AudioSource auxMusicAudioSource;
    public AudioSource eventMusicAudioSource;

    public AudioMixerSnapshot eventSnapShot;
    public AudioMixerSnapshot idle;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        EventAggregator.Instance.Subscribe(this);
    }

    private void OnDestroy()
    {
        EventAggregator.Instance.Unsubscribe(this);
    }

    public IEnumerator PlayEventMusic(AudioClip clip)
    {
        eventSnapShot.TransitionTo(0.05f);
        yield return new WaitForSeconds(0.2f);
        eventMusicAudioSource.clip = clip;
        eventMusicAudioSource.Play();
        while (eventMusicAudioSource.isPlaying)
        {
            yield return null;
        }
        idle.TransitionTo(0.05f);
    }

    public IEnumerator PlayEventMusicThenStop(AudioClip clip)
    {
        eventSnapShot.TransitionTo(0.05f);
        yield return new WaitForSeconds(0.2f);
        mainMusicAudioSource.Stop();
        auxMusicAudioSource.Stop();

        eventMusicAudioSource.clip = clip;
        eventMusicAudioSource.Play();
        while (eventMusicAudioSource.isPlaying)
        {
            yield return null;
        }
        idle.TransitionTo(0.05f);
    }

    public IEnumerator PlayEventMusicThenRestart(AudioClip clip)
    {
        eventSnapShot.TransitionTo(0.05f);
        yield return new WaitForSeconds(0.2f);
        mainMusicAudioSource.Stop();
        auxMusicAudioSource.Stop();

        eventMusicAudioSource.clip = clip;
        eventMusicAudioSource.Play();
        while (eventMusicAudioSource.isPlaying)
        {
            yield return null;
        }
        idle.TransitionTo(0.05f);
        yield return new WaitForSeconds(0.2f);

        mainMusicAudioSource.Play();
        auxMusicAudioSource.Play();
    }
    
    public void Handle(SoundUIMessage message)
    {
        if (message != null)
        {
            if (message.senderSoundUIController.masterAudioSlider)
            {
                mainMusicAudioSource.volume = message.senderSoundUIController.masterAudioSlider.value;
                print(message.senderSoundUIController.masterAudioSlider.value);
            }
            if (message.senderSoundUIController.voiceAudioSlider)
            {
                auxMusicAudioSource.volume = message.senderSoundUIController.voiceAudioSlider.value;
            }
        }
    }
    
}
