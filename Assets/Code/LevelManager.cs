using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject warp1, warp2;
	public int nextLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(warp1.GetComponent<WarpDetector>().getReady() && warp2.GetComponent<WarpDetector>().getReady())
		{
			Application.LoadLevel( nextLevel );
		}
	}
}
