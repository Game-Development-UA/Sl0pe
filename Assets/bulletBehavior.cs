using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (((collision.gameObject.tag == "Wall") || (collision.gameObject.tag == "Floor")) || (collision.gameObject.tag == "Zombie"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }
}
