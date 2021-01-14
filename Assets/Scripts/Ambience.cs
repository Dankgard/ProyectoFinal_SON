using UnityEngine;

public class Ambience : MonoBehaviour
{
    float altitud;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        FMODUnity.RuntimeManager.StudioSystem.getParameterByName("Altitud", out altitud);
    }

    void Update()
    {
        altitud = player.transform.position.y;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Altitud", altitud);
    }
}
