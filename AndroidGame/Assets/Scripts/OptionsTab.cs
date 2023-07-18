using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsTab : MonoBehaviour
{
    [SerializeField]
    private GameObject[] otherStoreObject;

    [SerializeField]
    private GameObject settingsUI;
    [SerializeField]
    private Animator settingsAnim;

    private bool _shouldClose;

    private void Start()
    {
        _shouldClose = false;
    }

    private void Update()
    {
        if (settingsUI.transform.position.y >= 9.3 && _shouldClose)
        {
            _shouldClose = false;
            settingsUI.SetActive(false);
        }
    }

    public void SettingsMovement()
    {
        if (_shouldClose)
        {
            settingsAnim.SetBool("SettingsOff", true);
        }
        else
        {
            if (StoresAreClosed())
            {
                settingsUI.SetActive(true);
                _shouldClose = true;
            }
        }
    }

    private bool StoresAreClosed()
    {
        return !otherStoreObject[0].activeInHierarchy && !otherStoreObject[1].activeInHierarchy;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
