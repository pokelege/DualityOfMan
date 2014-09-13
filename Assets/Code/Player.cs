using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float health;
	public float velocity;
	public float rotateVelocity;
	public Camera camera;
	public GameObject playerModel;
	public GameObject punchCollider;
	public PlayerControls controls;
	public bool player2 = false;
	public bool collided = false;
	// Use this for initialization
	void Start ()
	{
		if ( player2 ) controls = new Player2Controls();
		else controls = new Player1Controls();
		controls.setTargetCamPos( camera.transform.position );
	}
	
	// Update is called once per frame
	void Update ()
	{
		controls.movePlayer( this, velocity );
	}
	void LateUpdate()
	{
		controls.rotateCam( this, 0.5f );
	}
	void OnCollisionEnter()
	{
		collided = true;
	}

	void OnCollisionExit()
	{
		collided = false;
	}
}