using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !triggered)
        {
            triggered = true;
            GameObject.FindWithTag("Explosion").GetComponent<FMODUnity.StudioEventEmitter>().Play();
            GameObject.FindWithTag("ElectricFence").GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        }
    }
}
