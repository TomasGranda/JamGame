using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2.5f;

    public int maxLife = 100;

    public float currentLife = 100;

    public GameObject projectile;

    public int maxProjectilesInScreen = 2;

    [HideInInspector]
    public bool isDestroyed = false;

    void Update()
    {
        if (currentLife > 0)
        {
            playerMovement();
            playerShoot();
        }
    }

    // Player movement uses arrow keys to detect in which direction to move
    void playerMovement()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(new Vector3(0, -movementSpeed * Time.deltaTime, 0));
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(new Vector3(0, movementSpeed * Time.deltaTime, 0));
        }
    }

    void playerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameObject.FindGameObjectsWithTag("PlayerProjectile").Length < maxProjectilesInScreen)
        {
            GameObject.Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            GetComponents<AudioSource>()[0].Play();

        }
    }

    public void TriggerDeadAnimation()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        GetComponents<AudioSource>()[1].Play();
    }
}
