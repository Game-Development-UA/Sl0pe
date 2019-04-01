using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeManager : MonoBehaviour {

    public Maze mazePrefab;
    public PlayerController player;

    // Custom Prefab
    public Endpoint endpointPrefab;

    private Maze currentMaze;
    private PlayerController currentPlayer;

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

        // Instantiate maze and player
        currentMaze = Instantiate(mazePrefab) as Maze;
        currentMaze.Create(endpointPrefab);
        currentPlayer = Instantiate(player) as PlayerController;
        currentPlayer.InstantiatePlayer(currentMaze);
    }

    private void Restart()
    {
        Destroy(currentMaze.gameObject);
        currentMaze.Destroy();
        Destroy(currentPlayer.gameObject);
        StartGame();
    }
}
