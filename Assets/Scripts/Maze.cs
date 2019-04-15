using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maze : MonoBehaviour {

    public Cell cellPrefab;
    public IntVector2 size;
    public Passage passagePrefab;
    public Wall wallPrefab;
    public GameObject zombiePrefab;

    private Cell[,] cells;
    private Endpoint endpoint;
    private Vector2[] corners = new Vector2[4];
    private int endpointCorner; 

    public Cell GetCell(IntVector2 coordinates)
    {
        return cells[coordinates.x, coordinates.z];
    }

    public void Create(Endpoint endpointPrefab)
    {
        cells = new Cell[size.x, size.z];
        List<Cell> activeCells = new List<Cell>();
        DoFirstGenerationStep(activeCells);
        while(activeCells.Count > 0)
        {
            DoNextGenerationStep(activeCells);
        }

        corners[0] = new Vector2(size.x / 2 - 0.5f, size.z / 2 - 0.5f);
        corners[1] = new Vector2(-1 * size.x / 2 + 0.5f, size.z / 2 - 0.5f);
        corners[2] = new Vector2(-1 * size.x / 2 + 0.5f, -1 * size.z / 2 + 0.5f);
        corners[3] = new Vector2(size.x / 2 - 0.5f, -1 * size.z / 2 + 0.5f);

        endpointCorner = Random.Range(0, 4);

        endpoint = Instantiate(endpointPrefab, new Vector3(corners[endpointCorner].x, 3f, corners[endpointCorner].y), Quaternion.identity);
        AddZombies();
    }

    private void DoFirstGenerationStep(List<Cell> activeCells)
    {
        activeCells.Add(CreateCell(RandomCoordinates));
    }

    private void DoNextGenerationStep(List<Cell> activeCells)
    {
        int currentIndex = activeCells.Count - 1;
        Cell currentCell = activeCells[currentIndex];
        if(currentCell.IsFullyInitialized)
        {
            activeCells.RemoveAt(currentIndex);
            return;
        }
        Direction direction = currentCell.RandomUninitializedDirection;
        IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
        if (ContainsCoordinates(coordinates))
        {
            Cell neighbor = GetCell(coordinates);
            if (neighbor == null)
            {
                neighbor = CreateCell(coordinates);
                CreatePassage(currentCell, neighbor, direction);
                activeCells.Add(neighbor);
            }
            else
            {
                CreateWall(currentCell, neighbor, direction);
            }
        }
        else
        {
            CreateWall(currentCell, null, direction);
        }
    }

    private void CreatePassage(Cell cell, Cell otherCell, Direction direction)
    {
        Passage passage = Instantiate(passagePrefab) as Passage;
        passage.Initialize(cell, otherCell, direction);
        passage = Instantiate(passagePrefab) as Passage;
        passage.Initialize(otherCell, cell, direction.GetOpposite());
    }

    private void CreateWall(Cell cell, Cell otherCell, Direction direction)
    {
        Wall wall = Instantiate(wallPrefab) as Wall;
        wall.Initialize(cell, otherCell, direction);
        if(otherCell != null)
        {
            wall = Instantiate(wallPrefab) as Wall;
            wall.Initialize(otherCell, cell, direction.GetOpposite());
        }
    }

    private Cell CreateCell(IntVector2 coordinates)
    {
        Cell newCell = Instantiate(cellPrefab) as Cell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.coordinates = coordinates;
        newCell.name = "Cell " + coordinates.x + ", " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0.0f, coordinates.z - size.z * 0.5f + 0.5f);
        return newCell;
    }

    public IntVector2 RandomCoordinates
    {
        get
        {
            return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
        }
    }

    public bool ContainsCoordinates(IntVector2 coordinate)
    {
        return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
    }

    // Custom Method
    public void Destroy()
    {
        Destroy(endpoint.gameObject);
    }

    // Custom Method
    public int GetEndpointCorner()
    {
        return endpointCorner;
    }

    // Custom Method
    public Endpoint GetEndpoint()
    {
        return endpoint;
    }

    // Custom Method
    public void AddZombies()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i < currentLevel * 5; ++i)
        {
            float xPosition = Random.Range(-size.x / 2, size.x / 2);
            float zPosition = Random.Range(-size.z / 2, size.z / 2);

            if (xPosition < 1)
            {
                xPosition += 0.5f;
            }
            else
            {
                xPosition -= 0.5f;
            }

            if (zPosition < 1)
            {
                zPosition += 0.5f;
            }
            else
            {
                zPosition -= 0.5f;
                    
            }

            Instantiate(zombiePrefab, new Vector3(xPosition, 0f, zPosition), Quaternion.identity);
        }
    }
}
