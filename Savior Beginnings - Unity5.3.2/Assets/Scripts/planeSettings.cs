using UnityEngine;
using System.Collections;

public class planeSettings : MonoBehaviour {

	// Use this for initialization
	void Start() 
	{
		gameObject.GetComponent<Renderer>().material.color = Color.black; 
	}
}
