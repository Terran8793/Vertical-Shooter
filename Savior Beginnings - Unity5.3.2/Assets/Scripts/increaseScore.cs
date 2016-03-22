using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class increaseScore : MonoBehaviour {

	public Text score; 
	public Transform scoreAmount; 
	
	void Start() 
	{
		score.name = "SCORE";
		scoreAmount.name = "SCOREAMOUNT"; 
		scoreAmount.transform.position = new Vector3(0, 0, 0); 
	}
}
