using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int value = 50;

    public float shootInterval = 1;

    public GameObject enemyShoot;

    private float time;

    void Start()
    {
        InitShoot();
    }

    void Shoot()
    {
        GameObject.Instantiate(enemyShoot, transform.position, transform.rotation);
    }

    void InitShoot()
    {
        IEnumerator myWaitCoroutine()
        {
            yield return new WaitForSeconds(shootInterval);

            Shoot();

            StartCoroutine(myWaitCoroutine());
        }
        StartCoroutine(myWaitCoroutine());
    }
}
