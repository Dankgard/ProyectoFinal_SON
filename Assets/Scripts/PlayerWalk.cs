using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    float speed;

    private void Start()
    {
        speed = 34;
        FMODUnity.RuntimeManager.StudioSystem.getParameterByName("speed", out speed);
    }

    void Update()
    {

        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right") ||
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!GetComponent<FMODUnity.StudioEventEmitter>().IsPlaying())
                GetComponent<FMODUnity.StudioEventEmitter>().Play();

            /*if (Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("ASD");
                speed = 0;
            }
            else
                speed = 1;*/
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("speed", 18);
            
            Debug.Log(speed);
        }
        else
            GetComponent<FMODUnity.StudioEventEmitter>().Stop();
    }
}
