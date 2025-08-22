using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // [SerializeField]
    public AudioClip defaultAmbience;
    public AudioClip destructionSound;
    public AudioClip unlockSound;

    private AudioSource track1, track2;
    private AudioSource destructionSoundSource;
    private AudioSource ouchSoundSource;
    private AudioSource hitSoundSource;
    private AudioSource deathSoundSource;
    private AudioSource unlockSoundSource;
    private bool isPlayingTrack1;
    private bool firstTime = true;

    public static AudioManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Start()
    {
        track1 = gameObject.AddComponent<AudioSource>();
        track2 = gameObject.AddComponent<AudioSource>();
        destructionSoundSource = gameObject.AddComponent<AudioSource>();
        hitSoundSource = gameObject.AddComponent<AudioSource>();
        ouchSoundSource = gameObject.AddComponent<AudioSource>();
        deathSoundSource = gameObject.AddComponent<AudioSource>();
        unlockSoundSource = gameObject.AddComponent<AudioSource>();
        isPlayingTrack1 = true;

        SwapTrack(defaultAmbience);
    }

    // Update is called once per frame
    public void SwapTrack(AudioClip newClip)
    {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(newClip));
        isPlayingTrack1 = !isPlayingTrack1;
    }

    public void ReturnToDefault()
    {
        SwapTrack(defaultAmbience);
    }

    public void PlayDestructionSound()
    {
        destructionSoundSource.PlayOneShot(destructionSound);
    }

    public void PlayOuchSound(AudioClip ouchSound)
    {
        ouchSoundSource.PlayOneShot(ouchSound);
    }

    public void PlayHitSound(AudioClip hitSound)
    {
        hitSoundSource.PlayOneShot(hitSound);
    }

    public void PlayDeathSound(AudioClip deathSound)
    {
        deathSoundSource.PlayOneShot(deathSound);
    }

    public void PlayUnlockSound()
    {
        unlockSoundSource.PlayOneShot(unlockSound);
    }

    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float fadeDuration = 2.0f;
        // float delayBeforeNewTrack = 5.0f; // Adjust the delay duration as needed
        float targetVolume = 0.8f; // Set the target volume to 0.8
        float timeElapsed = 0;

        if (firstTime)
        {
            track1.clip = newClip;
            track1.Play();
            firstTime = false;
            yield return null;
        }
        else {
            // Fade out the current track
        if (isPlayingTrack1)
        {
            track2.clip = newClip;
            track2.Play();

            while (timeElapsed < fadeDuration)
            {
                track2.volume = Mathf.Lerp(0, targetVolume, timeElapsed / fadeDuration);
                track1.volume = Mathf.Lerp(targetVolume, 0, timeElapsed / fadeDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track1.Stop();
        }
        else
        {
            track1.clip = newClip;
            track1.Play();

            while (timeElapsed < fadeDuration)
            {
                track1.volume = Mathf.Lerp(0, targetVolume, timeElapsed / fadeDuration);
                track2.volume = Mathf.Lerp(targetVolume, 0, timeElapsed / fadeDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track2.Stop();
        }
        }

    }

}
