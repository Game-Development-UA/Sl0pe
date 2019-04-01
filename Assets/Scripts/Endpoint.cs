using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour {

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
}
