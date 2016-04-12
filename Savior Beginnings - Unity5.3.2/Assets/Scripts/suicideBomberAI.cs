using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class suicideBomberAI : MonoBehaviour {

	public Transform bomberTransform; 
	public Rigidbody weaponPowerup;
	public bool affinity; 

	bool flip = true; 
	bool pause = false; 
	int health = 10; 
	double fighterTimer = 1.0; 
	double randomNumber = 0.0;
  ScoreControler score;

  void Start()
  {
    score = ScoreControler.Get();
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
    float increment = 20;
    score.AddScore(increment);
    //float wholeAmount = GameObject.Find("SCOREAMOUNT").transform.position.x;
    //GameObject.Find("SCOREAMOUNT").transform.position = new Vector3(wholeAmount + increment, 0, 0);
    //GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + GameObject.Find("SCOREAMOUNT").transform.position.x.ToString();
    Destroy(this.gameObject);
    randomNumber = Random.value;
    if (randomNumber > 0.9)
    {
      Rigidbody wP;
      wP = Instantiate(weaponPowerup, bomberTransform.position, bomberTransform.rotation) as Rigidbody;
      wP.name = "weaponPowerup";
      wP.AddForce(bomberTransform.forward * 2000);
    }
    if (GameObject.Find("ebName").transform.position.z < GameObject.Find("ebPub").transform.position.z)
    {
      GameObject.Find("ebName").transform.Translate(Vector3.down * 20);
    }
  }

  //Called when enemy is hit by something
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
		if(droneC.gameObject.name == "bulletPrefab(Clone)")
		{
			health -= 1; 
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

		if(pause == false)
		{
			bomberTransform.Translate(Vector3.forward * 2);
			if(bomberTransform.position.z > 300)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
