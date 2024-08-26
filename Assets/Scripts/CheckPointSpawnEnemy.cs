using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSpawnEnemy : MonoBehaviour
{
    public static CheckPointSpawnEnemy Instance;

    public List<Transform> Enemys = new List<Transform>();

    void Awake()
    {
        // Set up the singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keeps the instance across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Enemys.Clear(); // Clear the list to avoid duplicates

        // Populate the Enemys list with child transforms
        foreach (Transform t in transform)
        {
            Enemys.Add(t);
        }
    }
}
