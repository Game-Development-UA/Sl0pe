using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20f;
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            SceneManager.LoadScene(6);
        }
    }
    */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}
