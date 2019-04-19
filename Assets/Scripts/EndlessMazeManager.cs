using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessMazeManager : MonoBehaviour
{
    public Maze mazePrefab;
    public PlayerController player;
    public Endpoint endpointPrefab;
    private Maze currentMaze;
    private PlayerController currentPlayer;
    private int currentLevel = 0;
    private float time = 300;

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        time -= Time.deltaTime;
        
        if (time < 0f)
        {
            SceneManager.LoadScene(6);
        }

        if (currentMaze.GetEndpoint().GetComplete())
        {
            currentMaze.DestroyEndpoint();
            Destroy(currentMaze.gameObject);
            Destroy(currentPlayer.gameObject);
            StartGame();
        }
    }

    private void StartGame()
    {
        currentLevel++;

        // Increase size of maze with level progression
        mazePrefab.size.x = 4 + currentLevel * 6;
        mazePrefab.size.z = 4 + currentLevel * 6;

        // Instantiate maze and player
        currentMaze = Instantiate(mazePrefab) as Maze;
        currentMaze.Create(endpointPrefab, true);
        currentPlayer = Instantiate(player) as PlayerController;
        currentPlayer.InstantiatePlayer(currentMaze);
    }
}
