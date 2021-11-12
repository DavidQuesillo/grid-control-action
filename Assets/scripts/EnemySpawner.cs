using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject toSpawn;
    [SerializeField]
    private float spawnRegularity = 3f;

    [SerializeField]
    private Transform[] rightMovingSpawnPoints = new Transform[4];
    [SerializeField]
    private Transform[] leftMovingSpawnPoints = new Transform[4];
    [SerializeField]
    private Transform[] downMovingSpawnPoints = new Transform[4];
    [SerializeField]
    private Transform[] upMovingSpawnPoints = new Transform[4];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {   
            int where = Random.Range(1, 5);
            
            if (where == 1)
            {
                GameObject enemy = Instantiate(toSpawn, rightMovingSpawnPoints[Random.Range(0, rightMovingSpawnPoints.Length)]);
                enemy.GetComponent<EnemyBase>().whereToAdvance = Vector2.right;
                enemy.GetComponent<EnemyShoot>().whereToShoot = Vector2.right;
            }
            if (where == 2)
            {
                GameObject enemy = Instantiate(toSpawn, leftMovingSpawnPoints[Random.Range(0, leftMovingSpawnPoints.Length)]);
                enemy.GetComponent<EnemyBase>().whereToAdvance = Vector2.left;
                enemy.GetComponent<EnemyShoot>().whereToShoot = Vector2.left;
            }
            if (where == 3)
            {
                GameObject enemy = Instantiate(toSpawn, downMovingSpawnPoints[Random.Range(0, downMovingSpawnPoints.Length)]);
                enemy.GetComponent<EnemyBase>().whereToAdvance = Vector2.down;
                enemy.GetComponent<EnemyShoot>().whereToShoot = Vector2.down;
            }
            if (where == 4)
            {
                GameObject enemy = Instantiate(toSpawn, upMovingSpawnPoints[Random.Range(0, upMovingSpawnPoints.Length)]);
                enemy.GetComponent<EnemyBase>().whereToAdvance = Vector2.up;
                enemy.GetComponent<EnemyShoot>().whereToShoot = Vector2.up;
            }
            yield return new WaitForSeconds(Random.Range(spawnRegularity, 5f));
        }
    }
}
