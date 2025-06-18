using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<PlayerMovmentOther>().Die();
            Destroy(gameObject);
        }
    }
}
