using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class enemies : MonoBehaviour 
{
	public Rigidbody droneB; 
	public Transform dronePrefabTransform; 
	public Rigidbody weaponPowerup;
	public bool buffed; 
	public int affinity; 
	public int movement = 1; 
	public int health = 6; 

	//private variables
	bool flip = false; 
	bool pause = false; 
	double droneTimer = 1.0; 
	int amountMoved = 0; 
	Rigidbody droneBRB; 
	double randomNumber = 0.0; 
	Text count; 

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
		if(buffed == true)
		{
			health = 100; 
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
			float increment = 2;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
			randomNumber = Random.value; 
			if(randomNumber > 0.9)
			{
				Rigidbody wP; 
				wP = Instantiate(weaponPowerup, dronePrefabTransform.position, dronePrefabTransform.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				if(name == "drone1(Clone)")
				{
					wP.AddForce(dronePrefabTransform.forward * 2000); 
				}
				if(name == "drone2(Clone)")
				{
					wP.AddForce(dronePrefabTransform.forward * -2000);
				}
			}
			if(GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
			{
				GameObject.Find("ebName").transform.Translate(Vector3.down * 4); 
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
			health -= 5; 
			Destroy(droneC.gameObject); 
		}
		if(droneC.gameObject.name == "blade")
		{
			health -= 5; 
		}
		if((health <= 0) || (this.transform.position.z > 600) || (this.transform.position.z < -100)) 
		{
			float increment = 2;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
			randomNumber = Random.value; 
			if(randomNumber > 0.9)
			{
				Rigidbody wP; 
				wP = Instantiate(weaponPowerup, dronePrefabTransform.position, dronePrefabTransform.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				if(name == "drone1(Clone)")
				{
					wP.AddForce(dronePrefabTransform.forward * 2000); 
				}
				if(name == "drone2(Clone)")
				{
					wP.AddForce(dronePrefabTransform.forward * -2000);
				}
			}
			if(GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
			{
				GameObject.Find("ebName").transform.Translate(Vector3.down * 4); 
			}
			if(buffed == true)
			{
				if(GameObject.Find("sphereBoss1") != null) 
				{
					if(GameObject.Find("sphereBoss1").GetComponent<sphereBossScript>().spawnDrone == false)
					{
						GameObject.Find("sphereBoss1").GetComponent<sphereBossScript>().spawnDrone = true; 
					}
				}
				if(GameObject.Find("sphereBoss2") != null) 
				{
					if(GameObject.Find("sphereBoss2").GetComponent<sphereBossScript>().spawnDrone == false)
					{
						GameObject.Find("sphereBoss2").GetComponent<sphereBossScript>().spawnDrone = true; 
					}
				}
			}
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
			droneTimer -= Time.deltaTime; 
			if(droneTimer <= 0.0) 
			{ 
				if(name == "drone1(Clone)") 
				{
					droneBRB = Instantiate(droneB, dronePrefabTransform.position, dronePrefabTransform.rotation * Quaternion.AngleAxis (-90, Vector3.right)) as Rigidbody;
					droneBRB.AddForce(dronePrefabTransform.forward * 5500);
					Destroy(droneBRB.gameObject, 2.0f);
				} 
				if(name == "drone2(Clone)") 
				{
					droneBRB = Instantiate (droneB, dronePrefabTransform.position, dronePrefabTransform.rotation * Quaternion.AngleAxis (-90, Vector3.right)) as Rigidbody;
					droneBRB.AddForce (dronePrefabTransform.forward * -5500);
					Destroy(droneBRB.gameObject, 2.0f);
				}
				if(affinity == 1) 
				{
					droneBRB.gameObject.GetComponent<Renderer>().material.color = Color.white; 
					droneBRB.name = "torpedoWhite"; 
				}
				if(affinity == 2) 
				{
					droneBRB.gameObject.GetComponent<Renderer>().material.color = Color.black; 
					droneBRB.name = "torpedoBlack"; 
				}
				if(affinity == 3) 
				{
					droneBRB.gameObject.GetComponent<Renderer>().material.color = Color.grey; 
					droneBRB.name = "torpedoGrey"; 
				}
				droneTimer = 1.0; 
			}

			//Move
			if(movement == 1)
			{
				if(flip == true) 
				{
					dronePrefabTransform.Translate(Vector3.left * 1); 
					if(dronePrefabTransform.position.x < -60) 
					{
						flip = false; 
					}
				}
				else 
				{
					dronePrefabTransform.Translate(Vector3.right * 1); 
					if(dronePrefabTransform.position.x > 60) 
					{
						flip = true; 
					}
				}
			}
			if(movement == 2)
			{
				dronePrefabTransform.Translate(Vector3.forward * 1); 
			}
			if(movement == 3)
			{
				dronePrefabTransform.Translate(Vector3.forward * -1); 
			}
			if(movement == 4)
			{
				dronePrefabTransform.Translate(Vector3.forward * 1); 
			}
			if(movement == 5)
			{
				dronePrefabTransform.Translate(Vector3.forward * 1); 

			}
			if(movement == 6)
			{
				dronePrefabTransform.Translate(Vector3.forward * -1); 
			}
			if(movement == 7)
			{
				dronePrefabTransform.Translate(Vector3.forward * -1); 
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
						dronePrefabTransform.Translate(Vector3.left * 1); 
						if(dronePrefabTransform.position.x < -60) 
						{
							flip = false; 
						}
					}
					else 
					{
						dronePrefabTransform.Translate(Vector3.right * 1); 
						if(dronePrefabTransform.position.x > 60) 
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
						dronePrefabTransform.Translate(Vector3.left * 1); 
						if(dronePrefabTransform.position.x < -60) 
						{
							flip = false; 
						}
					}
					else 
					{
						dronePrefabTransform.Translate(Vector3.right * 1); 
						if(dronePrefabTransform.position.x > 60) 
						{
							flip = true; 
						}
					}
				}
			}

			//Death
			if((health <= 0) || (this.transform.position.z > 600) || (this.transform.position.z < -100)) 
			{
				Destroy(this.gameObject); 
				if(buffed == true)
				{
					if(GameObject.Find("sphereBoss1").GetComponent<sphereBossScript>().spawnDrone == false) 
					{
						GameObject.Find("sphereBoss1").GetComponent<sphereBossScript>().spawnDrone = true; 
					}
					if(GameObject.Find("sphereBoss2").GetComponent<sphereBossScript>().spawnDrone == false) 
					{
						GameObject.Find("sphereBoss2").GetComponent<sphereBossScript>().spawnDrone = true; 
					}
				}
			}
		}
	}
}
