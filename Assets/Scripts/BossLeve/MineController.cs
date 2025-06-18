using UnityEngine;

public class MineController : MonoBehaviour
{
    public float lifetime = 10f;
    public ParticleSystem explosionEffect;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            other.GetComponent<PlayerMovmentOther>()?.Die();
            Destroy(gameObject);
        }
    }
}