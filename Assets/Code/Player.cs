using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float velocity;
	public Camera camera;
	public GameObject playerModel;
	public PlayerControls controls;
	public bool player2 = false;
	// Use this for initialization
	void Start ()
	{
		if ( player2 ) controls = new Player2Controls();
		else controls = new Player1Controls();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (controls.movePlayer( this )) playerModel.GetComponent<AnimationHack>().setAnimation(AnimationHack.CurrentAnimation.Run);
		else playerModel.GetComponent<AnimationHack>().setAnimation( AnimationHack.CurrentAnimation.Stand );
		controls.rotatePlayer( this );
	}
}
