using UnityEngine;

public class InvincibilityPickUp : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration = 5f;
    [SerializeField] private GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            PlayerInvincibility playerInvincibility = other.GetComponent<PlayerInvincibility>();

            if (playerInvincibility != null)
            {
                
                playerInvincibility.ActivateInvincibility(invincibilityDuration);

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
