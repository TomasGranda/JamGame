using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 3;

    public float damage = 10;

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Enemy":
                Destroy(transform.gameObject);
                other.GetComponent<Animator>().SetTrigger("Dead");

                GameObject.Find("GameMaster").GetComponent<GameMaster>().OnEnemyDestroyed(other.gameObject);
                other.GetComponents<AudioSource>()[1].Play();
                break;
            case "Boss":
                Destroy(transform.gameObject);

                BossController bossController = other.GetComponent<BossController>();
                bossController.currentLife -= damage;
                if (bossController.currentLife <= 0)
                {
                    other.GetComponent<Animator>().SetTrigger("Dead");
                    GameObject.Find("GameMaster").GetComponent<GameMaster>().OnBossDestroyed(other.gameObject);
                    other.GetComponents<AudioSource>()[1].Play();

                }
                else
                {
                    other.GetComponents<AudioSource>()[2].Play();
                }
                break;
            case "VerticalBorder":
                Destroy(transform.gameObject);
                break;
        }
    }
}
