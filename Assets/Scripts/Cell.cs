using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public IntVector2 coordinates;
    private CellEdge[] edges = new CellEdge[Directions.Count];

	public CellEdge GetEdge(Direction direction)
    {
        return edges[(int)direction];
    }

    public void SetEdge(Direction direction, CellEdge edge)
    {
        edges[(int)direction] = edge;
    }
}
