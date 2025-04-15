using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Time Settings")]
    public float maxTime = 300f; // Maximum level time in seconds
    public float elapsedTime = 0f;
    public bool isGameOver = false;

    [Header("UI")]
    public Text timerText; // <-- Usiamo Text normale qui
    public Text punteggioText; // Testo per visualizzare il punteggio

    private int punteggio = 0; // Punteggio totale del giocatore

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!isGameOver)
        {
            elapsedTime += Time.deltaTime;

            // Aggiorna il timer visivo
            UpdateTimerUI();

            if (elapsedTime >= maxTime)
            {
                EndGame();
            }
        }
    }

    private void UpdateTimerUI()
    {
        float timeLeft = Mathf.Max(0f, maxTime - elapsedTime);
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game Over: Time's up!");
    }

    public void AggiungiPunti(int punti)
    {
        punteggio += punti;
        AggiornaTestoPunteggio();
    }

    private void AggiornaTestoPunteggio()
    {
        punteggioText.text = $"Stipendio: {punteggio}";
    }

    public void AggiungiTempo(float tempoDaAggiungere)
    {
        elapsedTime -= tempoDaAggiungere;
        if (elapsedTime < 0f)
            elapsedTime = 0f;
    }
}
