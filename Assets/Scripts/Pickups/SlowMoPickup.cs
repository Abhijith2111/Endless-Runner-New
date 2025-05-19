using UnityEngine;

public class SlowMoPickup : MonoBehaviour
{

    [SerializeField] private float slowDuration = 3f;
    [SerializeField] private float timeScale = 0.5f; // 0.5 = 50% speed
    [SerializeField] private GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeController timeController = FindObjectOfType<TimeController>();
            if (timeController != null)
            {
                timeController.ActivateSlowMotion(slowDuration, timeScale);

                // Visual/Sound effects
                if (pickupEffect != null)
                    Instantiate(pickupEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
