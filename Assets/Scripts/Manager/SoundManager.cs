using UnityEngine;
using System.Collections;
using Assets.Scripts.Manager;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private AudioSource backingSound;

    [SerializeField]
    private AudioSource effectSound;

    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;
    
    public void PlayEffect(AudioClip clip)
    {
        effectSound.clip = clip;
        effectSound.Play();
    }
    public void PlayBackingSound(AudioClip clip)
    {
        backingSound.clip = clip;
        backingSound.Play();
    }
    public void StopBackgroundMusic()
    {
        backingSound.Stop();
    }
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        effectSound.pitch = randomPitch;
        effectSound.clip = clips[randomIndex];
        effectSound.Play();
    }
    public void TurnofAllAudio()
    {
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            if (audio != null)
            {
                if (audio.Equals(backingSound) || audio.Equals(effectSound))
                    break;
                audio.Stop();
            }
        }
    }
}
