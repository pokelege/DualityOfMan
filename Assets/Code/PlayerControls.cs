using UnityEngine;
using System.Collections;

public interface PlayerControls
{
	bool movePlayer( Player player, float velocity = 10 );
	void rotatePlayer( Player player, float velocity = 10 );
}
