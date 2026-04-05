using UnityEngine;
using TMPro;

public class PongUIScript : MonoBehaviour
{
    [Header("Referensi UI Text")]
    public TextMeshProUGUI txtPlayerScore;
    public TextMeshProUGUI txtOpponentScore;
    public TextMeshProUGUI txtStatus; // Teks untuk "Press Space" atau "Winner"

    [Header("Referensi Data")]
    public GameManager gameManager;

    public void UpdatePlayerScoreDisplay()
    {
        txtPlayerScore.text = gameManager.playerScore.ToString();
    }

    public void UpdateOpponentScoreDisplay()
    {
        txtOpponentScore.text = gameManager.opponentScore.ToString();
    }

    // Fungsi baru untuk mengatur tampilan instruksi
    public void SetStatusText(string message, bool active)
    {
        txtStatus.text = message;
        txtStatus.gameObject.SetActive(active);
    }
}