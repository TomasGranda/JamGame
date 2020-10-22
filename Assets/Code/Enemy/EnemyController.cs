using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;

    public float shootInterval = 1;

    public GameObject enemyShoot;

    private CharacterController characterController;

    private float time;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        InitShoot();
    }

    void Update()
    {
        characterController.Move(Vector2.down * Time.deltaTime * speed);
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
