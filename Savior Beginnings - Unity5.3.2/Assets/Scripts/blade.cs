using UnityEngine;
using System.Collections;

public class blade : MonoBehaviour {

	public Transform bladeT; 
	public Rigidbody rb; 

	// Update is called once per frame
	void Update() 
	{
		bladeT.Rotate(Vector3.up * 20); 
	}
}
