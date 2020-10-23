using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2.5f;

    public int maxLife = 100;

    public float currentLife = 100;

    public GameObject projectile;

    private GameObject projectileClone;

    void Update()
    {
        playerMovement();
        playerShoot();
    }

    // Player movement uses arrow keys to detect in which direction to move
    void playerMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, -movementSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, movementSpeed * Time.deltaTime, 0));
        }
    }

    void playerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectileClone = GameObject.Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        }
    }
}
