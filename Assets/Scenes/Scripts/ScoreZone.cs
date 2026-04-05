using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private GameManager manager;

    void Start() {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball")) {
            manager.ScorePoint(gameObject.tag);
        }
    }
}