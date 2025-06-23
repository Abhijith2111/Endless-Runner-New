using UnityEngine;

public class PlayerMovment : MonoBehaviour
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
    private bool hasDoubleJump;
    private float doubleJumpTimer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = initialSpeed;
        timeSinceLastIncrease = 0f;
    }

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

        if (canDoubleJump)
        {
            doubleJumpTimer -= Time.deltaTime;
            if (doubleJumpTimer <= 0f)
            {
                canDoubleJump = false;
                hasDoubleJump = false;
                Debug.Log("Double jump expired.");
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.z > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.z < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
            }
        }


        if (Physics.Raycast(transform.position, Vector3.down, 1.01f, LayerMask.GetMask("Ground")))
        {
            hasDoubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1.01f, LayerMask.GetMask("Ground")))
            {
                Jump();
            }
            else if (canDoubleJump && !hasDoubleJump)
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
    }

    public void StopGame()
    {
        isGameRunning = false;
    }

    public void ActivateDoubleJump(float duration)
    {
        canDoubleJump = true;
        hasDoubleJump = false;
        doubleJumpTimer = duration;
        Debug.Log("Double jump activated!");
    }

    private void Jump()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.y = 0;
        rb.linearVelocity = velocity;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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