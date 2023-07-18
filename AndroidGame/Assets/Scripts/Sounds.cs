using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource music;

    public void VolumeValue(float volume)
    {
        music.volume = volume;
    }
}
