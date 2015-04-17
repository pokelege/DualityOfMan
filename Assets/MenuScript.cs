using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( Input.GetKey( KeyCode.Space ) ) Application.LoadLevel( 1 );
		if ( Input.GetKey( KeyCode.R ) ) Application.LoadLevel( "Credits" );
		if ( Input.GetKey( KeyCode.Escape ) ) Application.Quit();
	}
}
