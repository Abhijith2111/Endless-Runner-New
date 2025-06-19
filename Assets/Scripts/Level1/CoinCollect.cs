using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //collect coins
        Knowledge.coinTally += 1;
        this.gameObject.SetActive(false);
    }
}
