using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Time Settings")]
    public float maxTime = 300f; // Maximum level time in seconds
    public float elapsedTime = 0f;
    public bool isGameOver = false;

    [Header("UI")]
    public TextMeshProUGUI timerText; // Riferimento al testo UI

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // facoltativo
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
        // Potresti disattivare il timer UI o mostrarne uno rosso, ecc.
    }
}