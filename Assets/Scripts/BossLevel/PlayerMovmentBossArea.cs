using UnityEngine;

public class PlayerMovmentBossArea : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 5f;
    [SerializeField] private float maxSpeed = 100f;
    [SerializeField] private float speedIncreaseInterval = 5f; 
    [SerializeField] private float speedIncrement = 1f;

    public float playerSpeed = 5;
    public float horizontalSpeed = 3;
    public float rightLimit = 6;
    public float leftLimit = -6;

    private float currentSpeed;
    private float timeSinceLastIncrease;
    private bool isGameRunning = true;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 10;

    public bool canDoubleJump { get; set; }
    bool hasDoubleJump;
    private float doubleJumpTimer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = initialSpeed;
        timeSinceLastIncrease = 0f;
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);

        if (!isGameRunning) return;

        timeSinceLastIncrease += Time.deltaTime;

        if (timeSinceLastIncrease >= speedIncreaseInterval && currentSpeed < maxSpeed)
        {
            IncreaseSpeed();
            timeSinceLastIncrease = 0f;
        }



        if (Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.transform.position.z > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (this.gameObject.transform.position.z < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
            }
        }

        //jump
        
        if(Physics.Raycast(transform.position, Vector3.down, 1.01f, LayerMask.GetMask("Ground")))
        {
            hasDoubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1.01f, LayerMask.GetMask("Ground")))
            {
               
                Jump();
            }

            else if(canDoubleJump && !hasDoubleJump)
            {
                hasDoubleJump = true;
                Jump();
            }
            
        }

        float movement = playerSpeed * Time.deltaTime;


        transform.Translate(Vector3.forward * movement);
    }

    private void IncreaseSpeed()
    {
        currentSpeed = Mathf.Min(currentSpeed + speedIncrement, maxSpeed);
        Debug.Log($"Speed increased to: {currentSpeed}");

        // You could add visual/audio feedback here
    }

    public void StopGame()
    {
        isGameRunning = false;
    }

    public void ActivateDoubleJump(float duration)
    {
        canDoubleJump = true;
        doubleJumpTimer = duration;
        // You could add visual feedback here
    }

    private void Jump()
    {
        
        rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (!GetComponent<PlayerInvincibility>().IsInvincible())
            {
                
            }
        }
    }
}
