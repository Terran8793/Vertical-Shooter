using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class initialization : MonoBehaviour 
{
	bool reset = false; 

	void Update()
	{
		//Quit
		if(Input.GetKey("escape"))
		{
			Application.LoadLevel(0);
		}

		if(GameObject.Find("playerCharacter").GetComponent<Renderer>().enabled == false)
		{
			reset = true; 
		}
		if(reset == true)
		{
			reset = false; 
			if(GameObject.Find("bulletWhite") != null)
			{
				Destroy(GameObject.Find("bulletWhite"));
				reset = true;
			}
			if(GameObject.Find("bulletBlack") != null)
			{
				Destroy(GameObject.Find("bulletBlack"));
				reset = true;
			}
			if(GameObject.Find("missleP(Clone)") != null)
			{
				Destroy(GameObject.Find("missleP(Clone)"));
				reset = true;
			}
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
			if(GameObject.Find("drone1(Clone)") != null)
			{
				Destroy(GameObject.Find("drone1(Clone)"));
				reset = true;
			}
			if(GameObject.Find("drone2(Clone)") != null)
			{
				Destroy(GameObject.Find("drone2(Clone)"));
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
			if(GameObject.Find("sphereBoss1") != null)
			{
				Destroy(GameObject.Find("sphereBoss1")); 
				reset = true; 
			}
			if(GameObject.Find("sphereBoss2") != null)
			{
				Destroy(GameObject.Find("sphereBoss2")); 
				reset = true; 
			}
			if(GameObject.Find("weaponPowerup") != null)
			{
				Destroy(GameObject.Find("weaponPowerup")); 
				reset = true; 
			}
		}
	}
}
