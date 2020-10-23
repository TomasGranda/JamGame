using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    public GameObject boss;

    public float spawnOffSet = 15;

    public float bossOrbitDistance = 0.5f;

    private GameObject bossInstance;

    void Start()
    {
        InitBossSpawn();
    }

    void InitBossSpawn()
    {
        IEnumerator myWaitCoroutine()
        {
            yield return new WaitForSeconds(spawnOffSet);

            SpawnBoss();


            yield return new WaitForSeconds(5);
        }
        StartCoroutine(myWaitCoroutine());
    }

    void SpawnBoss()
    {
        bossInstance = GameObject.Instantiate(boss, transform.position + Vector3.right * bossOrbitDistance, transform.rotation, transform);
    }
}
