using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoinAmount : MonoBehaviour
{
    BoxCollider collider;
    float coinAmount;

    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            collider.enabled = false;
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            FMODUnity.RuntimeManager.StudioSystem.getParameterByName("CoinAmount", out coinAmount);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("CoinAmount", coinAmount + 1);
        }
    }
}
