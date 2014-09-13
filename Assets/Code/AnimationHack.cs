using UnityEngine;
using System.Collections;

public class AnimationHack : MonoBehaviour {

	public enum CurrentAnimation { Stand, Run };

	public GameObject[] frames;
	public int standStart, standEnd;
	public int runStart, runEnd;
	private CurrentAnimation animation = CurrentAnimation.Stand;
	private float currentFrame;
	public float speed;
	// Use this for initialization
	void Start () 
	{
		foreach(GameObject i in frames)
		{
			i.SetActive( false );
		}

		currentFrame = standStart;
	}

	public void setAnimation(CurrentAnimation ani)
	{
		if ( !animation.Equals( ani ) )
		{
			animation = ani;
			frames[( int )currentFrame].SetActive( false );
			if ( animation.Equals( CurrentAnimation.Stand ) )
			{
				currentFrame = standStart;
			}
			else if ( animation.Equals( CurrentAnimation.Run ) )
			{
				currentFrame = runStart;
			}
			frames[( int )currentFrame].SetActive( true );
		}
	}

	public CurrentAnimation getAnimation()
	{
		return animation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		frames[( int )currentFrame].SetActive( false );
		currentFrame += speed * Time.deltaTime;
		if(animation.Equals(CurrentAnimation.Stand) && currentFrame >= standEnd)
		{
			currentFrame = standStart;
		}
		else if ( animation.Equals( CurrentAnimation.Run ) && currentFrame >= runEnd )
		{
			currentFrame = runStart;
		}
		frames[( int )currentFrame].SetActive( true );
	}
}
