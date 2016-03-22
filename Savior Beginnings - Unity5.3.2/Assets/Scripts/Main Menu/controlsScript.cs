using UnityEngine;
using UnityEngine.UI; 
using System.IO;
using System.Collections;

public class controlsScript : MonoBehaviour {

	public Text shootT; 
	public Text misslesT; 
	public Text upT; 
	public Text downT; 
	public Text leftT; 
	public Text rightT; 
	public Text asT; 
	public Text flipT; 
	public Text turnRightT; 
	public Text turnLeftT; 
	public Text dodgeT; 
	public Text sgmT; 
	public Text chargeT; 
	public Text bladeT; 

	bool shootB = false; 
	bool misslesB = false; 
	bool upB = false; 
	bool downB = false; 
	bool leftB = false; 
	bool rightB = false; 
	bool asB = false; 
	bool flipB = false; 
	bool turnRightB = false; 
	bool turnLeftB = false; 
	bool dodgeB = false; 
	bool sgmB = false; 
	bool chargeB = false; 
	bool bladeB = false; 
	bool changeKey = false; 

	string text; 

	StreamReader controls; 

	void Start()
	{
		controls = new StreamReader("save.txt"); 
		for(int number = 0; number < 14; number++)
		{
			if(number == 0)
			{
				shootT.text = controls.ReadLine().ToString(); 
			}
			if(number == 1)
			{
				misslesT.text = controls.ReadLine().ToString(); 
			}
			if(number == 2)
			{
				upT.text = controls.ReadLine().ToString(); 
			}
			if(number == 3)
			{
				downT.text = controls.ReadLine().ToString(); 
			}
			if(number == 4)
			{
				leftT.text = controls.ReadLine().ToString(); 
			}
			if(number == 5)
			{
				rightT.text = controls.ReadLine().ToString(); 
			}
			if(number == 6)
			{
				asT.text = controls.ReadLine().ToString(); 
			}
			if(number == 7)
			{
				flipT.text = controls.ReadLine().ToString(); 
			}
			if(number == 8)
			{
				turnRightT.text = controls.ReadLine().ToString(); 
			}
			if(number == 9)
			{
				turnLeftT.text = controls.ReadLine().ToString(); 
			}
			if(number == 10)
			{
				dodgeT.text = controls.ReadLine().ToString(); 
			}
			if(number == 11)
			{
				sgmT.text = controls.ReadLine().ToString(); 
			}
			if(number == 12)
			{
				chargeT.text = controls.ReadLine().ToString(); 
			}
			if(number == 13)
			{
				bladeT.text = controls.ReadLine().ToString(); 
			}
		}
		controls.Close(); 
	}

