
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public Transform player;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    [Header("Wave Settings")]
    public int startingEnemies = 5;
    public int enemiesPerWave = 2;
    public float initialWaitTime = 5f;
    public float breakTime = 5f;

    private int currentWave = 0;
    private int aliveEnemies = 0;

    void Start()
    {
        StartCoroutine(StartWaves());
    }

    IEnumerator StartWaves()
    {
        // Esperar antes de comenzar la primera oleada
        yield return new WaitForSeconds(initialWaitTime);

        while (!GameManager.Instance.isGameOver)
        {
            // Aumentar el número de oleada
            currentWave++;
            // Registrar la oleada en el GameManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.RegisterWave(currentWave);
            }

            // Calcular cuántos enemigos tendrá esta oleada
            int enemiesToSpawn = startingEnemies +
                                 (currentWave - 1) * enemiesPerWave;

            Debug.Log("Comienza la oleada " + currentWave +
                      " con " + enemiesToSpawn + " enemigos.");

            // Crear todos los enemigos de la oleada
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }

            // Esperar hasta que todos los enemigos sean eliminados
            yield return new WaitUntil(() =>
                aliveEnemies <= 0 || GameManager.Instance.isGameOver
            );

            // Comprobar si la partida terminó
            if (GameManager.Instance.isGameOver)
                yield break;

            Debug.Log("Oleada " + currentWave + " completada.");

            // Descanso antes de la siguiente oleada
            yield return new WaitForSeconds(breakTime);
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
            return;

        // Elegir un punto de aparición aleatorio
        Transform spawnPoint = spawnPoints[
            Random.Range(0, spawnPoints.Length)
        ];

        // Crear el enemigo
        GameObject enemy = Instantiate(
            enemyPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        // Asignar el jugador al sistema de persecución
        EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();

        if (enemyAI != null)
        {
            enemyAI.player = player;
        }

        // Conectar el enemigo con el administrador de oleadas
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.waveManager = this;
        }

        // Registrar un enemigo activo
        aliveEnemies++;
    }

    public void EnemyDefeated()
    {
        aliveEnemies--;
    }
}
