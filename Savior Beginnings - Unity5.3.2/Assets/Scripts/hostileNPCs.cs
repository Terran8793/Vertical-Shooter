using UnityEngine;
using System.Collections;

//Attach class to environment, or any place where it can continuously run
public class hostileNPCs : MonoBehaviour 
{
	public GameObject droneWhite;
	public GameObject droneBlack; 
	public GameObject droneGrey; 
	public GameObject platform; 
	public GameObject fighterWhite;
	public GameObject fighterBlack; 
	public GameObject fighterGrey; 
	public GameObject gWhite; 
	public GameObject gBlack; 
	public GameObject gGrey; 
	public GameObject droneBigWhite; 
	public GameObject droneBigBlack; 
	public GameObject droneBigGrey; 
	public GameObject suicideBomber; 
	public GameObject sphereBossWhite; 
	public GameObject sphereBossBlack; 
	public GameObject battleship; 
	public Transform spawnPoint1; 
	public Transform spawnPoint2; 
	public Transform spawnPoint3; 
	public Transform spawnPoint4; 
	public Transform spawnPoint5; 
	public Transform spawnPoint6; 
	public Transform spawnPoint7; 
	public Transform spawnPoint8; 
	public Transform spawnPoint9; 
	public Transform spawnPoint10; 
	public Transform spawnPoint11; 
	public Transform background; 

	//private variables
	double timer = 0.0; 
	bool spawn = true; 
	bool pause = false; 
	bool newRow = false; 
	bool reset = false; 
	int position = 0; 
	float backgroundX; 
	float backgroundY; 
	float backgroundZ; 
	int checkpoint = 0; 

	void Start()
	{
		backgroundX = background.position.x; 
		backgroundY = background.position.y; 
		backgroundZ = background.position.z; 
	}

