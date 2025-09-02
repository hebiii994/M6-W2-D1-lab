using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    //easy

    public void PlaySound(AudioClip clip)
    {
        Debug.Log($"Play {clip.name}");
    }
}


