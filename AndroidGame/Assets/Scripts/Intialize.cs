using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Intialize : MonoBehaviour
{
    [SerializeField]
    private Upgrades data;

    private void Awake()
    {
        data.Deserialize();
    }

    private void OnApplicationQuit()
    {
        data.SeerializeData();
    }
}