	public void shoot()
	{
		shootB = true; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void missles()
	{
		shootB = false; 
		misslesB = true; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void up()
	{
		shootB = false; 
		misslesB = false; 
		upB = true; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void down()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = true; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void left()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = true; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void right()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = true; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void affinityShift()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = true; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void flip()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = true; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void turnRight()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = true; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void turnLeft()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = true; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void dodge()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = true; 
		sgmB = false; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void sgm()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = true; 
		chargeB = false; 
		bladeB = false; 
		changeKey = true;
	}

	public void charge()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = true;
		bladeB = false; 
		changeKey = true;
	}

	public void blade()
	{
		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false;
		bladeB = true; 
		changeKey = true;
	}

	string assignKey(string key)
	{
		if(Input.GetKeyDown("1"))
		{
			key = "1"; 
		}
		if(Input.GetKeyDown("2"))
		{
			key = "2"; 
		}
		if(Input.GetKeyDown("3"))
		{
			key = "3"; 
		}
		if(Input.GetKeyDown("4"))
		{
			key = "4"; 
		}
		if(Input.GetKeyDown("5"))
		{
			key = "6"; 
		}
		if(Input.GetKeyDown("7"))
		{
			key = "7"; 
		}
		if(Input.GetKeyDown("8"))
		{
			key = "8"; 
		}
		if(Input.GetKeyDown("9"))
		{
			key = "9"; 
		}
		if(Input.GetKeyDown("0"))
		{
			key = "0"; 
		}
		if(Input.GetKeyDown("q"))
		{
			key = "q"; 
		}
		if(Input.GetKeyDown("w"))
		{
			key = "w"; 
		}
		if(Input.GetKeyDown("e"))
		{
			key = "e"; 
		}
		if(Input.GetKeyDown("r"))
		{
			key = "r"; 
		}
		if(Input.GetKeyDown("t"))
		{
			key = "t"; 
		}
		if(Input.GetKeyDown("y"))
		{
			key = "y"; 
		}
		if(Input.GetKeyDown("u"))
		{
			key = "u"; 
		}
		if(Input.GetKeyDown("i"))
		{
			key = "i"; 
		}
		if(Input.GetKeyDown("o"))
		{
			key = "o"; 
		}
		if(Input.GetKeyDown("p"))
		{
			key = "p"; 
		}
		if(Input.GetKeyDown("a"))
		{
			key = "a"; 
		}
		if(Input.GetKeyDown("s"))
		{
			key = "s"; 
		}
		if(Input.GetKeyDown("d"))
		{
			key = "d"; 
		}
		if(Input.GetKeyDown("f"))
		{
			key = "f"; 
		}
		if(Input.GetKeyDown("g"))
		{
			key = "g"; 
		}
		if(Input.GetKeyDown("h"))
		{
			key = "h"; 
		}
		if(Input.GetKeyDown("j"))
		{
			key = "j"; 
		}
		if(Input.GetKeyDown("k"))
		{
			key = "k"; 
		}
		if(Input.GetKeyDown("l"))
		{
			key = "l"; 
		}
		if(Input.GetKeyDown("z"))
		{
			key = "z"; 
		}
		if(Input.GetKeyDown("x"))
		{
			key = "x"; 
		}
		if(Input.GetKeyDown("c"))
		{
			key = "c"; 
		}
		if(Input.GetKeyDown("v"))
		{
			key = "v"; 
		}
		if(Input.GetKeyDown("b"))
		{
			key = "b"; 
		}
		if(Input.GetKeyDown("n"))
		{
			key = "n"; 
		}
		if(Input.GetKeyDown("m"))
		{
			key = "m"; 
		}
		if(Input.GetKeyDown("left shift"))
		{
			key = "left shift";  
		}
		if(Input.GetKeyDown("right shift"))
		{
			key = "right shift"; 
		}
		if(Input.GetKeyDown("left ctrl"))
		{
			key = "left ctrl";  
		}
		if(Input.GetKeyDown("right ctrl"))
		{
			key = "right ctrl"; 
		}
		if(Input.GetKeyDown("left alt"))
		{
			key = "left alt";  
		}
		if(Input.GetKeyDown("right alt"))
		{
			key = "right alt"; 
		}
		if(Input.GetKeyDown("backspace"))
		{
			key = "backspace"; 
		}
		if(Input.GetKeyDown("delete"))
		{
			key = "delete"; 
		}
		if(Input.GetKeyDown("tab"))
		{
			key = "tab"; 
		}
		if(Input.GetKeyDown("return"))
		{
			key = "return"; 
		}
		if(Input.GetKeyDown("f1"))
		{
			key = "f1"; 
		}
		if(Input.GetKeyDown("f2"))
		{
			key = "f2"; 
		}
		if(Input.GetKeyDown("f3"))
		{
			key = "f3"; 
		}
		if(Input.GetKeyDown("f4"))
		{
			key = "f4"; 
		}
		if(Input.GetKeyDown("f5"))
		{
			key = "f5"; 
		}
		if(Input.GetKeyDown("f6"))
		{
			key = "f6"; 
		}
		if(Input.GetKeyDown("f7"))
		{
			key = "f7"; 
		}
		if(Input.GetKeyDown("f8"))
		{
			key = "f8"; 
		}
		if(Input.GetKeyDown("f9"))
		{
			key = "f9"; 
		}
		if(Input.GetKeyDown("f10"))
		{
			key = "f10"; 
		}
		if(Input.GetKeyDown("f11"))
		{
			key = "f11"; 
		}
		if(Input.GetKeyDown("f12"))
		{
			key = "f12"; 
		}
		if(Input.GetKeyDown("caps lock"))
		{
			key = "caps lock"; 
		}

		shootB = false; 
		misslesB = false; 
		upB = false; 
		downB = false; 
		leftB = false; 
		rightB = false; 
		asB = false; 
		flipB = false; 
		turnRightB = false; 
		turnLeftB = false; 
		dodgeB = false; 
		sgmB = false; 
		chargeB = false;
		bladeB = false; 
		changeKey = false;

		return key; 
	}

	void Update()
	{
		if(changeKey == true)
		{
			if(shootB == true)
			{
				shootT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					shootT.text = assignKey(shootT.text); 
				}
			}
			if(misslesB == true)
			{
				misslesT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					misslesT.text = assignKey(shootT.text); 
				}
			}
			if(upB == true)
			{
				upT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					upT.text = assignKey(shootT.text); 
				}
			}
			if(downB == true)
			{
				downT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					downT.text = assignKey(shootT.text); 
				}
			}
			if(leftB == true)
			{
				leftT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					leftT.text = assignKey(shootT.text); 
				}
			}
			if(rightB == true)
			{
				rightT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					rightT.text = assignKey(shootT.text); 
				}
			}
			if(asB == true)
			{
				asT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					asT.text = assignKey(shootT.text); 
				}
			}
			if(flipB == true)
			{
				flipT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					flipT.text = assignKey(shootT.text); 
				}
			}
			if(turnRightB == true)
			{
				turnRightT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					turnRightT.text = assignKey(shootT.text); 
				}
			}
			if(turnLeftB == true)
			{
				turnLeftT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					turnLeftT.text = assignKey(shootT.text); 
				}
			}
			if(dodgeB == true)
			{
				dodgeT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					dodgeT.text = assignKey(shootT.text); 
				}
			}
			if(sgmB == true)
			{
				sgmT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					sgmT.text = assignKey(shootT.text); 
				}
			}
			if(chargeB == true)
			{
				chargeT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					chargeT.text = assignKey(shootT.text); 
				}
			}
			if(bladeB == true)
			{
				bladeT.text = " "; 
				if(Input.anyKeyDown == true)
				{
					bladeT.text = assignKey(shootT.text); 
				}
			}
		}
		controls.Close(); 
		text = shootT.text + " " + misslesT.text + " " + upT.text + " " + downT.text + " " + leftT.text + " " + rightT.text + " " + asT.text + " " + flipT.text + " " + turnRightT.text + " " + turnLeftT.text + " " + dodgeT.text + " " + sgmT.text + " " + chargeT.text + " " + bladeT.text; 
		text = text.Replace(" ", System.Environment.NewLine); 
		File.WriteAllText("save.txt", text);
	}
}
