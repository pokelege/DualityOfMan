using UnityEngine;
using System.Collections;

public class Player2Controls : PlayerControls
{
	public Vector3 lastPos;
	private Vector3 targetCameraPos;

	public void setTargetCamPos( Vector3 camPos )
	{
		targetCameraPos = camPos;
	}
	public void movePlayer( Player player, float velocity = 10, float jumpPower = 10, AudioClip jumpSound = null, AudioClip punchSound = null )
	{
		// player.punchCollider.GetComponent<PunchDetector>().punched
		AnimationHack ani = player.playerModel.GetComponent<AnimationHack>();
		if ( ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) && ani.finished )
		{
			PunchDetector detector = player.punchCollider.GetComponent<PunchDetector>();
			if ( detector.punched != null ) detector.punched.GetComponent<Player>().health -= 1;
			if ( punchSound != null ) player.audio.PlayOneShot( punchSound );
			ani.setAnimation( AnimationHack.CurrentAnimation.Stand );
		}
		Vector3 totalDirection = new Vector3();
        totalDirection += player.camera.transform.forward * Input.GetAxis("Vertical_P2");
        totalDirection += player.camera.transform.right * Input.GetAxis("Horizontal_P2");

        Debug.Log(Input.GetAxis("Vertical_P2"));

		if ( Input.GetButton( "Punch_P2" ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Punch, false );
		totalDirection.y = 0;

		if ( totalDirection.Equals( Vector3.zero ) ) player.playerModel.rigidbody.velocity = new Vector3( 0, player.playerModel.rigidbody.velocity.y, 0 );
		else
		{
			Vector3 newVelo = totalDirection.normalized * velocity;
			player.playerModel.rigidbody.velocity = new Vector3( newVelo.x, player.playerModel.rigidbody.velocity.y, newVelo.z );
		}
		player.transform.LookAt( player.transform.position + totalDirection );
		if ( player.collided && Input.GetButton( "Jump_P2" ) )
		{
			player.playerModel.rigidbody.AddForce( Vector3.up * jumpPower );
			if ( jumpSound != null ) player.audio.PlayOneShot( jumpSound );
		}
		if ( totalDirection.Equals( Vector3.zero ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Stand );
		else if ( !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) player.playerModel.GetComponent<AnimationHack>().setAnimation( AnimationHack.CurrentAnimation.Run );
		lastPos = player.playerModel.transform.position;
	}

	public void rotateCam( Player player, float velocity = 10, float cameraDistance = 5, float cameraHeight = 3, float cameraFocusHeight = 3, float cameraSpeed = 25, float cameraMaxDistance = 10 )
	{
		targetCameraPos += player.playerModel.transform.position - lastPos;
		Vector3 vectorDirection = ( targetCameraPos - player.playerModel.transform.position ).normalized;
		vectorDirection.y = 0;
		vectorDirection = vectorDirection.normalized;
		float lastCameraDistance = ( player.camera.transform.position - player.playerModel.transform.position ).magnitude;

        if (Input.GetAxis("CamHorizontal_P2") > 0)
        {
            targetCameraPos += Vector3.Cross(vectorDirection, Vector3.up) * velocity;
            player.camera.transform.position += Vector3.Cross(vectorDirection, Vector3.up) * velocity;
        }
        if (Input.GetAxis("CamHorizontal_P2") < 0)
        {
            targetCameraPos += Vector3.Cross(Vector3.up, vectorDirection) * velocity;
            player.camera.transform.position += Vector3.Cross(Vector3.up, vectorDirection) * velocity;
        }
		player.camera.transform.position = ( ( player.camera.transform.position - player.playerModel.transform.position ).normalized * lastCameraDistance ) + player.playerModel.transform.position;
		vectorDirection = ( targetCameraPos - player.playerModel.transform.position ).normalized;
		vectorDirection.y = 0;
		vectorDirection = vectorDirection.normalized;
		targetCameraPos = ( vectorDirection * cameraDistance ) + new Vector3( 0, cameraHeight, 0 ) + player.playerModel.transform.position;
		if ( ( player.camera.transform.position - player.playerModel.transform.position ).magnitude > cameraMaxDistance ) player.camera.transform.position = targetCameraPos;
		else player.camera.rigidbody.AddForce( ( targetCameraPos - player.camera.transform.position ) * cameraSpeed );
		player.camera.transform.LookAt( player.playerModel.transform.position + new Vector3( 0, cameraFocusHeight, 0 ) );
	}
}
