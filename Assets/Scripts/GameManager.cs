using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Game Manager found!");
            return;
        }

        instance = this;
    }
    #endregion


    public List<Transform> spawns = new List<Transform>();

    public GameObject enemyPrefab;
    public int waveNumber = 25;
    public float spawnDelay = 1;
    public TMP_Text pointsText;
    public int currentPoints = 0;

    float timeSinceSpawned = 0;
    int spawnedEnemies = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeSinceSpawned = spawnDelay;
        GivePoints(currentPoints);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceSpawned >= 0)
        {
            timeSinceSpawned -= Time.deltaTime;
        }

        if (timeSinceSpawned <= 0 && spawnedEnemies <= waveNumber)
        {
            timeSinceSpawned = spawnDelay;
            int spawn = Random.Range(0, spawns.Count);
            int randomEnemy = Random.Range(0, 2);
            if (randomEnemy == 0)
            {
                Ship tankShip = new ShipBuilder()
                    .SetPrefab(enemyPrefab)
                    .AssignSpeed(.0075f)
                    .AssignSize(2)
                    .AssignPoints(10)
                    .AssignHealth(10)
                    .Build(spawns[spawn].position, enemyPrefab.transform.rotation);
            }
            else
            {
                Ship fastShip = new ShipBuilder()
                    .SetPrefab(enemyPrefab)
                    .AssignSpeed(.015f)
                    .AssignSize(1)
                    .AssignPoints(3)
                    .AssignHealth(3)
                    .Build(spawns[spawn].position, enemyPrefab.transform.rotation);
            }
        }
    }

    public void GivePoints(int points)
    {
        currentPoints += points;
        pointsText.text = "Points: " + currentPoints.ToString();
    }
}
