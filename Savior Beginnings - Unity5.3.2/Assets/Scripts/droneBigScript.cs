using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class droneBigScript : MonoBehaviour {

	public Rigidbody weaponPowerup; 
	public GameObject droneWhite; 
	public GameObject droneBlack; 
	public GameObject droneGrey; 
	public int movement = 8; 
	public int affinity; 

	int amountMoved = 0; 
	bool pause = false; 
	double droneTimer = 4.0; 
	int health = 100; 
	Rigidbody droneBRB; 
	double randomNumber = 0.0; 
	Text count;
  ScoreControler score;

	//Use this for initilization
	void Start()
	{
	  score = ScoreControler.Get();
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
      ImDead();
    }
  }

  private void ImDead()
  {
    float increment = 2;
    score.AddScore(increment);
    //float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x;
    //GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);
    //GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString();
    Destroy(this.gameObject);
    randomNumber = Random.value;
    if (randomNumber > 0.9)
    {
      Rigidbody wP;
      wP = Instantiate(weaponPowerup, this.transform.position, this.transform.rotation) as Rigidbody;
      wP.name = "weaponPowerup";
      if (name == "drone1(Clone)")
      {
        wP.AddForce(this.transform.forward * 2000);
      }
      if (name == "drone2(Clone)")
      {
        wP.AddForce(this.transform.forward * -2000);
      }
    }
    if (GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
    {
      GameObject.Find("ebName").transform.Translate(Vector3.down * 4);
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
		  ImDead();
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

		//Spawn Ship
		droneTimer -= Time.deltaTime; 
		if(droneTimer <= 0)
		{
			GameObject droneI; 
			if(affinity == 1)
			{
				droneI = Instantiate(droneWhite, this.transform.position, this.transform.rotation) as GameObject; 
				droneI.GetComponent<fighterAI>().movement = movement;
				if(movement == 8)
				{
					droneI.name = "fighter1"; 
				}
				if(movement == 9)
				{
					droneI.name = "fighter2"; 
				}
			}
			if(affinity == 2)
			{
				droneI = Instantiate(droneBlack, this.transform.position, this.transform.rotation) as GameObject; 
				droneI.GetComponent<fighterAI>().movement = movement;
				if(movement == 8)
				{
					droneI.name = "fighter1"; 
				}
				if(movement == 9)
				{
					droneI.name = "fighter2"; 
				}
			}
			if(affinity == 3)
			{
				droneI = Instantiate(droneGrey, this.transform.position, this.transform.rotation) as GameObject; 
				droneI.GetComponent<fighterAI>().movement = movement;
				if(movement == 8)
				{
					droneI.name = "fighter1"; 
				}
				if(movement == 9)
				{
					droneI.name = "fighter2"; 
				}
			}
			droneTimer = 4.0; 
		}

		//Movement
		if(movement == 8)
		{
			if(amountMoved < 90)
			{
				this.transform.Translate(Vector3.forward * 1);
				amountMoved += 1; 
			}
		}
		if(movement == 9)
		{
			if(amountMoved < 70)
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
