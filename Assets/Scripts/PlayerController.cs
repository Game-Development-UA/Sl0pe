 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

    private Vector2[] corners = new Vector2[4];

    void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(6);
    }

    public void InstantiatePlayer(Maze currentMaze)
    {
        // Store locations of the 4 maze corners as Vector2's
        corners[0] = new Vector2(currentMaze.size.x / 2 - 0.5f, currentMaze.size.z / 2 - 0.5f);
        corners[1] = new Vector2(-1 * currentMaze.size.x / 2 + 0.5f, currentMaze.size.z / 2 - 0.5f);
        corners[2] = new Vector2(-1 * currentMaze.size.x / 2 + 0.5f, -1 * currentMaze.size.z / 2 + 0.5f);
        corners[3] = new Vector2(currentMaze.size.x / 2 - 0.5f, -1 * currentMaze.size.z / 2 + 0.5f);

        int cameraCorner = Random.Range(0, 4);

        // Regenerate camera corner if selection is the same as the endpoint 
        // Prevents start point and endpoint from being at the same location
        if (cameraCorner == currentMaze.GetEndpointCorner())
        {
            InstantiatePlayer(currentMaze);
        }
        else
        {
            transform.position = new Vector3(corners[cameraCorner].x, 0.5f, corners[cameraCorner].y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            RaycastHit hit;

            for (int i = 0; i < 4; ++i)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    if ((hit.collider.gameObject.tag == "Wall") && (hit.distance < 1f))
                    {
                        transform.Rotate(0f, 90f, 0f);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0f, 90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0f, -90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                if ((hit.distance > 1f) || ((hit.distance < 1f) && (hit.collider.gameObject.tag == "Endpoint")))
                {
                    transform.position = transform.position + transform.forward;
                }
            }
        }
    }
}
