using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    Transform playerTransform;
    Transform birdTransform;
    float distance;

    void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        birdTransform = GameObject.FindWithTag("Bird").GetComponent<Transform>();
        distance = Vector3.Distance(playerTransform.position, birdTransform.position);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DistanceToBird", Mathf.Min(30, distance));
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
