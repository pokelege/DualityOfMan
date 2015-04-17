using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    private bool collided = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        collided = true;
    }

    public bool GetTriggered()
    {
        return collided;
    }
}
