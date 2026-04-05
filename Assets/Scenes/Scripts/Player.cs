using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;
    [SerializeField] private float speed = 5f; // Bisa diubah dari Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical"); // W/S atau Panah Atas/Bawah
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, moveInput * speed);
    }
}