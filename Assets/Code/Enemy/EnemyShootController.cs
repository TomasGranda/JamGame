using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    public float speed = 3;

    public float damage = 10;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "VerticalBorder":
            case "HorizontalBorder":
                Destroy(gameObject);
                break;
            case "Player":
                PlayerController playerController = other.GetComponent<PlayerController>();
                playerController.currentLife -= damage;
                Destroy(gameObject);
                other.GetComponents<AudioSource>()[2].Play();
                break;
        }
    }
}