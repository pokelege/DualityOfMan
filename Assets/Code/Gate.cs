using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour
{
	GameObject gate;
	GameObject[] buttons;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		var pressedAll = true;
		foreach ( GameObject i in buttons )
		{
			if ( !i.GetComponent<Button>().pressed ) { pressedAll = false; break; }
		}

		if ( pressedAll ) gate.SetActive( false );
	}
}
