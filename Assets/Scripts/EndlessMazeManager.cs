using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMazeManager : MonoBehaviour
{
    public Maze mazePrefab;
    public PlayerController player;
    public Endpoint endpointPrefab;
    private Maze currentMaze;
    private PlayerController currentPlayer;
    private int currentLevel = 0;

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (currentMaze.GetEndpoint().GetComplete())
        {
            Destroy(currentMaze);
            Destroy(currentPlayer);
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
