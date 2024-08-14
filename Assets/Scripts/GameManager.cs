using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject enemyPrefab; // Prefab of the enemy
    public int numEnemy;
    public List<Transform> spawnPoints = new List<Transform>();

    private float spawnCooldown = 2f; // Cooldown between spawns
    private float lastSpawnTime; // Time of the last spawn

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        numEnemy = 0;
        lastSpawnTime = -spawnCooldown; // Allow spawning immediately at the start

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
        // If there are fewer than 8 enemies and the cooldown has passed, spawn a new enemy
        if (numEnemy < 8 && Time.time - lastSpawnTime >= spawnCooldown)
        {
            SpawnEnemy();
            numEnemy += 1;
            lastSpawnTime = Time.time; // Update the last spawn time
        }
    }

    public void SpawnEnemy()
    {
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

        // Chọn một điểm spawn ngẫu nhiên từ danh sách
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform randomSpawnPoint = spawnPoints[randomIndex];

        // Instantiate một enemy prefab tại vị trí và rotation của điểm spawn ngẫu nhiên
        Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }

    public void DeleteAllEnemies()
    {
        // Tìm tất cả các đối tượng có tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Xóa từng đối tượng
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
