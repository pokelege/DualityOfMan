using UnityEngine;
using System.Collections;

public class PunchDetector : MonoBehaviour
{
	public GameObject punched = null;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.CompareTag("Player"))
			punched = collision.gameObject;
	}

	void OnTriggerExit( Collider collision )
	{
		punched = null;
	}
}
