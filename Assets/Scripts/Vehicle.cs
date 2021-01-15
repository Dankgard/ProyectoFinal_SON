using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.LEGO.Minifig;

public class Vehicle : MonoBehaviour
{
    bool on = false;
    MinifigController player;
    int marcha = 0;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<MinifigController>();
    }

    // Update is called once per frame
    void Update()
    {
        tryUnmount();

        if (on)
        {
            if (marcha > 0 && Input.GetKeyDown(KeyCode.Z))
            {
                marcha--;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Marcha", marcha);
            }

            if (marcha < 3 && Input.GetKeyDown(KeyCode.X))
            {
                marcha++;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Marcha", marcha);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            on = true;
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            player.inputEnabled = false;
        }
    }

    void tryUnmount()
    {
        if(on && Input.GetKey(KeyCode.Space))
        {
            on = false;
            GetComponent<FMODUnity.StudioEventEmitter>().Stop();
            player.inputEnabled = true;
        }
    }
}
