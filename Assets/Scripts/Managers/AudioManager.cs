using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip buttonClick;
    public AudioClip coin;
    public AudioClip chest;
    public AudioClip artifact;
    public AudioSource background;
    public AudioSource effects;

    private void Awake()
    {
        Instance = this;
    }
    
    public void PlayAudio(SelectAudio selectAudio)
    {
        switch (selectAudio.audioClip)
        {
            case Audio.ButtonClick:
                effects.PlayOneShot(buttonClick);
                break;
            case Audio.Chest:
                effects.PlayOneShot(chest);
                break;
            case Audio.Coins:
                effects.PlayOneShot(coin);
                break;
            case Audio.Artifact:
                effects.PlayOneShot(artifact);
                break;
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        effects.PlayOneShot(clip);
    }


    public void TurnOffAudio(bool boolean)
    {
        background.mute = boolean;
    }

    public void TurnOffSounds(bool boolean)
    {
        effects.mute = boolean;
    }

}