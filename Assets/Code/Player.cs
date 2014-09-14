using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float health;
	public float velocity;
	public float jumpPower = 10;
	public float cameraRotateSpeed = 0.5f;
	public float cameraDistance = 5;
	public float cameraHeight = 3;
	public float cameraFocusHeight = 1;
	public float cameraSpeed = 25;
	public float cameraMaxDistance = 10;
	public float rotateVelocity;
	public Camera camera;
	public GameObject playerModel;
	public GameObject punchCollider;
	public AudioClip jumpSound;
	public AudioClip punchSound;
	public PlayerControls controls;
	public bool player2 = false;
	public bool collided = false;
	// Use this for initialization
	void Start ()
	{
		if ( player2 ) controls = new Player2Controls();
		else controls = new Player1Controls();
		controls.setTargetCamPos( camera.transform.position );
		Physics.gravity = new Vector3( 0, -20, 0 );
	}
	
	// Update is called once per frame
	void Update ()
	{
		controls.movePlayer( this, velocity, jumpPower, jumpSound, punchSound );
		if ( health <= 0 ) Application.LoadLevel(0) ;
	}
	void LateUpdate()
	{
		controls.rotateCam( this, cameraRotateSpeed, cameraDistance, cameraHeight, cameraFocusHeight,cameraSpeed, cameraMaxDistance  );
	}
	void OnCollisionStay( Collision collision )
	{
		if(collision.gameObject.CompareTag("Floor")) 
		collided = true;
	}

	void OnCollisionExit( Collision collision )
	{
		if ( collision.gameObject.CompareTag( "Floor" ) )
			collided = false;
	}
}