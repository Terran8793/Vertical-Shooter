using UnityEngine;
using System.Collections;

public class playButtonScript : MonoBehaviour {

	public GameObject init; 

	void OnMouseUp()
	{
		GameObject init2 = Instantiate(init, init.transform.position, init.transform.rotation) as GameObject;  
	}
}
