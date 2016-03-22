using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class fighterAI : MonoBehaviour {

	public Transform fighterTransform; 
	public Rigidbody fighterBullet; 
	public Rigidbody weaponPowerup;
	public int affinity; 
	public int movement = 1; 

	bool flip = true; 
	bool pause = false; 
	int health = 5; 
	int amountMoved = 0; 
	double fighterTimer = 0.5; 
	Rigidbody fighterRB;
	double randomNumber = 0.0; 

	//Use this for initilization
	void Start()
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
				wP = Instantiate(weaponPowerup, fighterTransform.position, fighterTransform.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				if(name == "fighter1")
				{
					wP.AddForce(fighterTransform.forward * 2000); 
				}
				if(name == "fighter2")
				{
					wP.AddForce(fighterTransform.forward * -2000); 
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
			if(affinity == 2)
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
				wP = Instantiate(weaponPowerup, fighterTransform.position, fighterTransform.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				if(name == "fighter1")
				{
					wP.AddForce(fighterTransform.forward * 2000); 
				}
				if(name == "fighter2")
				{
					wP.AddForce(fighterTransform.forward * -2000); 
				}
			}
		}
		if(GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
		{
			GameObject.Find("ebName").transform.Translate(Vector3.down * 2); 
		}
	}
	
	// Update is called once per frame
	void Update() 
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
			fighterTimer -= Time.deltaTime; 
			if(fighterTimer <= 0.0)
			{ 
				if(name == "fighter1")
				{
					fighterRB = Instantiate(fighterBullet, fighterTransform.position, fighterTransform.rotation) as Rigidbody;
					fighterRB.AddForce(fighterTransform.forward * 3500);
					Destroy(fighterRB.gameObject, 2.0f);
				} 
				if(name == "fighter2")
				{
					fighterRB = Instantiate(fighterBullet, fighterTransform.position, fighterTransform.rotation) as Rigidbody;
					fighterRB.AddForce(fighterTransform.forward * -3500);
					Destroy(fighterRB.gameObject, 2.0f);
				} 
				if(affinity == 1)
				{
					fighterRB.gameObject.GetComponent<Renderer>().material.color = Color.white; 
					fighterRB.name = "fbWhite"; 
				}
				if(affinity == 2)
				{
					fighterRB.gameObject.GetComponent<Renderer>().material.color = Color.black; 
					fighterRB.name = "fbBlack"; 
				}
				if(affinity == 3)
				{
					fighterRB.gameObject.GetComponent<Renderer>().material.color = Color.black; 
					fighterRB.name = "fbGrey"; 
				}
				fighterTimer = 1.5; 
			}

			//Move
			if(movement == 1)
			{
				if(flip == true) 
				{
					fighterTransform.Translate(Vector3.left * 1); 
					if(fighterTransform.position.x < -60)
					{
						flip = false; 
					}
				} 
				else 
				{
					fighterTransform.Translate(Vector3.right * 1); 
					if(fighterTransform.position.x > 60)
					{
						flip = true; 
					}
				}
			}
			if(movement == 2)
			{
				fighterTransform.Translate(Vector3.up * 1); 
			}
			if(movement == 8)
			{
				if(amountMoved < 10)
				{
					this.transform.Translate(Vector3.forward * 1);
					amountMoved += 1; 
				}
				else
				{
					if(flip == true) 
					{
						fighterTransform.Translate(Vector3.left * 1); 
						if(fighterTransform.position.x < -60) 
						{
							flip = false; 
						}
					}
					else 
					{
						fighterTransform.Translate(Vector3.right * 1); 
						if(fighterTransform.position.x > 60) 
						{
							flip = true; 
						}
					}
				}
			}
			if(movement == 9)
			{
				if(amountMoved < 10)
				{
					this.transform.Translate(Vector3.forward * -1);
					amountMoved += 1; 
				}
				else
				{
					if(flip == true) 
					{
						fighterTransform.Translate(Vector3.left * 1); 
						if(fighterTransform.position.x < -60) 
						{
							flip = false; 
						}
					}
					else 
					{
						fighterTransform.Translate(Vector3.right * 1); 
						if(fighterTransform.position.x > 60) 
						{
							flip = true; 
						}
					}
				}
			}
		}

		if((health <= 0) || (this.transform.position.z > 600) || (this.transform.position.z < -100)) 
		{
			Destroy(this.gameObject); 
		}
	}
}
