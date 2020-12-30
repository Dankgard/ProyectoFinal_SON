using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    Transform playerTransform;
    Transform birdTransform;
    float distance;

    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        birdTransform = GameObject.FindWithTag("Bird").GetComponent<Transform>();
        distance = Vector3.Distance(playerTransform.position, birdTransform.position);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DistanceToBird", Mathf.Min(30, distance));
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
