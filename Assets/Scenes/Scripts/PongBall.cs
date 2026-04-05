using UnityEngine;

public class PongBall : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Fungsi ini dipanggil oleh GameManager saat Space ditekan
    public void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = new Vector2(x, y) * speed;
    }

    public void StopBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
}