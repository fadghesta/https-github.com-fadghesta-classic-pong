using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float threshold = 0.1f; // Toleransi untuk "sejajar"
    public Transform ball;

    void FixedUpdate()
    {
        if (ball == null) return;

        float ballY = ball.position.y;
        float aiY = transform.position.y;

        // Jika bola di atas AI (dengan toleransi), bergerak naik
        if (ballY > aiY + threshold)
        {
            transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
        }
        // Jika bola di bawah AI (dengan toleransi), bergerak turun
        else if (ballY < aiY - threshold)
        {
            transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
        }
        // Jika sejajar, diam

        // Batasi agar AI tidak keluar layar
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}