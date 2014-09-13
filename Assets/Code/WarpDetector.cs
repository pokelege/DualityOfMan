using UnityEngine;
using System.Collections;

public class WarpDetector : MonoBehaviour {

	private bool ready = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public bool getReady()
	{
		return ready;
	}
	void OnTriggerEnter(Collider other)
	{
		ready = true;
	}
	void OnTriggerExit(Collider other)
	{
		ready = false;
	}
}
