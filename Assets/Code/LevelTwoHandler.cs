using UnityEngine;
using System.Collections;

public class LevelTwoHandler : MonoBehaviour {
	
	public GameObject rigidElevator;
	public GameObject curvedElevator;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(rigidElevator.GetComponent<Elevator>().GetTriggered() && curvedElevator.GetComponent<Elevator>().GetTriggered())
		{
			LoadNextLevel();
		}
	}
	
	void LoadNextLevel()
	{
		Application.LoadLevel( "LevelThree" );
	}
}
