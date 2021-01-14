using UnityEngine;

public class AddCoinAmount : MonoBehaviour
{
    BoxCollider collider;
    float coinAmount;

    void Awake()
    {
        collider = GetComponent<BoxCollider>();
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
