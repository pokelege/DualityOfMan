using UnityEngine;
using System.Collections;

public class Player2Controls : PlayerControls
{
	public KeyCode Up = KeyCode.UpArrow;
	public KeyCode Down = KeyCode.DownArrow;
	public KeyCode Left = KeyCode.LeftArrow;
	public KeyCode Right = KeyCode.RightArrow;
	public KeyCode Jump = KeyCode.RightShift;
	public KeyCode Punch = KeyCode.Slash;

	public void movePlayer( Player player, float velocity = 10 )
	{
		// player.punchCollider.GetComponent<PunchDetector>().punched
		AnimationHack ani = player.playerModel.GetComponent<AnimationHack>();
		if ( ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) && ani.finished )
			ani.setAnimation( AnimationHack.CurrentAnimation.Stand );
		Vector3 totalDirection = new Vector3();
		if ( Input.GetKey( Up ) ) totalDirection += player.camera.transform.forward;
		if ( Input.GetKey( Down ) ) totalDirection -= player.camera.transform.forward;
		if ( Input.GetKey( Punch ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Punch );
		totalDirection.y = 0;
		player.playerModel.rigidbody.AddForce( totalDirection.normalized * velocity );
		if ( player.collided && Input.GetKey( Jump ) ) player.playerModel.rigidbody.AddForce( Vector3.up * velocity );
		if ( totalDirection.Equals( Vector3.zero ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Stand );
		else if ( !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) player.playerModel.GetComponent<AnimationHack>().setAnimation( AnimationHack.CurrentAnimation.Run );
	}

	public void rotatePlayer( Player player, float velocity = 10 )
	{
		if ( Input.GetKey( Right ) )
		{
			player.transform.Rotate( 0, velocity, 0 );
		}
		if ( Input.GetKey( Left ) )
		{
			player.transform.Rotate( 0, -velocity, 0 );
		}
	}
	public void rotateCam( Player player, float velocity = 10 ) { }
}
