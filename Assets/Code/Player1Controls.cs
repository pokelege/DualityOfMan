using UnityEngine;
using System.Collections;

public class Player1Controls : PlayerControls
{
	public KeyCode Up = KeyCode.W;
	public KeyCode Down = KeyCode.S;
	public KeyCode Left = KeyCode.A;
	public KeyCode Right = KeyCode.D;
	public KeyCode CamLeft = KeyCode.Q;
	public KeyCode CamRight = KeyCode.E;
	public KeyCode Jump = KeyCode.Space;
	public KeyCode Punch = KeyCode.R;
	public Vector3 lastPos;
	public void movePlayer(Player player, float velocity = 10)
	{
		// player.punchCollider.GetComponent<PunchDetector>().punched
		AnimationHack ani = player.playerModel.GetComponent<AnimationHack>();
		if ( ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) && ani.finished )
			ani.setAnimation( AnimationHack.CurrentAnimation.Stand );
		Vector3 totalDirection = new Vector3();
		if ( Input.GetKey( Up ) ) totalDirection += player.camera.transform.forward;
		if ( Input.GetKey( Down ) ) totalDirection -= player.camera.transform.forward;
		if ( Input.GetKey( Right ) )
		{
			totalDirection += player.camera.transform.right;
		}
		if ( Input.GetKey( Left ) )
		{
			totalDirection-= player.camera.transform.right;
		}
		if ( Input.GetKey( Punch ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Punch );
		totalDirection.y = 0;
		player.playerModel.rigidbody.AddForce( totalDirection.normalized * velocity );
		player.transform.LookAt( player.transform.position + totalDirection );
		if ( player.collided && Input.GetKey( Jump ) ) player.playerModel.rigidbody.AddForce( Vector3.up * velocity );
		if ( totalDirection.Equals( Vector3.zero ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Stand );
		else if( !ani.getAnimation().Equals(AnimationHack.CurrentAnimation.Punch)) player.playerModel.GetComponent<AnimationHack>().setAnimation( AnimationHack.CurrentAnimation.Run );
		lastPos = player.playerModel.transform.position;
	}

	public void rotatePlayer( Player player, float velocity = 10 )
	{
	}

	public void rotateCam(Player player, float velocity = 10)
	{
		player.camera.transform.position += player.playerModel.transform.position - lastPos;
		Vector3 vectorDirection = ( player.camera.transform.position - player.playerModel.transform.position ).normalized;
		vectorDirection.y = 0;
		vectorDirection = vectorDirection.normalized;
		if ( Input.GetKey( CamRight ) ) player.camera.transform.position += Vector3.Cross( vectorDirection, Vector3.up ) * velocity; //((Quaternion.AngleAxis(-velocity * Time.deltaTime, Vector3.up) * vectorDirection ) * 10)+ new Vector3( 0, 10, 0 );
		if ( Input.GetKey( CamLeft ) ) player.camera.transform.position += Vector3.Cross( Vector3.up, vectorDirection ) * velocity; //( ( Quaternion.Euler( 0, velocity * Time.deltaTime, 0 ) * vectorDirection ) * 10 ) + new Vector3( 0, 10, 0 );
		vectorDirection = ( player.camera.transform.position - player.playerModel.transform.position ).normalized;
		vectorDirection.y = 0;
		vectorDirection = vectorDirection.normalized;
		player.camera.transform.position = ( vectorDirection * 10 ) + new Vector3( 0, 10, 0 ) + player.playerModel.transform.position;
		player.camera.transform.LookAt( player.playerModel.transform.position + new Vector3( 0, 5, 0 ) );
	}
}
