using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivating : MonoBehaviour
{
    [SerializeField]
    GameObject _Parent;
    [SerializeField]
    GameObject _Child;

    bool isActive=false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
        _Parent.SetActive(isActive);
        isActive = !isActive;
        }
    }
}
