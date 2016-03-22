using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class sphereBossScript : MonoBehaviour {

	public int affinity;
	public int movement = 8; 
	public bool spawnDrone = false; 
	public GameObject droneWhite; 
	public GameObject droneBlack; 
	public Rigidbody missile; 
	public Rigidbody bullet; 

	int amountMoved = 0; 
	int health = 2000; 
	int mode = 1; 
	double spawnDroneTimer = 10; 
	double bulletTimer = 1.5; 
	double missileTimerWhite = 3.0;
	double missileTimerBlack = 4.5; 
	double switchModeTimer = 30.0;
	bool init = true; 

	// Use this for initialization
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
		spawnDrone = true; 
		spawnDroneTimer = 4.0; 
	}

	void OnParticleCollision(GameObject particle)
	{
		if(particle.gameObject.name == "screenClearEffect")
		{
			health -= 500; 
		}
		if(health <= 0)
		{
			float increment = 2;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
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
			float increment = 20;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
			if(GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
			{
				GameObject.Find("ebName").transform.Translate(Vector3.down * 4); 
			}
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		//Shoot
		switchModeTimer -= Time.deltaTime; 
		if(switchModeTimer <= 0)
		{
			mode = 2; 
		}
		Rigidbody bulletI; 
		if(mode == 1)
		{
			bulletTimer -= Time.deltaTime; 
			if(bulletTimer <= 0.0)
			{
				bulletI = Instantiate(bullet, this.transform.position, this.transform.rotation) as Rigidbody; 
				bulletI.name = "fbGrey"; 
				bulletI.gameObject.GetComponent<Renderer>().material.color = Color.red; 
				if(this.name == "sphereBoss1")
				{
					bulletI.AddForce(this.transform.forward * 3500); 
					bulletI.AddForce(this.transform.right * 5500); 
				}
				if(this.name == "sphereBoss2")
				{
					bulletI.AddForce(this.transform.forward * -3500); 
					bulletI.AddForce(this.transform.right * 5500); 
				}
				bulletI = Instantiate(bullet, this.transform.position, this.transform.rotation) as Rigidbody; 
				bulletI.name = "fbGrey"; 
				bulletI.gameObject.GetComponent<Renderer>().material.color = Color.red; 
				if(this.name == "sphereBoss1")
				{
					bulletI.AddForce(this.transform.forward * 3500); 
					bulletI.AddForce(this.transform.right * 3500); 
				}
				if(this.name == "sphereBoss2")
				{
					bulletI.AddForce(this.transform.forward * -3500); 
					bulletI.AddForce(this.transform.right * 3500); 
				}
				bulletI = Instantiate(bullet, this.transform.position, this.transform.rotation) as Rigidbody; 
				bulletI.name = "fbGrey"; 
				bulletI.gameObject.GetComponent<Renderer>().material.color = Color.red; 
				if(this.name == "sphereBoss1")
				{
					bulletI.AddForce(this.transform.forward * 3500); 
				}
				if(this.name == "sphereBoss2")
				{
					bulletI.AddForce(this.transform.forward * -3500); 
				}
				bulletI = Instantiate(bullet, this.transform.position, this.transform.rotation) as Rigidbody; 
				bulletI.name = "fbGrey"; 
				bulletI.gameObject.GetComponent<Renderer>().material.color = Color.red; 
				if(this.name == "sphereBoss1")
				{
					bulletI.AddForce(this.transform.forward * 3500); 
					bulletI.AddForce(this.transform.right * -3500); 
				}
				if(this.name == "sphereBoss2")
				{
					bulletI.AddForce(this.transform.forward * -3500); 
					bulletI.AddForce(this.transform.right * -3500); 
				}
				bulletI = Instantiate(bullet, this.transform.position, this.transform.rotation) as Rigidbody; 
				bulletI.name = "fbGrey"; 
				bulletI.gameObject.GetComponent<Renderer>().material.color = Color.red; 
				if(this.name == "sphereBoss1")
				{
					bulletI.AddForce(this.transform.forward * 3500); 
					bulletI.AddForce(this.transform.right * -5500); 
				}
				if(this.name == "sphereBoss2")
				{
					bulletI.AddForce(this.transform.forward * -3500); 
					bulletI.AddForce(this.transform.right * -5500); 
				}
				bulletTimer = 1.5; 
			}
		}
		if(mode == 2)
		{
			Rigidbody missileI; 
			if(affinity == 1)
			{
				missileTimerWhite -= Time.deltaTime; 
				if(missileTimerWhite <= 0)
				{
					missileI = Instantiate(missile, this.transform.position, this.transform.rotation) as Rigidbody; 
					missileI.name = "missile"; 
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward * 3500); 
						missileI.AddForce(this.transform.right * -3500); 
					}
					if(this.name == "sphereBoss2")
					{
						missileI.AddForce(this.transform.forward *-3500); 
						missileI.AddForce(this.transform.right * -3500); 
					}
					missileI = Instantiate(missile, this.transform.position, this.transform.rotation) as Rigidbody; 
					missileI.name = "missile"; 
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward * 3500); 
					}
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward *-3500); 
					}
					missileI = Instantiate(missile, this.transform.position, this.transform.rotation) as Rigidbody; 
					missileI.name = "missile"; 
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward * 3500); 
						missileI.AddForce(this.transform.right * 3500); 
					}
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward * -3500); 
						missileI.AddForce(this.transform.right * -3500); 
					}
					missileTimerWhite = 3.0; 
				}
			}
			if(affinity == 2)
			{
				missileTimerBlack -= Time.deltaTime; 
				if(missileTimerBlack <= 0)
				{
					missileI = Instantiate(missile, this.transform.position, this.transform.rotation) as Rigidbody; 
					missileI.name = "missile"; 
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward * 3500); 
						missileI.AddForce(this.transform.right * -3500); 
					}
					if(this.name == "sphereBoss2")
					{
						missileI.AddForce(this.transform.forward *-3500); 
						missileI.AddForce(this.transform.right * -3500); 
					}
					missileI = Instantiate(missile, this.transform.position, this.transform.rotation) as Rigidbody; 
					missileI.name = "missile"; 
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward * 3500); 
					}
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward *-3500); 
					}
					missileI = Instantiate(missile, this.transform.position, this.transform.rotation) as Rigidbody; 
					missileI.name = "missile"; 
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward * 3500); 
						missileI.AddForce(this.transform.right * 3500); 
					}
					if(this.name == "sphereBoss1")
					{
						missileI.AddForce(this.transform.forward * -3500); 
						missileI.AddForce(this.transform.right * -3500); 
					}
					missileTimerBlack = 4.5; 
				}
			}
		}

		//Spawn Drone
		if(spawnDrone == true)
		{
			spawnDroneTimer -= Time.deltaTime; 
			if(spawnDroneTimer <= 0)
			{
				GameObject droneI; 
				if(affinity == 1)
				{
					droneI = Instantiate(droneWhite, this.transform.position + new Vector3(20, 0, 0), this.transform.rotation) as GameObject; 
					droneI.GetComponent<enemies>().buffed = true; 
					droneI.GetComponent<enemies>().health = 100; 
					droneI.GetComponent<enemies>().movement = movement; 
					if(movement == 8)
					{
						droneI.name = "drone1(Clone)"; 
					}
					if(movement == 9)
					{
						droneI.name = "drone2(Clone)"; 
					}
				}
				if(affinity == 2)
				{
					droneI = Instantiate(droneBlack, this.transform.position + new Vector3(-20, 0, 0), this.transform.rotation) as GameObject; 
					droneI.GetComponent<enemies>().buffed = true; 
					droneI.GetComponent<enemies>().health = 100; 
					droneI.GetComponent<enemies>().movement = movement; 
					if(movement == 8)
					{
						droneI.name = "drone1(Clone)"; 
					}
					if(movement == 9)
					{
						droneI.name = "drone2(Clone)"; 
					}
				}
				if(init == true)
				{
					if(affinity == 1)
					{
						droneI = Instantiate(droneWhite, this.transform.position + new Vector3(20, 0, 0), this.transform.rotation) as GameObject; 
						droneI.GetComponent<enemies>().buffed = true; 
						droneI.GetComponent<enemies>().health = 100; 
						droneI.GetComponent<enemies>().movement = movement; 
						if(movement == 8)
						{
							droneI.name = "drone1(Clone)"; 
						}
						if(movement == 9)
						{
							droneI.name = "drone2(Clone)"; 
						}
					}
					if(affinity == 2)
					{
						droneI = Instantiate(droneBlack, this.transform.position + new Vector3(-20, 0, 0), this.transform.rotation) as GameObject;
						droneI.GetComponent<enemies>().buffed = true; 
						droneI.GetComponent<enemies>().health = 100; 
						droneI.GetComponent<enemies>().movement = movement; 
						if(movement == 8)
						{
							droneI.name = "drone1(Clone)"; 
						}
						if(movement == 9)
						{
							droneI.name = "drone2(Clone)"; 
						}
					}
					init = false; 
				}
				spawnDrone = false; 
				spawnDroneTimer = 10.0; 
			}
		}

		//Movement
		if(movement == 8)
		{
			if(amountMoved < 80)
			{
				this.transform.Translate(Vector3.forward * 1);
				amountMoved += 1; 
			}
		}
		if(movement == 9)
		{
			if(amountMoved < 75)
			{
				this.transform.Translate(Vector3.forward * -1);
				amountMoved += 1; 
			}
		}
		
		//Death
		if((health <= 0) || (this.transform.position.z > 600) || (this.transform.position.z < -100)) 
		{
			Destroy(this.gameObject); 
		}
	}
}
