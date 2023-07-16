using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreEvents : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject store;
    [SerializeField]
    private StoreEvents otherStore;
    [SerializeField]
    private GameObject otherStoreObject;

    private bool _shouldClose;

    private void Start()
    {
        _shouldClose = false;
    }

    private void Update()
    {
        if (store.transform.position.y <= -10.41 && _shouldClose)
        {
            _shouldClose = false;
            store.SetActive(false);
        }
    }

    public void StoreHandler()
    {
        if (_shouldClose)
        {
            animator.SetBool("CloseStore", true);
        }
        else
        {
            if(otherStoreObject.activeInHierarchy)
            {
                otherStore.StoreHandler();
            }

            _shouldClose = true;
            store.SetActive(true);
        }
    }
}
