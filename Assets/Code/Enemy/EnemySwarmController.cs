using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwarmController : MonoBehaviour
{

    public float speed = 0.5f;

    public float movementPadding = 3;

    private Vector2 movementDirection;

    void Start()
    {
        movementDirection = Vector2.right;

    }

    void Update()
    {
        var distanceToBordersList = new List<float>();

        foreach (GameObject border in GameObject.FindGameObjectsWithTag("HorizontalBorder"))
        {
            var borderPositionX = new Vector2(border.transform.position.x, 0);
            var thisPositionX = new Vector2(transform.position.x, 0);

            if (Vector2.Distance(borderPositionX, thisPositionX) < movementPadding)
            {
                movementDirection *= -1;
            }
        }

        transform.Translate(movementDirection * Time.deltaTime * speed);

    }
}
