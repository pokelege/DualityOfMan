using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
	public bool pressed = false;
	public GameObject up, down;
	// Use this for initialization
	void Start()
	{
		up.SetActive( true );
		down.SetActive( false );
	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnCollisionEnter(Collision collision)
	{
		pressed = true;
		up.SetActive( false );
		down.SetActive( true );
	}
}
