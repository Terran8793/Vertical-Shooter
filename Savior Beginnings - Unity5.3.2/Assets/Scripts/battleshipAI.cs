using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class battleshipAI : MonoBehaviour {

	public Transform battleshipTransfrom; 
	public Transform victoryT; 
	public Rigidbody torpedo;  
	public Rigidbody bullet; 
	public Rigidbody victoryRB; 
	public Rigidbody weaponPowerup;
	public bool affinity; 

	bool flip = true; 
	bool pause = false; 
	int health = 2000; 
	double timer1 = 1.0; 
	double timer2 = 3.0; 
	Rigidbody bBullet; 
	Rigidbody btorpedo;
	double randomNumber = 0.0; 

	void OnParticleCollision(GameObject particle)
	{
		if(particle.gameObject.name == "screenClearEffect")
		{
			health -= 500; 
		}
		if(health <= 0)
		{
			float increment = 200;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
			randomNumber = Random.value; 
			if(randomNumber > 0.9)
			{
				Rigidbody wP; 
				wP = Instantiate(weaponPowerup, battleshipTransfrom.position, battleshipTransfrom.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				wP.AddForce(battleshipTransfrom.forward * 2000); 
			}
			if(GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
			{
				GameObject.Find("ebName").transform.Translate(Vector3.down * 40); 
			}
		}
	}

	//Called when drone is hit by something
	void OnCollisionEnter(Collision droneC)
	{
		if(droneC.gameObject.name == "bulletWhite")
		{
			if(affinity == true)
			{
				health -= 1; 
			}
			if(affinity == false)
			{
				health -= 2; 
			}
			Destroy(droneC.gameObject); 
		}
		if(droneC.gameObject.name == "bulletBlack")
		{
			if(affinity == true)
			{
				health -= 2; 
			}
			if(affinity == false)
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
			float increment = 200;  
			float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x; 
			GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);  
			GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString(); 
			Destroy(this.gameObject); 
			randomNumber = Random.value; 
			if(randomNumber > 0.9)
			{
				Rigidbody wP; 
				wP = Instantiate(weaponPowerup, battleshipTransfrom.position, battleshipTransfrom.rotation) as Rigidbody; 
				wP.name = "weaponPowerup"; 
				wP.AddForce(battleshipTransfrom.forward * 2000); 
			}
			if(GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
			{
				GameObject.Find("ebName").transform.Translate(Vector3.down * 40); 
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
			timer1 -= Time.deltaTime; 
			timer2 -= Time.deltaTime; 
			//Fire
			if(timer1 <= 0.0)
			{
				bBullet = Instantiate(bullet, battleshipTransfrom.position, battleshipTransfrom.rotation) as Rigidbody;
				bBullet.AddForce(battleshipTransfrom.forward * 6000);
				Destroy(bBullet.gameObject, 2.0f);
				bBullet.gameObject.GetComponent<Renderer>().material.color = Color.white; 
				bBullet.name = "fbWhite"; 
				timer1 = 1.0; 
			}
			if(timer2 <= 0.0)
			{
				btorpedo = Instantiate(torpedo, battleshipTransfrom.position, battleshipTransfrom.rotation) as Rigidbody;
				btorpedo.AddForce(battleshipTransfrom.forward * 6000);
				Destroy(btorpedo.gameObject, 2.0f);
				btorpedo.gameObject.GetComponent<Renderer>().material.color = Color.white; 
				btorpedo.name = "torpedoWhite"; 
				timer2 = 5.0; 
			}

			//Move
			if(flip == true) 
			{
				battleshipTransfrom.Translate(Vector3.left * 1); 
				if(battleshipTransfrom.position.x < -60)
				{
					flip = false; 
				}
			} 
			else 
			{
				battleshipTransfrom.Translate(Vector3.right * 1); 
				if(battleshipTransfrom.position.x > 60)
				{
					flip = true; 
				}
			}
		}
	}
}
