using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public GameObject centerButton;
    public GameObject leftButton;
    public GameObject rightButton;

    GameObject player;

    bool centerTouched = false;
    bool leftTouched = false;
    bool rightTouched = false;

    FMODUnity.StudioEventEmitter emitter;

    float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        FMODUnity.RuntimeManager.StudioSystem.getParameterByName("Speed", out speed);
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;

        // CENTER BUTTON
        float dist = Vector3.Distance(playerPos, centerButton.transform.position);
        if (dist < 1 && !centerTouched)
        {
            if (!emitter.IsPlaying())
                emitter.Play();
            else
                emitter.Stop();

            centerTouched = true;
        } 

        if (dist > 1)
            centerTouched = false;

        // LEFT BUTTON
        dist = Vector3.Distance(playerPos, leftButton.transform.position);
        if (dist < 1 && !leftTouched)
        {
            speed += 10;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Speed", speed);
            leftTouched = true;
        }

        if (dist > 1)
            leftTouched = false;

        // RIGHT BUTTON
        dist = Vector3.Distance(playerPos, rightButton.transform.position);
        if (dist < 1 && !rightTouched)
        {
            speed -= 10;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Speed", speed);
            rightTouched = true;
        }

        if (dist > 1)
            rightTouched = false;
    }
}
