using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float value = 200;

    public float maxLife = 100;

    public float currentLife;

    public float rotationSpeed = 100;

    public float attackInterval = 3;

    private float moveInterval = 10;

    public float speed;

    public GameObject bossShoot;

    public GameObject bossSuperShoot;

    private GameObject player;

    private Vector3 movementDirection;

    private List<Transform> bossPositions = new List<Transform>();

    private int movePosition = 1;

    [HideInInspector]
    public bool destroy = false;


    public void CheckIfDestroy()
    {
        if (destroy)
        {
            GameMaster.Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        currentLife = maxLife;
        InitMovement();
        InitAttacks();
        player = GameObject.Find("Player");
        movementDirection = Vector3.right;

        bossPositions.Add(GameObject.Find("BossPositionLeft").transform);
        bossPositions.Add(GameObject.Find("BossPositionCenter").transform);
        bossPositions.Add(GameObject.Find("BossPositionRight").transform);
    }

    void Update()
    {
        CheckIfDestroy();
        if (!destroy)
        {
            if (transform.parent != null)
            {
                transform.parent.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);

                Vector3 eulerRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);

                var pivotPosition = new Vector2(bossPositions[movePosition].position.x, 0);
                var thisPositionX = new Vector2(transform.parent.position.x, 0);

                if (Vector2.Distance(pivotPosition, thisPositionX) > 4)
                {
                    movementDirection = (pivotPosition - thisPositionX).normalized;
                }
                else if (Vector2.Distance(pivotPosition, thisPositionX) < 0.3)
                {
                    movementDirection = Vector2.zero;
                }

                transform.parent.Translate(movementDirection * Time.deltaTime * speed, Space.World);
            }
        }
    }

    private void Attack()
    {
        System.Random rnd = new System.Random();
        var number = rnd.Next(1, 3);

        if (number == 1)
        {
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            GameObject.Instantiate(bossShoot, transform.position, Quaternion.Euler(eulerRotation.x, eulerRotation.y, 45));
            GameObject.Instantiate(bossShoot, transform.position, Quaternion.Euler(eulerRotation.x, eulerRotation.y, 15));
            GameObject.Instantiate(bossShoot, transform.position, Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0));
            GameObject.Instantiate(bossShoot, transform.position, Quaternion.Euler(eulerRotation.x, eulerRotation.y, -15));
            GameObject.Instantiate(bossShoot, transform.position, Quaternion.Euler(eulerRotation.x, eulerRotation.y, -45));

        }
        else
        {
            GameObject.Instantiate(bossSuperShoot, transform.position, transform.rotation);
        }
        GetComponents<AudioSource>()[0].Play();
    }

    private void InitAttacks()
    {
        IEnumerator myWaitCoroutine()
        {
            yield return new WaitForSeconds(attackInterval);

            Attack();

            StartCoroutine(myWaitCoroutine());
        }
        StartCoroutine(myWaitCoroutine());
    }

    private void InitMovement()
    {
        IEnumerator myWaitCoroutine()
        {
            yield return new WaitForSeconds(moveInterval);

            Move();

            StartCoroutine(myWaitCoroutine());
        }
        StartCoroutine(myWaitCoroutine());
    }

    private void Move()
    {
        if (movePosition == 2)
        {
            movePosition = 0;
        }
        else
        {
            movePosition++;
        }
    }
}
