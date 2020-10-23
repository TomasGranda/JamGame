using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    public GameObject player;
    public GameObject projectile;
    public GameObject projectileClone;

    public float getMovementSpeed()
    {
        return this.movementSpeed;
    }

    public void setMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        setMovementSpeed(2.5F);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerShoot();
        playerResize();
    }

    // Player movement uses arrow keys to detect in which direction to move
    void playerMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(getMovementSpeed() * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-getMovementSpeed() * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, -getMovementSpeed() * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, getMovementSpeed() * Time.deltaTime, 0));
        }
    }

    void playerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectileClone = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), transform.rotation) as GameObject;
        }
    }

    void playerResize() {
       
    }
}
