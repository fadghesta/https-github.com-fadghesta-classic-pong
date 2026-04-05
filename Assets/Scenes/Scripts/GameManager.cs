using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public PongBall ball; // Referensi ke skrip bola
    public GameObject instructionText; // Referensi ke UI "Press Space"
    
    private bool isGameStarted = false; // Status awal game: Belum mulai

    void Update()
    {
        // Mengecek setiap frame apakah tombol Space ditekan
        // Dan hanya berfungsi JIKA game belum dimulai
        if (!isGameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        isGameStarted = true;
        
        // Sembunyikan teks instruksi saat main
        if (instructionText != null) 
            instructionText.SetActive(false);

        // Perintahkan bola untuk mulai bergerak
        ball.LaunchBall(); 
    }

    // Panggil fungsi ini saat terjadi Gol untuk mereset status
    public void ResetRound()
    {
        isGameStarted = false;
        
        // Munculkan kembali teks instruksi
        if (instructionText != null) 
            instructionText.SetActive(true);
            
        ball.StopBall();
    }
}