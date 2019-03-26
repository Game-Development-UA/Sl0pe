using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public IntVector2 coordinates;

    private CellEdge[] edges = new CellEdge[Directions.Count];
    private int initializedEdgeCount;

	public CellEdge GetEdge(Direction direction)
    {
        return edges[(int)direction];
    }

    public void SetEdge(Direction direction, CellEdge edge)
    {
        edges[(int)direction] = edge;
        initializedEdgeCount += 1;
    }

    public bool IsFullyInitialized
    {
        get
        {
            return initializedEdgeCount == Directions.Count;
        }
    }

    public Direction RandomUninitializedDirection
    {
        get
        {
            int skips = Random.Range(0, Directions.Count - initializedEdgeCount);
            for(int i = 0; i < Directions.Count; ++i)
            {
                if(edges[i] == null)
                {
                    if(skips == 0)
                    {
                        return (Direction)i;
                    }
                    skips -= 1;
                }
            }
            throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
        }
    }
}
