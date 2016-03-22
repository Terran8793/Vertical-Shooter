using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class gattlingScript : MonoBehaviour {

	public Transform gattlingTransform; 
	public Rigidbody fighterBullet; 
	public Rigidbody weaponPowerup;
	public int affinity; 
	public int movement = 1; 

	bool flip = true; 
	bool pause = false; 
	int health = 1; 
	double gTimer = 0.15; 
	Rigidbody gRB;
	double randomNumber = 0.0; 

	// Use this for initialization
	void Start () 
	{
		if(affinity == 1)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.white; 
		}
		if(affinity == 2)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.black; 
		}
		if(affinity == 3)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.grey; 
		}
	}

	void OnParticleCollision(GameObject particle)
	{
		if(particle.gameObject.name == "screenClearEffect")
		{
			health -= 100; 
		}
		if(health <= 0)
		{
			float increment = 1;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
			randomNumber = Random.value; 
			if(randomNumber > 0.9)
			{
				Rigidbody wP; 
				wP = Instantiate(weaponPowerup, gattlingTransform.position, gattlingTransform.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				if(name == "gattling1")
				{
					wP.AddForce(gattlingTransform.forward * 2000); 
				}
				if(name == "gattling2")
				{
					wP.AddForce(gattlingTransform.forward * -2000); 
				}
			}
		}
	}
	
	//Called when drone is hit by something
	void OnCollisionEnter(Collision droneC)
	{
		if(droneC.gameObject.name == "bulletWhite")
		{
			if((affinity == 1) || (affinity == 3))
			{
				health -= 1; 
			}
			if(affinity == 1)
			{
				health -= 2; 
			}
			Destroy(droneC.gameObject); 
		}
		if(droneC.gameObject.name == "bulletBlack")
		{
			if(affinity == 1)
			{
				health -= 2; 
			}
			if((affinity == 2) || (affinity == 3))
			{
				health -= 1; 
			}
			Destroy(droneC.gameObject); 
		}
		if(droneC.gameObject.name == "missleP(Clone)")
		{
			health -= 20; 
			Destroy(droneC.gameObject); 
		}
		if(droneC.gameObject.name == "blade")
		{
			health -= 5; 
		}
		if((health <= 0) || (this.transform.position.z > 600) || (this.transform.position.z < -100)) 
		{
			float increment = 1;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
			randomNumber = Random.value; 
			if(randomNumber > 0.9)
			{
				Rigidbody wP; 
				wP = Instantiate(weaponPowerup, gattlingTransform.position, gattlingTransform.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				if(name == "gattling1")
				{
					wP.AddForce(gattlingTransform.forward * 2000); 
				}
				if(name == "gattling2")
				{
					wP.AddForce(gattlingTransform.forward * -2000); 
				}
			}
		}
		if(GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
		{
			GameObject.Find("ebName").transform.Translate(Vector3.down * 2); 
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Pause 
		if(Input.GetKeyUp("p"))
		{
			pause = !pause; 
		}
		if(pause == false)
		{
			Time.timeScale = 1; 
		}
		else
		{
			Time.timeScale = 0; 
		}
		
		if(pause == false)
		{
			//Fire
			gTimer -= Time.deltaTime; 
			if(gTimer <= 0.0)
			{ 
				if(name == "gattling1")
				{
					gRB = Instantiate(fighterBullet, gattlingTransform.position, gattlingTransform.rotation) as Rigidbody;
					gRB.AddForce(gattlingTransform.forward * 6000);
					Destroy(gRB.gameObject, 2.0f);
				} 
				if(name == "gattling2")
				{
					gRB = Instantiate(fighterBullet, gattlingTransform.position, gattlingTransform.rotation) as Rigidbody;
					gRB.AddForce(gattlingTransform.forward * -6000);
					Destroy(gRB.gameObject, 2.0f);
				} 
				if(affinity == 1)
				{
					gRB.gameObject.GetComponent<Renderer>().material.color = Color.white; 
					gRB.name = "fbWhite"; 
				}
				if(affinity == 2)
				{
					gRB.gameObject.GetComponent<Renderer>().material.color = Color.black; 
					gRB.name = "fbBlack"; 
				}
				if(affinity == 3)
				{
					gRB.gameObject.GetComponent<Renderer>().material.color = Color.grey; 
					gRB.name = "fbGrey"; 
				}
				gTimer = 0.15; 
			}
			
			//Move
			if(movement == 1)
			{
				if(flip == true) 
				{
					gattlingTransform.Translate(Vector3.left * 1); 
					if(gattlingTransform.position.x < -60)
					{
						flip = false; 
					}
				} 
				else 
				{
					gattlingTransform.Translate(Vector3.right * 1); 
					if(gattlingTransform.position.x > 60)
					{
						flip = true; 
					}
				}
			}
			if(movement == 2)
			{
				gattlingTransform.Translate(Vector3.up * 1);
			}
		}

		if((health <= 0) || (this.transform.position.z > 600) || (this.transform.position.z < -100)) 
		{
			Destroy(this.gameObject); 
		}
	}
}
