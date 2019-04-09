using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    private float speed = .1f;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if ((hit.collider.gameObject.tag == "Wall") && (hit.distance < 0.25f))
            {
                int rotateDirection = Random.Range(0, 2);

                if (rotateDirection == 0)
                {
                    transform.Rotate(0f, 90f, 0f);
                }
                else
                {
                    transform.Rotate(0f, -90f, 0f);
                }
            }
            else if (hit.collider.gameObject.tag == "Zombie")
            {
                transform.Rotate(0f, 180f, 0f);
            }
            else
            {
                transform.position = transform.position + transform.forward * speed;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
