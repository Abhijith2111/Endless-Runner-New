using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioSource coinSound;

    void OnTriggerEnter(Collider other)
    {
        //collect coins
        coinSound.Play();
        this.gameObject.SetActive(false);
        Knowledge.coinTally += 1;
    }
}
