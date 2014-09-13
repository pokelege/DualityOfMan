using UnityEngine;
using System.Collections;

public class Player2Controls : PlayerControls
{
	public KeyCode p2Up = KeyCode.UpArrow;
	public KeyCode p2Down = KeyCode.DownArrow;
	public KeyCode p2Left = KeyCode.LeftArrow;
	public KeyCode p2Right = KeyCode.RightArrow;

	public bool movePlayer( Player player, float velocity = 10 )
	{
		Vector3 totalDirection = new Vector3();
		if ( Input.GetKey( p2Up ) ) totalDirection += player.camera.transform.forward;
		if ( Input.GetKey( p2Down ) ) totalDirection -= player.camera.transform.forward;
		player.playerModel.transform.position += totalDirection.normalized * velocity;
		player.camera.transform.position = player.playerModel.transform.position + ( -player.playerModel.transform.forward * 10 );
		player.camera.transform.LookAt( player.playerModel.transform.position );
		if ( totalDirection.Equals( Vector3.zero ) ) return false;
		else return true;
	}

	public void rotatePlayer( Player player, float velocity = 10 )
	{
		if ( Input.GetKey( p2Right ) )
		{
			player.transform.Rotate( 0, velocity, 0 );
		}
		if ( Input.GetKey( p2Left ) )
		{
			player.transform.Rotate( 0, -velocity, 0 );
		}
	}
}
