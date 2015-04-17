using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
	public bool pressed = false;
	public GameObject up, down;
	public GameObject[] elligibleObjects;
	public AudioClip buttonSound;
	public bool releaseable;
	private class ObjectChecker { public GameObject elligibleObject; public bool collided;}
	private ObjectChecker[] objects;
	// Use this for initialization
	void Start()
	{
		up.SetActive( true );
		down.SetActive( false );
		if (elligibleObjects != null )
		{
			objects = new ObjectChecker[elligibleObjects.Length];
			for(int i = 0; i <objects.Length; i++)
			{
				objects[i] = new ObjectChecker { elligibleObject = elligibleObjects[i], collided = false };
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if ( pressed )
		{
			up.SetActive( false );
			down.SetActive( true );
		}
		else
		{
			up.SetActive( true );
			down.SetActive( false );
		}
	}
	void OnCollisionStay(Collision collision)
	{
		if(elligibleObjects != null && elligibleObjects.Length > 0)
		{
			pressed = false;
			foreach(ObjectChecker i in objects )
			{
				if(collision.collider.gameObject.Equals(i.elligibleObject))
				{
					if ( buttonSound != null && i.collided == false ) audio.PlayOneShot( buttonSound );
					i.collided = true;
					pressed = true;
				}
			}
		}
		else
		{
			if ( buttonSound != null && pressed == false ) audio.PlayOneShot( buttonSound );
			pressed = true;
		}

	}

	void OnCollisionExit(Collision collision)
	{
		if ( releaseable && elligibleObjects != null && elligibleObjects.Length > 0 )
		{
			pressed = false;
			foreach ( ObjectChecker i in objects )
			{
				if ( collision.collider.gameObject.Equals( i.elligibleObject ) )
				{
					if ( buttonSound != null && i.collided == true ) audio.PlayOneShot( buttonSound );
					i.collided = false;
				}
				else if(i.collided)
				{
					pressed = true;
				}
			}
		}
	}
}