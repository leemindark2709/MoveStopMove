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
    public bool isStart;
    public Transform button;
    public Transform Dead;
    public Transform InGame;
    public Transform TouchToContinue;
    public Transform SettingTouch;
    public Transform Home;
    public Transform Shop;
    public bool EndGame;
    public bool isPause;
    public Transform PLayer;
    public int numofSpawnDie=1;
    private void Awake()
    {
        Instance = this;
        Dead = GameObject.Find("Dead").transform;
        Dead.gameObject.SetActive(false);
        button = GameObject.Find("ButtonResum").transform;
        button.gameObject.SetActive(false);
        InGame = GameObject.Find("InGame").transform;
        InGame.gameObject.SetActive(false);
        TouchToContinue = GameObject.Find("TouchToContinue").transform;
        TouchToContinue.gameObject.SetActive(false);
        SettingTouch = GameObject.Find("SettingTouch").transform;
        SettingTouch.gameObject.SetActive(false);
        Home = GameObject.Find("Home").transform;
        Shop = GameObject.Find("Shop").transform;
        Shop.gameObject.SetActive(false);
        PLayer = GameObject.Find("Player").transform;
        
    }
    public void TurnOfComponentPlayer()
    {
        PLayer.Find("Canvas").gameObject.SetActive(false);
        PLayer.GetComponent<PlayerMovement>().enabled = false;

    } 
    public void TurnOnComponentPlayer()
    {
        PLayer.Find("Canvas").gameObject.SetActive(true);
        PLayer.GetComponent<PlayerMovement>().enabled = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        TurnOfComponentPlayer();
        SetUpCamera();
        isStart = false;
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
      
        if (EndGame&&numofSpawnDie==1)
        {
            StartCoroutine(DelayEnableDie());
        }

        // If there are fewer than 6 enemies and the cooldown has passed, spawn a new enemy
        if (numEnemyAlive < 6 && Time.time - lastSpawnTime >= spawnCooldown && NumEnemySpawn > 0&&isStart)
        {
            SpawnEnemy();
            numEnemyAlive += 1;
            lastSpawnTime = Time.time; // Update the last spawn time
        }
    }
    public void SetUpCamera()
    {
        
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.z = -0.6f;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.y = 0.36f;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offsetRotation.x = 39;
    }

    private IEnumerator PauseGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PauseGame();
    }
    private IEnumerator DelayEnableDie()
    {
        yield return new WaitForSeconds(2);

        // Kiểm tra liên tục cho đến khi numofSpawnDie == 1
        while (numofSpawnDie != 1)
        {
            yield return null; // Chờ đến khung hình tiếp theo
        }

        // Khi numofSpawnDie == 1, thực hiện các hành động sau
        if (PlayerAttack.instance.NumOfDead == 0)
        {
            Dead.gameObject.SetActive(true);
            numofSpawnDie = 0;
        }
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
