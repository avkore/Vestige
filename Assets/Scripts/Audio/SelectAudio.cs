using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAudio : MonoBehaviour
{
    public Audio audioClip;

    public void PlayAudio()
    {
        AudioManager.Instance.PlayAudio(this);
    }
}

[System.Serializable]
public enum Audio
{
    ButtonClick,
    Chest,
    Coins
}
