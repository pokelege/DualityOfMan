﻿using UnityEngine;
using System.Collections;

public class Player2Controls : PlayerControls
{
	public KeyCode Up = KeyCode.UpArrow;
	public KeyCode Down = KeyCode.DownArrow;
	public KeyCode Left = KeyCode.LeftArrow;
	public KeyCode Right = KeyCode.RightArrow;
	public KeyCode CamLeft = KeyCode.LeftBracket;
	public KeyCode CamRight = KeyCode.RightBracket;
	public KeyCode Jump = KeyCode.RightShift;
	public KeyCode Punch = KeyCode.Slash;
	public Vector3 lastPos;
	private Vector3 targetCameraPos;

	public void setTargetCamPos( Vector3 camPos )
	{
		targetCameraPos = camPos;
	}
	public void movePlayer( Player player, float velocity = 10 )
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
			totalDirection -= player.camera.transform.right;
		}
		if ( Input.GetKey( Punch ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Punch, false );
		totalDirection.y = 0;
		player.playerModel.rigidbody.AddForce( totalDirection.normalized * velocity );
		player.transform.LookAt( player.transform.position + totalDirection );
		if ( player.collided && Input.GetKey( Jump ) ) player.playerModel.rigidbody.AddForce( Vector3.up * velocity );
		if ( totalDirection.Equals( Vector3.zero ) && !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) ani.setAnimation( AnimationHack.CurrentAnimation.Stand );
		else if ( !ani.getAnimation().Equals( AnimationHack.CurrentAnimation.Punch ) ) player.playerModel.GetComponent<AnimationHack>().setAnimation( AnimationHack.CurrentAnimation.Run );
		lastPos = player.playerModel.transform.position;
	}

	public void rotateCam( Player player, float velocity = 10 )
	{
		targetCameraPos += player.playerModel.transform.position - lastPos;
		Vector3 vectorDirection = ( targetCameraPos - player.playerModel.transform.position ).normalized;
		vectorDirection.y = 0;
		vectorDirection = vectorDirection.normalized;
		float lastCameraDistance = ( player.camera.transform.position - player.playerModel.transform.position ).magnitude;
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
		player.camera.transform.position = ( ( player.camera.transform.position - player.playerModel.transform.position ).normalized * lastCameraDistance ) + player.playerModel.transform.position;
		vectorDirection = ( targetCameraPos - player.playerModel.transform.position ).normalized;
		vectorDirection.y = 0;
		vectorDirection = vectorDirection.normalized;
		targetCameraPos = ( vectorDirection * 10 ) + new Vector3( 0, 10, 0 ) + player.playerModel.transform.position;
		player.camera.rigidbody.AddForce( ( targetCameraPos - player.camera.transform.position ) * 25 );
		player.camera.transform.LookAt( player.playerModel.transform.position + new Vector3( 0, 5, 0 ) );
	}
}
