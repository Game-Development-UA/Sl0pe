using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour {

    public Maze mazePrefab;

    // Custom Prefab
    public Endpoint endpointPrefab;

    private Maze currentMaze;

	void Start () {
        StartGame();
	}

	void Update () {
        
        // Allow user to restart game by pressing ESC
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Restart();
        }
	}

    private void StartGame()
    {
        currentMaze = Instantiate(mazePrefab) as Maze;
        currentMaze.Create(endpointPrefab);
    }

    private void Restart()
    {
        Destroy(currentMaze.gameObject);
        currentMaze.Destroy();
        StartGame();
    }
}
