using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private GameManager manager;

    void Start() {
        manager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("OnTriggerEnter2D: " + other.name + " with tag: " + other.tag + ", my tag: " + gameObject.tag);
        if (other.CompareTag("Ball")) {
            manager.ScorePoint(gameObject.tag);
        }
    }
}