using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour {
<<<<<<< HEAD:Assets/Endpoint.cs
//
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
=======

    private bool complete = false;

	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            complete = true;
        }
    }

    public bool GetComplete()
    {
        return complete;
    }
>>>>>>> Andy's_Development:Assets/Scripts/Endpoint.cs
}
