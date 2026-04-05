using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    public Transform ball;

    void FixedUpdate()
    {
        if (ball == null) return;

        // AI hanya bergerak naik/turun mengikuti sumbu Y bola
        float targetY = Mathf.MoveTowards(transform.position.y, ball.position.y, speed * Time.fixedDeltaTime);
        
        // Batasi agar AI tidak keluar layar (Opsional)
        targetY = Mathf.Clamp(targetY, -4.5f, 4.5f);
        
        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
    }
}