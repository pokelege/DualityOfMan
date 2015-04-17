using UnityEngine;
using System.Collections;

public class AnimationHack : MonoBehaviour {

	public enum CurrentAnimation { Stand, Run, Punch };

	public GameObject[] frames;
	public int standStart, standEnd;
	public int runStart, runEnd;
	public int punchStart, punchEnd;
	private CurrentAnimation animation = CurrentAnimation.Stand;
	private float currentFrame;
	public float speed;
	private bool loop;
	public bool finished;
	// Use this for initialization
	void Start () 
	{
		foreach(GameObject i in frames)
		{
			i.SetActive( false );
		}

		currentFrame = standStart;
	}

	public void setAnimation(CurrentAnimation ani, bool loop = true)
	{
		this.loop = loop;
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
			else if(animation.Equals(CurrentAnimation.Punch))
			{
				currentFrame = punchStart;
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
		finished = false;
		if ( animation.Equals( CurrentAnimation.Stand ) && ( int )currentFrame > standEnd )
		{
			if(loop)
			{
				currentFrame = standStart;
			}
			else
			{
				currentFrame = standEnd;
				finished = true;
			}
		}
		else if ( animation.Equals( CurrentAnimation.Run ) && (int)currentFrame > runEnd )
		{
			currentFrame = runStart;
			if ( loop )
			{
				currentFrame = runStart;
			}
			else
			{
				currentFrame = runEnd;
				finished = true;
			}
		}
		else if ( animation.Equals( CurrentAnimation.Punch ) && ( int )currentFrame > punchEnd )
		{
			currentFrame = punchStart;
			if ( loop )
			{
				currentFrame = punchStart;
			}
			else
			{
				currentFrame = punchEnd;
				finished = true;
			}
		}
		frames[( int )currentFrame].SetActive( true );
	}
}
