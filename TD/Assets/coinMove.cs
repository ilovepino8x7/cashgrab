using UnityEngine;

public class coinMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Start()
    {
        rb.linearVelocity = (Vector2)transform.right * moveSpeed;
        rb.angularVelocity = 0f;
    }
}
