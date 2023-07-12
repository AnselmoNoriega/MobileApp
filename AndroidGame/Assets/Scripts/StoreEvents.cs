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

    public bool _shouldClose;
    public float temp;
    private void Start()
    {
        _shouldClose = false;
    }

    private void Update()
    {
        if (store.transform.position.y <= -9 && _shouldClose)
        {
            _shouldClose = false;
            store.SetActive(false);
        }

        temp = store.transform.position.y;
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
