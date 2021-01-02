using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !triggered)
        {
            triggered = true;
            GameObject.FindWithTag("Explosion").GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
    }
}
