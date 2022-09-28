using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    void FixedUpdate()
    {
        rb.AddForce(0f, 0f, 2000f * Time.deltaTime);
    }
}
