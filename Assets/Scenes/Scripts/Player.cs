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
        
        // Batasi paddle agar tidak keluar dari stage
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.5f, 4.5f), transform.position.z);
    }
}