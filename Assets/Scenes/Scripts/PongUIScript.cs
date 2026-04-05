using UnityEngine;
using TMPro; // Wajib untuk TextMeshPro

public class PongUIScript : MonoBehaviour
{
    [Header("Referensi UI Text")]
    public TextMeshProUGUI txtPlayerScore;
    public TextMeshProUGUI txtOpponentScore;
    public TextMeshProUGUI txtStatus; // Teks untuk "Press Space" atau "Winner"

    [Header("Referensi Data")]
    public GameManager gameManager;

    // Pastikan fungsi ini PUBLIC agar muncul di UnityEvent Inspector
    public void UpdatePlayerScoreDisplay()
    {
        if (gameManager != null && txtPlayerScore != null)
        {
            txtPlayerScore.text = gameManager.playerScore.ToString();
        }
    }

    public void UpdateOpponentScoreDisplay()
    {
        if (gameManager != null && txtOpponentScore != null)
        {
            txtOpponentScore.text = gameManager.opponentScore.ToString();
        }
    }

    // Fungsi gabungan untuk memudahkan update semua skor sekaligus
    public void UpdateAllScores()
    {
        UpdatePlayerScoreDisplay();
        UpdateOpponentScoreDisplay();
    }

    // Fungsi untuk mengatur tampilan instruksi/status
    public void SetStatusText(string message, bool active)
    {
        if (txtStatus != null)
        {
            txtStatus.text = message;
            txtStatus.gameObject.SetActive(active);
        }
    }
}