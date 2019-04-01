using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Maze mazePrefab;

    private Vector2[] corners = new Vector2[4];
    private float[] rotations = new float[4];

	void Start () {
        corners[0] = new Vector2(mazePrefab.size.x / 2 - 0.5f, mazePrefab.size.z / 2 - 0.5f);
        corners[1] = new Vector2(-1 * mazePrefab.size.x / 2 + 0.5f, mazePrefab.size.z / 2 - 0.5f);
        corners[2] = new Vector2(-1 * mazePrefab.size.x / 2 + 0.5f, -1 * mazePrefab.size.z / 2 + 0.5f);
        corners[3] = new Vector2(mazePrefab.size.x / 2 - 0.5f, -1 * mazePrefab.size.z / 2 + 0.5f);

        rotations[0] = 180f;
        rotations[1] = 180f;
        rotations[2] = 0f;
        rotations[3] = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
