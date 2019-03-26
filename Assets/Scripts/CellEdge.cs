using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellEdge : MonoBehaviour {

    public Cell cell;
    public Cell otherCell;
    public Direction direction; 

    public void Initialize(Cell cell, Cell otherCell, Direction direction)
    {
        this.cell = cell;
        this.otherCell = otherCell;
        this.direction = direction;
        cell.SetEdge(direction, this);
        transform.parent = cell.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = direction.ToRotation();
    }
}
