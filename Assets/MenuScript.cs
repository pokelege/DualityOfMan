using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	// Update is called once per frame
	void Update ()
	{
		if ( Input.GetButton("Start_P1") || Input.GetButton("Start_P2") ) Application.LoadLevel( 1 );
		if ( Input.GetButton("RTrigger_P1") || Input.GetButton("RTrigger_P2") ) Application.LoadLevel( "Credits" );
		if ( Input.GetButton("Punch_P1") || Input.GetButton("Punch_P2") ) Application.Quit();
	}
}
