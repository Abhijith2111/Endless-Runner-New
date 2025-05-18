using System.Collections;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    private bool isInvincible = false;

    
    [SerializeField] private Material invincibleMaterial;
    private Material defaultMaterial;
    private Renderer playerRenderer;

    private void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
        defaultMaterial = playerRenderer.material;
    }

    public void ActivateInvincibility(float duration)
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine(duration));
        }
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;

        
        if (invincibleMaterial != null)
        {
            playerRenderer.material = invincibleMaterial;
        }

        

        yield return new WaitForSeconds(duration);

        
        isInvincible = false;
        playerRenderer.material = defaultMaterial;
    }

    
    public bool IsInvincible()
    {
        return isInvincible;
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
