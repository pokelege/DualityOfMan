using UnityEngine;
using System.Collections;

public interface PlayerControls
{
	void movePlayer( Player player, float velocity = 10, float jumpPower = 10, AudioClip jumpSound = null, AudioClip punchSound = null );
	void rotateCam( Player player, float velocity = 10, float cameraDistance = 5, float cameraHeight = 3, float cameraFocusHeight = 3, float cameraSpeed = 25, float cameraMaxDistance = 10 );
	void setTargetCamPos( Vector3 camPos );
}
