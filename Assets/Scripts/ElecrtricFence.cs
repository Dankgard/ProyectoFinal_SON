using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecrtricFence : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
