using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {

    public int xSize;
    public int ySize;
    public Cell cellPrefab;

    private Cell[,] cells;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Create()
    {
        cells = new Cell[xSize, ySize];
        for (int x = 0; x < xSize; ++x)
        {
            for (int y = 0; y < ySize; ++y)
            {
                CreateCell(x, y);
            }
        }
    }

    private void CreateCell(int x, int y)
    {
        Cell newCell = Instantiate(cellPrefab) as Cell;
        cells[x, y] = newCell;
        newCell.name = "Cell " + x + ", " + y;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x - xSize * 0.5f + 0.5f, 0.0f, y - ySize * 0.5f + 0.5f);
    }
}
