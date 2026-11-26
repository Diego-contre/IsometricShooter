
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    public bool isGameOver = false;

    [Header("Statistics")]
    private int currentWave = 0;
    private int enemiesKilled = 0;
    private float startTime;
    private float survivalTime;

    private int bestWave = 0;

    [Header("UI References")]
    public GameObject gameOverPanel;
    public TMP_Text waveText;
    public TMP_Text enemiesKilledText;
    public TMP_Text survivalTimeText;
    public TMP_Text bestWaveText;

    void Awake()
    {
        // Crear una instancia única del GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Registrar el momento en que comienza la partida
        startTime = Time.time;

        // Recuperar la mejor oleada guardada
        bestWave = PlayerPrefs.GetInt("BestWave", 0);
    }

    // Registrar la oleada que comienza
    public void RegisterWave(int wave)
    {
        currentWave = wave;
    }

    // Registrar un enemigo eliminado
    public void RegisterEnemyKilled()
    {
        enemiesKilled++;
    }

    public void GameOver()
    {
        // Evitar ejecutar la derrota más de una vez
        if (isGameOver)
            return;

        isGameOver = true;

        // Calcular el tiempo de supervivencia
        survivalTime = Time.time - startTime;

        // Actualizar el récord si corresponde
        if (currentWave > bestWave)
        {
            bestWave = currentWave;

            PlayerPrefs.SetInt("BestWave", bestWave);
            PlayerPrefs.Save();
        }

        // Mostrar las estadísticas
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (waveText != null)
            waveText.text = "Oleada alcanzada: " + currentWave;

        if (enemiesKilledText != null)
            enemiesKilledText.text = "Enemigos eliminados: " + enemiesKilled;

        if (survivalTimeText != null)
        {
            int minutes = Mathf.FloorToInt(survivalTime / 60f);
            int seconds = Mathf.FloorToInt(survivalTime % 60f);

            survivalTimeText.text = string.Format(
                "Tiempo sobrevivido: {0:00}:{1:00}",
                minutes,
                seconds
            );
        }

        if (bestWaveText != null)
            bestWaveText.text = "Mejor oleada: " + bestWave;

        Debug.Log("GAME OVER");

        // Detener el tiempo del juego
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Restaurar el tiempo antes de reiniciar
        Time.timeScale = 1f;

        // Recargar la escena actual
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
