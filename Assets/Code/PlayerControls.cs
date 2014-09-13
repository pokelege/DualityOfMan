using UnityEngine;
using System.Collections;

public interface PlayerControls
{
	void movePlayer( Player player, float velocity = 10 );
	void rotatePlayer( Player player, float velocity = 10 );
	void rotateCam( Player player, float velocity = 10 );
}
