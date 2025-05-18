using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{

    [SerializeField] private float powerupDuration = 10f;
    [SerializeField] private GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovment playerJump = other.GetComponent<PlayerMovment>();

            if (playerJump != null)
            {
                playerJump.ActivateDoubleJump(powerupDuration);

                // Visual effect
                if (pickupEffect != null)
                {
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                }

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
