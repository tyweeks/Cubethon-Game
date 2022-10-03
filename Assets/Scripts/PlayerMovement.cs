using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 5f;
    public float jumpRotationForce = 1.1f;

    private bool playerShouldJump = false;
    private bool playerCanMove = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerCanMove)
        {
            playerShouldJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerCanMove = true;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(0f, 0f, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") && playerCanMove)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") && playerCanMove)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (playerShouldJump)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            rb.AddTorque(jumpRotationForce, 0, 0, ForceMode.VelocityChange);
            playerCanMove = false;
            playerShouldJump = false;
        }

        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
