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
        else if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
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

    void RestartGame()
    {
        playerScore = 0;
        opponentScore = 0;
        gameOver = false;
        isGameStarted = false;
        firstStart = true;
        if (instructionText != null) instructionText.SetActive(true);
        if (uiScript != null) uiScript.SetStatusText("", false);
        if (uiScript != null)
        {
            uiScript.UpdatePlayerScoreDisplay();
            uiScript.UpdateOpponentScoreDisplay();
        }
    }

    // Satu fungsi ScorePoint yang rapi
    public void ScorePoint(string zoneTag)
    {
        if (gameOver) return;

        Debug.Log("ScorePoint called with tag: " + zoneTag);

        // Sesuaikan nama Tag ini dengan yang ada di Unity kamu
        if (zoneTag == "OpponentZone") 
        {
            playerScore++;
            Debug.Log("Player Score: " + playerScore);
            if (uiScript != null) uiScript.UpdatePlayerScoreDisplay();
        }
        else if (zoneTag == "PlayerZone")
        {
            opponentScore++;
            Debug.Log("Opponent Score: " + opponentScore);
            if (uiScript != null) uiScript.UpdateOpponentScoreDisplay();
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
            string winner = playerScore >= 11 ? "PLAYER 1 WINS!" : "PLAYER 2 WINS!";
            Debug.Log("Game Over: " + winner);
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