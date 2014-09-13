using UnityEngine;
using System.Collections;

public class PunchDetector : MonoBehaviour
{
	public bool punched = false;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnCollisionEnter()
	{
		punched = true;
	}

	void OnCollisionExit()
	{
		punched = false;
	}
}
