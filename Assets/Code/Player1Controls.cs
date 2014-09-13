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
	private Vector3 targetCameraPos;

	public void setTargetCamPos( Vector3 camPos )
	{
		targetCameraPos = camPos;
	}
	public void movePlayer(Player player, float velocity = 10, float jumpPower = 10)
	{
		// player.punchCollider.GetComponent<PunchDetector>().punched
		AnimationHack ani = player.playerModel.GetComponent<AnimationHack>();
		if ( ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) && ani.finished )
		{
			PunchDetector detector = player.punchCollider.GetComponent<PunchDetector>();
			if ( detector.punched != null ) detector.punched.GetComponent<Player>().health -= 1;
			ani.setAnimation( AnimationHack.CurrentAnimation.Stand );
		}
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
		if ( Input.GetKey( Punch ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Punch, false );
		totalDirection.y = 0;
		
		if ( totalDirection.Equals( Vector3.zero ) ) player.playerModel.rigidbody.velocity = new Vector3( 0, player.playerModel.rigidbody.velocity.y, 0 );
		else
		{
			Vector3 newVelo = totalDirection.normalized * velocity;
			player.playerModel.rigidbody.velocity = new Vector3(newVelo.x, player.playerModel.rigidbody.velocity.y, newVelo.z);
		}
		player.transform.LookAt( player.transform.position + totalDirection );
		if ( player.collided && Input.GetKey( Jump ) ) player.playerModel.rigidbody.AddForce( Vector3.up * jumpPower );
		if ( totalDirection.Equals( Vector3.zero ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Stand );
		else if( !ani.getAnimation().Equals(AnimationHack.CurrentAnimation.Punch)) player.playerModel.GetComponent<AnimationHack>().setAnimation( AnimationHack.CurrentAnimation.Run );
		lastPos = player.playerModel.transform.position;
	}

	public void rotateCam(Player player, float velocity = 10)
	{
		targetCameraPos += player.playerModel.transform.position - lastPos;
		Vector3 vectorDirection = ( targetCameraPos - player.playerModel.transform.position ).normalized;
		vectorDirection.y = 0;
		vectorDirection = vectorDirection.normalized;
		float lastCameraDistance = (player.camera.transform.position - player.playerModel.transform.position).magnitude;

		if ( Input.GetKey( CamRight ) )
		{
			targetCameraPos += Vector3.Cross( vectorDirection, Vector3.up ) * velocity;
			player.camera.transform.position += Vector3.Cross( vectorDirection, Vector3.up ) * velocity;
		}
		if ( Input.GetKey( CamLeft ) )
		{
			targetCameraPos += Vector3.Cross( Vector3.up, vectorDirection ) * velocity;
			player.camera.transform.position += Vector3.Cross( Vector3.up, vectorDirection ) * velocity;
		}
		player.camera.transform.position = (( player.camera.transform.position - player.playerModel.transform.position ).normalized * lastCameraDistance) + player.playerModel.transform.position;
		vectorDirection = ( targetCameraPos - player.playerModel.transform.position ).normalized;
		vectorDirection.y = 0;
		vectorDirection = vectorDirection.normalized;
		targetCameraPos = ( vectorDirection * 10 ) + new Vector3( 0, 10, 0 ) + player.playerModel.transform.position;
		player.camera.rigidbody.AddForce((targetCameraPos - player.camera.transform.position) * 25);
		player.camera.transform.LookAt( player.playerModel.transform.position + new Vector3( 0, 5, 0 ) );
	}
}
