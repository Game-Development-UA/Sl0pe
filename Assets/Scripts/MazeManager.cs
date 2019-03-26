using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour {

    public Maze mazePrefab;
    public Endpoint endpointPrefab;

    private Maze currentMaze;

	// Use this for initialization
	void Start () {
        StartGame();
	}
	
	// Update is called once per frame
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
