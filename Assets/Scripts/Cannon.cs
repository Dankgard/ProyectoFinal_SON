using UnityEngine;
using Unity.LEGO.Behaviours.Actions;

public class Cannon : MonoBehaviour
{
    GameObject player;
    float power;
    public ShootAction shoot;
    float lastShotTime;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        lastShotTime = Time.time;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                FMODUnity.RuntimeManager.StudioSystem.getParameterByName("Power", out power);
                power--;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Power", power);
            }

            if (Input.GetKey(KeyCode.E))
            {
                FMODUnity.RuntimeManager.StudioSystem.getParameterByName("Power", out power);
                power++;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Power", power);
            }
        }

        if ((power >= 20) && Time.time - lastShotTime > (10 - (power / 10)) * 0.1)
        {
            shoot.Fire();
            lastShotTime = Time.time;
        }
    }

}
