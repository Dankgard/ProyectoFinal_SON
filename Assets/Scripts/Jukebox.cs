using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    FMODUnity.StudioEventEmitter emitter;

    public int button;
    float volumeInclination;

    void Start()
    {
        FMODUnity.RuntimeManager.StudioSystem.getParameterByName("VolumeInclination", out volumeInclination);
        emitter = GameObject.FindWithTag("Juxebox").GetComponent<FMODUnity.StudioEventEmitter>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FMODUnity.RuntimeManager.StudioSystem.getParameterByName("VolumeInclination", out volumeInclination);
            if (button == 1 && volumeInclination >= -75.0f)
            {
                volumeInclination -= 25.0f;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("VolumeInclination", volumeInclination);
            }
            else if (button == 2)
            {
                if (!emitter.IsPlaying())
                {
                    emitter.Play();
                }
                else
                {
                    emitter.Stop();
                }
            }
            else if (button == 3 && volumeInclination <= 75.0f)
            {
                volumeInclination += 25.0f;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("VolumeInclination", volumeInclination);
            }
        }
    }
}
    

    