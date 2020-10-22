using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float spawnInterval = 1;

    public GameObject enemy;

    void Start()
    {
        InitSpawn();
    }

    void Spawn()
    {
        GameObject.Instantiate(enemy, transform.position, transform.rotation);
    }

    void InitSpawn()
    {
        IEnumerator myWaitCoroutine()
        {
            yield return new WaitForSeconds(spawnInterval);

            Spawn();

            StartCoroutine(myWaitCoroutine());
        }
        StartCoroutine(myWaitCoroutine());
    }
}
