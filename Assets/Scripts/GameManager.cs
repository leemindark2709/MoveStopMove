using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject enemyPrefab; // Prefab of the enemy
    public int numEnemyAlive;
    public List<Transform> spawnPoints = new List<Transform>();

    private float spawnCooldown = 2f; // Cooldown between spawns
    private float lastSpawnTime; // Time of the last spawn
    public int NumEnemySpawn = 20;
    public int counyEnemy = 20;
    public Transform button;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("ButtonResum").transform;
        button.gameObject.SetActive(false);
        NumEnemySpawn = 20;
        numEnemyAlive = 0;
        counyEnemy = 20;
        lastSpawnTime = -spawnCooldown; // Allow spawning immediately at the start

        if (counyEnemy == 0)
        {
            PauseGame();
            return;
        }

        // Check if CheckPointSpawnEnemy.Instance is properly initialized
        if (CheckPointSpawnEnemy.Instance != null)
        {
            spawnPoints = CheckPointSpawnEnemy.Instance.Enemys;
        }
        else
        {
            Debug.LogError("CheckPointSpawnEnemy.Instance is not set.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is dead
        if (PlayerAttack.instance.isDead)
        {
            StartCoroutine(PauseGameAfterDelay(2.5f));
        }

        // If there are fewer than 6 enemies and the cooldown has passed, spawn a new enemy
        if (numEnemyAlive < 2 && Time.time - lastSpawnTime >= spawnCooldown && NumEnemySpawn > 0)
        {
            SpawnEnemy();
            numEnemyAlive += 1;
            lastSpawnTime = Time.time; // Update the last spawn time
        }
    }

    private IEnumerator PauseGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PauseGame();
    }

    private void PauseGame()
    {
        button.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }

    public void SpawnEnemy()
    {
        NumEnemySpawn -= 1;
        if (enemyPrefab == null)
        {
            Debug.LogError("enemyPrefab is not assigned.");
            return;
        }

        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("No spawn points available.");
            return;
        }

        // Select a random spawn point from the list
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform randomSpawnPoint = spawnPoints[randomIndex];

        // Instantiate an enemy prefab at the position and rotation of the random spawn point
        Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }

    public void DeleteAllEnemies()
    {
        // Find all objects with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Destroy each object
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