	void spawnShips(Transform position, GameObject ship, int amount, string name, int type)
	{
		GameObject shipI; 
		Vector3 pos = position.position; 
		for(int number = 0; number < amount; number++)
		{
			shipI = Instantiate(ship, pos, position.rotation) as GameObject; 
			shipI.name = name; 
			if(type == 1)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 1;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 1;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 1;
				}
				if((name == "droneBig1") || (name == "droneBig2"))
				{
					shipI.GetComponent<droneBigScript>().movement = 8;
				}
				pos += new Vector3(30, 0, 0); 
			}
			if(type == 2)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 2;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 2;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 2;
				}
				if((name == "droneBig1") || (name == "droneBig2"))
				{
					shipI.GetComponent<droneBigScript>().movement = 9;
				}
				pos += new Vector3(30, 0, 0); 
			}
			if(type == 3)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 3;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 3;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 3;
				}
				pos += new Vector3(30, 0, 10); 
			}
			if(type == 4)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 3;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 3;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 3;
				}
				pos += new Vector3(-30, 0, 10); 
			}
			if(type == 5)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 4;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 4;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 4;
				}
				pos += new Vector3(-30, 0, -15); 
			}
			if(type == 6)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 5;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 5;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 5;
				}
				pos += new Vector3(-30, 0, 15); 
			}
			if(type == 7)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 6;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 6;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 6;
				}
				pos += new Vector3(30, 0, 15); 
			}
			if(type == 8)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 7;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 7;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 7;
				}
				pos += new Vector3(30, 0, -15); 
			}
			if(type == 9)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 2;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 2;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 2;
				}
				pos += new Vector3(0, 0, -15);
				if((shipI.name != "sphereBoss1") && (shipI.name != "sphereBoss2"))
				{
					shipI = Instantiate(ship, pos + new Vector3(15, 0, 0), position.rotation) as GameObject; 
					shipI.name = name; 
					if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
					{
						shipI.GetComponent<enemies>().movement = 2;
					} 
					if((name == "fighter1") || (name == "fighter2"))
					{
						shipI.GetComponent<fighterAI>().movement = 2;
					} 
					if((name == "gattling1") || (name == "gattling2"))
					{
						shipI.GetComponent<gattlingScript>().movement = 2;
					}
				}
			}
			if(type == 10)
			{
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 3;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 3;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 3;
				}
				pos += new Vector3(0, 0, 15); 
				shipI = Instantiate(ship, pos + new Vector3(15, 0, 0), position.rotation) as GameObject; 
				shipI.name = name; 
				if((name == "drone1(Clone)") || (name == "drone2(Clone)"))
				{
					shipI.GetComponent<enemies>().movement = 3;
				} 
				if((name == "fighter1") || (name == "fighter2"))
				{
					shipI.GetComponent<fighterAI>().movement = 3;
				} 
				if((name == "gattling1") || (name == "gattling2"))
				{
					shipI.GetComponent<gattlingScript>().movement = 3;
				}
			}
		}
	}
	
	//Update is called once per frame
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

		//Reset Timer
		if(GameObject.Find("playerCharacter").GetComponent<Renderer>().enabled == false)
		{
			if(checkpoint == 0)
			{
				spawn = true; 
				timer = 0.0; 
			}
			if(checkpoint == 1)
			{
				spawn = false;
				timer = 60.0; 
			}
		}

		if(pause == false)
		{
			background.position = new Vector3(backgroundX, backgroundY, backgroundZ); 
			backgroundZ += 1; 
			if(backgroundZ >= 285)
			{
				backgroundZ -= 285;
			}

			timer += Time.deltaTime; 
			GameObject droneI; 
			if((timer >= 5.0) && (timer < 5.1))
			{
				if(spawn == true)
				{
					droneI = Instantiate(droneGrey, spawnPoint1.position,  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone1(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint1.position + new Vector3(0, 0, 80),  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone2(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint3.position,  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone2(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint3.position + new Vector3(0, 0, -80),  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone1(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint7.position,  spawnPoint7.rotation) as GameObject; 
					droneI.name = "drone1(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint7.position + new Vector3(0, 0, 80),  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone2(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint8.position,  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone2(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint8.position + new Vector3(0, 0, -80),  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone1(Clone)"; 
					spawn = false; 
				}
			}
			if((timer >= 5.5) && (timer < 5.6))
			{
				if(spawn == false)
				{
					droneI = Instantiate(droneGrey, spawnPoint1.position,  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone1(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint3.position,  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone2(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint7.position,  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone1(Clone)"; 
					droneI = Instantiate(droneGrey, spawnPoint8.position,  spawnPoint1.rotation) as GameObject; 
					droneI.name = "drone2(Clone)"; 
					spawn = true; 
				}
			}
			if((timer >= 25.0) && (timer < 25.1))
			{
				if(spawn == true)
				{
					spawnShips(spawnPoint4, droneWhite, 5, "drone1(Clone)", 2); 
					spawn = false; 
				}
			}
			if((timer >= 26.0) && (timer < 26.1))
			{
				if(spawn == false)
				{
					spawnShips(spawnPoint4, droneBlack, 6, "drone1(Clone)", 2); 
					spawn = true; 
				}
			}
			if((timer >= 29.0) && (timer < 29.1))
			{
				if(spawn == true)
				{
					spawnShips(spawnPoint11, droneWhite, 6, "drone2(Clone)", 3); 
					spawn = false; 
				}
			}
			if((timer >= 29.5) && (timer < 29.6))
			{
				if(spawn == false)
				{
					spawnShips(spawnPoint9, droneBlack, 6, "drone2(Clone)", 4); 
					spawn = true; 
				}
			}
			if((timer >= 34.0) && (timer < 34.1))
			{
				if(spawn == true)
				{
					spawnShips(spawnPoint5, droneBlack, 5, "drone1(Clone)", 5); 
					spawnShips(spawnPoint5, droneWhite, 5, "drone1(Clone)", 6); 
					spawnShips(spawnPoint10, droneBlack, 5, "drone2(Clone)", 7); 
					spawnShips(spawnPoint10, droneWhite, 5, "drone2(Clone)", 8); 
					spawn = false; 
				}
			}
			if((timer >= 34.5) && (timer < 34.6))
			{
				if(spawn == false)
				{
					spawnShips(spawnPoint4, droneWhite, 6, "drone1(Clone)", 9); 
					spawnShips(spawnPoint9, droneBlack, 6, "drone2(Clone)", 10);
					spawn = true; 
				}
			}
			if((timer >= 40.0) && (timer < 40.1))
			{
				if(spawn == true)
				{
					spawnShips(spawnPoint2, droneBigWhite, 1, "droneBig1", 1); 
					spawnShips(spawnPoint4, droneBigBlack, 1, "droneBig1", 1); 
					spawnShips(spawnPoint9, droneBigBlack, 1, "droneBig2", 2); 
					spawnShips(spawnPoint11, droneBigWhite, 1, "droneBig2", 2); 
					spawn = false; 
				}
			}
			if((timer >= 40.2) && (timer < 40.3))
			{
				if(spawn == false)
				{
					spawnShips(spawnPoint5, droneBigGrey, 1, "droneBig1", 1);
					spawnShips(spawnPoint10, droneBigGrey, 1, "droneBig1", 2);
					spawn = true; 
				}
			}
			if((timer >= 45.0) && (timer < 45.1))
			{
				if(spawn == true)
				{
					spawnShips(spawnPoint1, droneBlack, 1, "drone1(Clone)", 1); 
					spawnShips(spawnPoint7, droneWhite, 1, "drone1(Clone)", 1); 
					spawnShips(spawnPoint3, droneBlack, 1, "drone2(Clone)", 1); 
					spawnShips(spawnPoint8, droneWhite, 1, "drone2(Clone)", 1); 
					spawn = false; 
				}
			}
			if((timer >= 50.0) && (timer < 50.1))
			{
				if(spawn == false)
				{
					spawnShips(spawnPoint1, droneGrey, 2, "drone1(Clone)", 1); 
					spawnShips(spawnPoint7, droneGrey, 2, "drone1(Clone)", 1); 
					spawnShips(spawnPoint3, droneGrey, 2, "drone2(Clone)", 1); 
					spawnShips(spawnPoint8, droneGrey, 2, "drone2(Clone)", 1); 
					spawn = true; 
				}
			}
			if((timer >= 55.0) && (timer < 55.1))
			{
				if(spawn == true)
				{
					spawnShips(spawnPoint1, droneBlack, 3, "drone1(Clone)", 1); 
					spawnShips(spawnPoint7, droneWhite, 3, "drone1(Clone)", 1); 
					spawnShips(spawnPoint3, droneBlack, 3, "drone2(Clone)", 1); 
					spawnShips(spawnPoint8, droneWhite, 3, "drone2(Clone)", 1); 
					spawn = false; 
				}
			}
			if((timer >= 60.0) && (timer < 60.1))
			{
				if(spawn == false)
				{
					spawnShips(spawnPoint1, gGrey, 1, "gattling1", 1); 
					spawnShips(spawnPoint7, gGrey, 1, "gattling1", 1); 
					spawnShips(spawnPoint3, gGrey, 1, "gattling2", 1); 
					spawnShips(spawnPoint8, gGrey, 1, "gattling2", 1); 
					spawn = true; 
				}
			}
			if((timer >= 80.0) && (timer < 80.1))
			{
				reset = true; 
				if(spawn == true)
				{
					spawnShips(spawnPoint5, sphereBossWhite, 1, "sphereBoss1", 8); 
					spawnShips(spawnPoint10, sphereBossBlack, 1, "sphereBoss2", 9); 
					spawn = false; 
				}
			}

			if(reset == true)
			{
				reset = false; 
				if(GameObject.Find("torpedoWhite") != null)
				{
					Destroy(GameObject.Find("torpedoWhite"));
					reset = true;
				}
				if(GameObject.Find("torpedoBlack") != null)
				{
					Destroy(GameObject.Find("torpedoBlack"));
					reset = true;
				}
				if(GameObject.Find("fbWhite") != null)
				{
					Destroy(GameObject.Find("fbWhite")); 
					reset = true;
				}
				if(GameObject.Find("fbBlack") != null)
				{
					Destroy(GameObject.Find("fbBlack"));
					reset = true;
				}
				if(GameObject.Find("fighter1") != null)
				{
					Destroy(GameObject.Find("fighter1")); 
					reset = true;
				}
				if(GameObject.Find("fighter2") != null)
				{
					Destroy(GameObject.Find("fighter2")); 
					reset = true;
				}
				if(GameObject.Find("platform") != null)
				{
					Destroy(GameObject.Find("platform"));
					reset = true;
				}
				if(GameObject.Find("suicideBomber") != null)
				{
					Destroy(GameObject.Find("suicideBomber"));
					reset = true;
				}
				if(GameObject.Find("battleship") != null)
				{
					Destroy(GameObject.Find("battleship"));
					reset = true;
				} 
				if(GameObject.Find("droneBig1") != null)
				{
					Destroy(GameObject.Find("droneBig1")); 
					reset = true; 
				}
				if(GameObject.Find("droneBig2") != null)
				{
					Destroy(GameObject.Find("droneBig2")); 
					reset = true; 
				}
			}
		}
	}
}
