using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int value = 50;

    public float shootInterval = 1;

    public GameObject enemyShoot;

    public int contactDamage = 20;

    [HideInInspector]
    public bool destroy = false;

    private float time;

    void Start()
    {
        InitShoot();
    }

    private void Update()
    {
        CheckIfDestroy();
    }

    void Shoot()
    {
        GameObject.Instantiate(enemyShoot, transform.position, transform.rotation);
        GetComponents<AudioSource>()[0].Play();
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

    public void CheckIfDestroy()
    {
        if (destroy)
        {
            GameMaster.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("Dead");
            other.gameObject.GetComponent<PlayerController>().currentLife -= contactDamage;
        }
    }
}
