using UnityEngine;
using System.Collections;

public class Player1Controls : PlayerControls
{
	public KeyCode p1Up = KeyCode.W;
	public KeyCode p1Down = KeyCode.S;
	public KeyCode p1Left = KeyCode.A;
	public KeyCode p1Right = KeyCode.D;
	public KeyCode p1Jump = KeyCode.Space;
	   
	public KeyCode p2Up = KeyCode.UpArrow;
	public KeyCode p2Down = KeyCode.DownArrow;
	public KeyCode p2Left = KeyCode.LeftArrow;
	public KeyCode p2Right = KeyCode.RightArrow;
	
	public bool movePlayer(Player player, float velocity = 10)
	{
		Vector3 totalDirection = new Vector3();
		if ( Input.GetKey( p1Up ) ) totalDirection += player.camera.transform.forward;
		if ( Input.GetKey( p1Down ) ) totalDirection -= player.camera.transform.forward;
		totalDirection.y = 0;
		player.playerModel.transform.position += totalDirection.normalized * velocity;
		player.camera.transform.position = player.playerModel.transform.position + ( -player.playerModel.transform.forward * 10 ) + new Vector3(0,10,0);
		player.camera.transform.LookAt( player.playerModel.transform.position );
		if ( totalDirection.Equals( Vector3.zero ) ) return false;
		else return true;
	}

	public void rotatePlayer( Player player, float velocity = 10 )
	{
		if ( Input.GetKey( p1Right ) )
		{
			player.transform.Rotate( 0, velocity, 0 );
		}
		if ( Input.GetKey( p1Left ) )
		{
			player.transform.Rotate( 0, -velocity, 0 );
		}
	}
}
