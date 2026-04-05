using UnityEngine;
using UnityEngine.Events; // WAJIB ADA agar UnityEvent bisa jalan

public class GameManager : MonoBehaviour
{
    public PongBall ball;
    public GameObject instructionText;
    public PongUIScript uiScript;
    
    public int playerScore = 0;
    public int opponentScore = 0;
    
    private bool isGameStarted = false;
    private bool gameOver = false;
    private bool firstStart = true;

    // BARIS INI yang memunculkan kotak di Inspector
    [Header("Event System")]
    public UnityEvent onScoreChanged;

    void Update()
    {
        if (!isGameStarted && !gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        isGameStarted = true;
        if (firstStart && instructionText != null)
        {
            instructionText.SetActive(false);
            firstStart = false;
        }

        if (ball != null) ball.LaunchBall();
    }

    // Satu fungsi ScorePoint yang rapi
    public void ScorePoint(string zoneTag)
    {
        if (gameOver) return;

        // Sesuaikan nama Tag ini dengan yang ada di Unity kamu
        if (zoneTag == "OpponentZone") 
        {
            playerScore++;
        }
        else if (zoneTag == "PlayerZone")
        {
            opponentScore++;
        }

        // Memanggil "Teriakan" Event (Observer Pattern)
        if (onScoreChanged != null)
        {
            onScoreChanged.Invoke();
        }

        // Cek Pemenang
        if (playerScore >= 11 || opponentScore >= 11)
        {
            gameOver = true;
            ball.StopBall();
            string winner = playerScore >= 11 ? "PLAYER 1 WINS!" : "OPPONENT WINS!";
            if (uiScript != null) uiScript.SetStatusText(winner + "\nPRESS SPACE TO RESTART", true);
        }
        else
        {
            if (ball != null)
            {
                ball.StopBall();
                ball.LaunchBall();
            }
        }
    }
}