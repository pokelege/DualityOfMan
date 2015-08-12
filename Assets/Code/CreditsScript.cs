using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour 
{
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton("Punch_P1") || Input.GetButton("Punch_P2")) Application.LoadLevel( "Menu" );
	}
}
