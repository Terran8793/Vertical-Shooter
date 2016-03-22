using UnityEngine;
using System.Collections;

public class missleScript : MonoBehaviour {
	
	public Rigidbody rb; 
	public float missileVel;
	public float turn;
	Transform target; 
	float oldDistance; 

	// Use this for initialization
	void Start() 
	{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("target"))
		{
			float newDistance = (go.transform.position - this.transform.position).sqrMagnitude;

			if(newDistance > oldDistance)
			{
				oldDistance = newDistance; 
				target = go.transform; 
			}
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(target != null)
		{
			rb.velocity = transform.forward * missileVel;
			Vector3 relPosition = target.position - transform.position;
			Quaternion targetRotation = Quaternion.LookRotation(relPosition);
			rb.MoveRotation(Quaternion.RotateTowards(this.transform.rotation, targetRotation, turn));
		}
	}
}
