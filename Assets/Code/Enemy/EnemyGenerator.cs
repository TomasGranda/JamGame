using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float spawnInterval = 1;

    public GameObject enemy;

    public GameObject enemySwarm;

    public float distanceBetweenEnemies = 1.5f;

    private GameObject currentEnemySwarm;

    private bool shouldSpawnEnemies = true;

    public int initialDirection = 1;

    void Start()
    {
        InitEnemiesSpawn();
        currentEnemySwarm = GameObject.Instantiate(enemySwarm, transform.position, transform.rotation);
        currentEnemySwarm.GetComponent<EnemySwarmController>().initialDirection = initialDirection;
    }

    void Update()
    {
        if (GetChildren(currentEnemySwarm).Count == 0 && shouldSpawnEnemies)
        {
            currentEnemySwarm.transform.position = transform.position;
            InitEnemiesSpawn();
        }

    }

    void SpawnEnemies()
    {
        // Top Row
        GameObject.Instantiate(enemy, currentEnemySwarm.transform.position + new Vector3(distanceBetweenEnemies, distanceBetweenEnemies, 0), transform.rotation, currentEnemySwarm.transform);
        GameObject.Instantiate(enemy, currentEnemySwarm.transform.position + new Vector3(0, distanceBetweenEnemies, 0), transform.rotation, currentEnemySwarm.transform);
        GameObject.Instantiate(enemy, currentEnemySwarm.transform.position + new Vector3(-distanceBetweenEnemies, distanceBetweenEnemies, 0), transform.rotation, currentEnemySwarm.transform);

        // Middle Row
        GameObject.Instantiate(enemy, currentEnemySwarm.transform.position + new Vector3(distanceBetweenEnemies, 0, 0), transform.rotation, currentEnemySwarm.transform);
        GameObject.Instantiate(enemy, currentEnemySwarm.transform.position + new Vector3(0, 0, 0), transform.rotation, currentEnemySwarm.transform);
        GameObject.Instantiate(enemy, currentEnemySwarm.transform.position + new Vector3(-distanceBetweenEnemies, 0, 0), transform.rotation, currentEnemySwarm.transform);
        StartCoroutine(myWaitCoroutine(1));
    }

    IEnumerator myWaitCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        shouldSpawnEnemies = true;
    }

    void InitEnemiesSpawn()
    {
        IEnumerator myWaitCoroutine()
        {
            yield return new WaitForSeconds(spawnInterval);

            if (shouldSpawnEnemies)
            {
                shouldSpawnEnemies = false;
                SpawnEnemies();
            }

            //StartCoroutine(myWaitCoroutine());
        }
        StartCoroutine(myWaitCoroutine());
    }

    List<GameObject> GetChildren(GameObject currentGameObject)
    {
        List<GameObject> children = new List<GameObject>();
        int childCount = currentGameObject.transform.childCount;
        for (var i = 0; i < childCount; i++)
        {
            children.Add(currentGameObject.transform.GetChild(i).gameObject);
        }

        return children;
    }
}
