using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip buttonClick;
    // public AudioClip coin;
    // public AudioClip chest;
    public AudioSource background;
    public AudioSource effects;

    private void Awake()
    {
        Instance = this;
    }
    
    public void PlayAudio(SelectAudio selectAudio)
    {
        if (selectAudio.audioClip == Audio.ButtonClick)
        {
            effects.PlayOneShot(buttonClick);
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