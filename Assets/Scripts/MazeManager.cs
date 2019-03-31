using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        // Increase size of maze with level progression
        mazePrefab.size.x = 5 + currentLevel * 5;
        mazePrefab.size.z = 5 + currentLevel * 5;

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
