﻿using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Minifig;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    float speed;
    MinifigController controller;

    private void Start()
    {
        FMODUnity.RuntimeManager.StudioSystem.getParameterByName("Speed", out speed);
        controller = gameObject.GetComponent<MinifigController>();
    }

    void Update()
    {
        if ((Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right") ||
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            && !controller.isAirborne())
        {
            if (!GetComponent<FMODUnity.StudioEventEmitter>().IsPlaying())
                GetComponent<FMODUnity.StudioEventEmitter>().Play();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 1;
                controller.maxForwardSpeed = 26;
            }
            else
            {
                speed = 0;
                controller.maxForwardSpeed = 13;
            }

            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Speed", speed);
        }
        else
            GetComponent<FMODUnity.StudioEventEmitter>().Stop();
    }
}
