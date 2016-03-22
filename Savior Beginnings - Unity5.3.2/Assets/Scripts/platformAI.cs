using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class platformAI : MonoBehaviour{

	public Transform platformTransform; 
	public Rigidbody platformBullet; 
	public Rigidbody weaponPowerup;
	public int affinity; 

	bool flip = true; 
	bool pause = false; 
	int health = 40; 
	double fighterTimer = 1.0; 
	Rigidbody platformB; 
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
			float increment = 10;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
			randomNumber = Random.value; 
			if(randomNumber > 0.9)
			{
				Rigidbody wP; 
				wP = Instantiate(weaponPowerup, platformTransform.position, platformTransform.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				wP.AddForce(platformTransform.forward * 2000); 
			}
			if(GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
			{
				GameObject.Find("ebName").transform.Translate(Vector3.down * 20); 
			}
		}
	}
	
	//Called when enemy is hit by something
	void OnCollisionEnter(Collision droneC)
	{
		if(droneC.gameObject.name == "bulletWhite")
		{
			if(affinity == 1)
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
			if(affinity == 2)
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
		if(health <= 0)
		{
			float increment = 10;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
			randomNumber = Random.value; 
			if(randomNumber > 0.9)
			{
				Rigidbody wP; 
				wP = Instantiate(weaponPowerup, platformTransform.position, platformTransform.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				wP.AddForce(platformTransform.forward * 2000); 
			}
			if(GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
			{
				GameObject.Find("ebName").transform.Translate(Vector3.down * 20); 
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
			fighterTimer -= Time.deltaTime; 
			if(fighterTimer <= 0.0)
			{ 
				platformB = Instantiate(platformBullet, platformTransform.position, platformTransform.rotation * Quaternion.AngleAxis(45, Vector3.up) * Quaternion.AngleAxis(90, Vector3.right)) as Rigidbody;
				platformB.AddForce(platformTransform.forward * 4000);
				platformB.AddForce(platformTransform.right * 4000);
				Destroy(platformB.gameObject, 2.0f);
				platformB = Instantiate(platformBullet, platformTransform.position, platformTransform.rotation * Quaternion.AngleAxis(45, Vector3.down) * Quaternion.AngleAxis(90, Vector3.right)) as Rigidbody;
				platformB.AddForce(platformTransform.forward * 4000);
				platformB.AddForce(platformTransform.right * -4000);
				Destroy(platformB.gameObject, 2.0f);
				platformB = Instantiate(platformBullet, platformTransform.position, platformTransform.rotation * Quaternion.AngleAxis(135, Vector3.up) * Quaternion.AngleAxis(90, Vector3.right)) as Rigidbody;
				platformB.AddForce(platformTransform.forward * -4000);
				platformB.AddForce(platformTransform.right * 4000);
				Destroy(platformB.gameObject, 2.0f);
				platformB = Instantiate(platformBullet, platformTransform.position, platformTransform.rotation * Quaternion.AngleAxis(135, Vector3.down) * Quaternion.AngleAxis(90, Vector3.right)) as Rigidbody;
				platformB.AddForce(platformTransform.forward * -4000);
				platformB.AddForce(platformTransform.right * -4000);
				Destroy(platformB.gameObject, 2.0f);
				if(affinity == 1)
				{
					platformB.gameObject.GetComponent<Renderer>().material.color = Color.white; 
					platformB.name = "torpedoWhite"; 
				}
				if(affinity == 2)
				{
					platformB.gameObject.GetComponent<Renderer>().material.color = Color.black; 
					platformB.name = "torpedoBlack"; 
				}
				fighterTimer = 1.0; 
			}


			//Move
			if(flip == true) 
			{
				platformTransform.Translate(Vector3.left * 1); 
				if(platformTransform.position.x < -60)
				{
					flip = false; 
				}
			} 
			else 
			{
				platformTransform.Translate(Vector3.right * 1); 
				if(platformTransform.position.x > 60)
				{
					flip = true; 
				}
			}
		}
	}
}
