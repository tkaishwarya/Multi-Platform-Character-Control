using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isRunning;
    private bool isChangingScene;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Keyboard controls
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * (isRunning ? runSpeed : walkSpeed);
        rb.MovePosition(rb.position + movement * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Scene change voice command
        if (Input.GetKeyDown(KeyCode.C))
        {
            isChangingScene = true;
        }
    }

    void FixedUpdate()
    {
        // Check if grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if landed on ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void LateUpdate()
    {
        // Handle scene change
        if (isChangingScene)
        {
            SceneManager.LoadScene("OtherScene");
        }
    }
}
