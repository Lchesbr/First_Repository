using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public Vector3 originalGrav;
    public float horizontalInput;
    public float moveSpeed = 10.0f;
    public float xBound = 10;
    public float jumpPower = 10;
    public float boostPower = 3;
    public float gravityMod;
    public bool isGrounded = true;
    public bool canBoost = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        originalGrav = Physics.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGrounded = false;
            canBoost = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && !isGrounded && canBoost)
        { 
            Physics.gravity *= boostPower;
            canBoost = false;
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Physics.gravity = originalGrav;
        }
    }

}
