using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float rotationSpeed = 100;

    void Update()
    {
        if (transform.parent != null)
        {
            transform.parent.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);

            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        }
    }
}
