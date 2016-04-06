using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System;

public class playerControls : MonoBehaviour
{
  public Transform playerT;
  public Transform bulletPrefabTransform;
  public Transform gameOverButtonT;
  public Transform restartButtonT;
  public Transform missilePrefabTransform;
  public Transform bladeT;
  public Transform bladeTO;
  public Transform healthBarT;
  public Transform energyBarT;
  public Transform life1;
  public Transform life2;
  public Transform life3;
  public Physics playerP;
  public Rigidbody bulletPrefab;
  public Rigidbody missilePrefab;
  public Rigidbody gameOverButtonRB;
  public Rigidbody restartButtonRB;
  public GameObject playerRB;
  public ParticleSystem explosion;
  public Transform ebOld;
  bool move = false;
  bool dodge = true;
  bool boost = true;
  bool flip = false;
  bool right = false;
  bool left = false;
  bool up = false;
  bool down = false;
  bool center = true;
  bool leanLeft = false;
  bool leanRight = false;
  bool missiles = false;
  bool machineGun = true;
  bool spreader = false;
  bool focus = true;
  bool quit = false;
  bool IsLower = false;

  double quitCountDown = 4.0;
  double dodgeTimer = 0.5;
  double dodgeTimer2 = 0.0;
  double mgTimer = 0.1;
  double mTimer = 0.2;
  double bTimer1 = 0.37;
  float playerXC = 0;
  float playerZC = 0;
  float playerYC = 0;
  float bladeOX = 0;
  float bladeOY = 0;
  float bladeOZ = 0;
  float angleUp = 0;
  float angleDown = 0;
  float type = 0;
  int level = 0;
  Rigidbody missileNew;
  double mSpeed = 10.0;
  int playerHealth = 80;
  double tTimer = 0.13;
  bool turnDown = false;
  bool turnUp = false;
  int rotate = 0;
  bool affinity = true;
  double aTimer = 0.2;
  bool pause = false;
  GameObject playerGO;
  bool dodgeCancel = false;
  bool shoot = true;
  bool blade = false;
  int lives = 4;
  double explosionTimer = 0.1;
  bool explosionCooldown = false;
  float ebOldZ;
  float ebOldX;
  float ebOldY;
  int ebMovement;
  bool chargeAttack = true;
  double rechargeTimer = 1.0;
  bool aoe = false;

  //Keys
  string chargeKey = "z";
  string switchGunKey = "s";
  string turnLeftKey = "a";
  string turnRightKey = "d";
  string dodgeKey = "f";

  // Use this for initialization
  void Start()
  {
    playerXC = playerT.position.x;
    playerYC = playerT.position.y;
    playerZC = playerT.position.z;
    playerHealth = 75;
    gameObject.GetComponent<Renderer>().material.color = Color.white;
    playerT.gameObject.GetComponent<Renderer>().enabled = true;
    playerT.name = "playerCharacter";
    ebOld.position = energyBarT.position;
    ebOld.name = "ebPub";
    energyBarT.name = "ebName";
  }

  void OnCollisionEnter(Collision damage)
  {
    //powerups
    if (damage.gameObject.name == "weaponPowerup")
    {
      if (level < 5)
      {
        level += 1;
      }
    }

    //Damage
    if (damage.gameObject.name == "missile")
    {
      playerHealth -= 25;
      healthBarT.Translate(Vector3.up * 25);
    }
    if (damage.gameObject.name == "torpedoWhite")
    {
      if (affinity == true)
      {
        playerHealth -= 0;
      }
      if (affinity == false)
      {
        playerHealth -= 10;
        healthBarT.Translate(Vector3.up * 10);
      }
    }
    if (damage.gameObject.name == "torpedoBlack")
    {
      if (affinity == true)
      {
        playerHealth -= 10;
        healthBarT.Translate(Vector3.up * 10);
      }
      if (affinity == false)
      {
        playerHealth -= 0;
      }
    }
    if (damage.gameObject.name == "torpedoGrey")
    {
      playerHealth -= 5;
      healthBarT.Translate(Vector3.up * 5);
    }
    if (damage.gameObject.name == "fbWhite")
    {
      if (affinity == true)
      {
        playerHealth -= 0;
      }
      if (affinity == false)
      {
        playerHealth -= 5;
        healthBarT.Translate(Vector3.up * 5);
      }
    }
    if (damage.gameObject.name == "fbBlack")
    {
      if (affinity == true)
      {
        playerHealth -= 5;
        healthBarT.Translate(Vector3.up * 5);
      }
      if (affinity == false)
      {
        playerHealth -= 0;
      }
    }
    if (damage.gameObject.name == "fbGrey")
    {
      playerHealth -= 2;
      healthBarT.Translate(Vector3.up * 2);
    }
    if ((damage.gameObject.name == "droneBlack(Clone)") || (damage.gameObject.name == "droneBlack(Clone)") || (damage.gameObject.name == "fighterBlack(Clone)") || (damage.gameObject.name == "fighterWhite(Clone)") || (damage.gameObject.name == "platformWhite(Clone)") || (damage.gameObject.name == "platformBlack(Clone)"))
    {
      playerHealth -= 50;
      healthBarT.Translate(Vector3.up * 50);
    }
    if (damage.gameObject.name == "suicideBomber")
    {
      playerHealth -= 100;
      healthBarT.Translate(Vector3.up * 100);
    }
    if (playerHealth <= 0)
    {
      playerT.gameObject.GetComponent<Renderer>().enabled = false;
      shoot = false;
      if (lives != 1)
      {
        Rigidbody restartRBI = Instantiate(restartButtonRB, restartButtonT.position, restartButtonT.rotation) as Rigidbody;
        restartRBI.name = "restartButton";
      }
      playerXC = 7;
      playerYC = 70;
      playerZC = 243;
      if (lives == 4)
      {
        life1.Translate(Vector3.left * 100);
      }
      if (lives == 3)
      {
        life2.Translate(Vector3.left * 100);
      }
      if (lives == 2)
      {
        life3.Translate(Vector3.left * 100);
      }
      if (lives == 1)
      {
        Rigidbody gamerOverI = Instantiate(gameOverButtonRB, restartButtonT.position, restartButtonT.rotation) as Rigidbody;
        gamerOverI.name = "gameOverButton";
        quit = true;
      }
    }
    Destroy(damage.gameObject);
  }

  void down45degrees()
  {
    if (rotate < 9)
    {
      playerT.Rotate(Vector3.down * 5);
      rotate += 1;
    }
    else
    {
      turnDown = false;
      rotate = 0;
    }
  }

  void up45degrees()
  {
    if (rotate < 9)
    {
      playerT.Rotate(Vector3.up * 5);
      rotate += 1;
    }
    else
    {
      turnUp = false;
      rotate = 0;
    }
  }
  void CreateBullet(Vector3 location, Vector3 forceForward, Vector3 forceHorizontal , Quaternion rotation )
  {
    bulletPrefabTransform.Translate(location);
   var bulletInstance = Instantiate(bulletPrefab, bulletPrefabTransform.position, bulletPrefabTransform.rotation * rotation * Quaternion.AngleAxis(-90, Vector3.right)) as Rigidbody;
    bulletInstance.AddForce(forceForward);
    bulletInstance.AddForce(forceHorizontal );
    Destroy(bulletInstance.gameObject, 3.0f);
    SetBulletProperties(bulletInstance);

  }
  void gun()
  {
    //Determine Bullet Type
    if (flip == false)
    {
      if ((leanLeft == true) || (leanRight == true))
      {
        if (leanLeft == true)
        {
          type = 1;
        }
        if (leanRight == true)
        {
          type = 2;
        }
      }
      else
      {
        type = 3;
      }
    }
    if (flip == true)
    {
      if ((leanLeft == true) || (leanRight == true))
      {
        if (leanLeft == true)
        {
          type = 4;
        }
        if (leanRight == true)
        {
          type = 5;
        }
      }
      else
      {
        type = 6;
      }
    }

    //Affinity Shift
    aTimer -= Time.deltaTime;
    if (Input.GetButtonDown("Affinity"))
    {
      if (aTimer <= 0.0)
      {
        if (affinity == true)
        {
          gameObject.GetComponent<Renderer>().material.color = Color.black;
          affinity = false;
        }
        else
        {
          gameObject.GetComponent<Renderer>().material.color = Color.white;
          affinity = true;
        }
        aTimer = 0.2;
      }
    }

    //Use blade
    if ((Input.GetButtonDown("Fire3")) && (blade == false))
    {
      blade = !blade;
    }

    if (blade == true)
    {
      bladeT.position = playerT.position;
      bTimer1 -= Time.deltaTime;
      if (bTimer1 <= 0)
      {
        blade = false;
        bTimer1 = 0.37;
      }
    }
    else
    {
      bladeT.position = bladeTO.position;
    }

    //Screen clear attack
    if (chargeAttack == true)
    {
      if (Input.GetKey(chargeKey))
      {
        aoe = true;
      }
      if (aoe == true)
      {
        if (energyBarT.position.z > ebOld.position.z - 72)
        {
          energyBarT.Translate(Vector3.up * 1);
        }
        else
        {
          explosion.Play();
          explosionTimer -= Time.deltaTime;
          if (explosionTimer <= 0)
          {
            explosion.Stop();
            chargeAttack = false;
            explosionTimer = 0.1;
            aoe = false;
          }
        }
      }
    }
    else
    {
      if (energyBarT.position.z < ebOld.position.z)
      {

      }
      else
      {
        chargeAttack = true;
      }
    }
    if (explosionCooldown == true)
    {
      explosionTimer = 1.5;
    }

    //Shoot
    mgTimer -= Time.deltaTime;
    mTimer -= Time.deltaTime;
    if (Input.GetButton("Fire1"))
    {
      if ((machineGun == true) && (mgTimer <= 0))
      {
        Rigidbody bulletInstance;
        bulletPrefabTransform.position = playerT.position;
        bulletPrefabTransform.rotation = playerT.rotation;
        mgTimer = 0.1;
        if (level >= 0)
        {
          if (focus == true)
          {
            CreateBullet( Vector3.left * 4, playerT.forward * 6000, Vector3.zero, Quaternion.identity );
            CreateBullet(Vector3.right * 8, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
          }
          if (spreader == true)
          {
            CreateBullet(Vector3.left * 4, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
            CreateBullet(Vector3.right * 8, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
          }
        }
        if (level >= 1)
        {
          if (focus == true)
          {
            CreateBullet(Vector3.left * 10, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
            CreateBullet(Vector3.right * 12, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
          }
          if (spreader == true)
          {
            CreateBullet(Vector3.left*10, playerT.forward*6000, playerT.right*-2000, Quaternion.AngleAxis(-10, Vector3.up));
            CreateBullet(Vector3.right * 12, playerT.forward * 6000, playerT.right * 2000, Quaternion.AngleAxis(10, Vector3.up));
          }
        }
        if (level >= 2)
        {
          if (focus == true)
          {
            CreateBullet(Vector3.left * 14, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
            CreateBullet(Vector3.right * 16, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
          }
          if (spreader == true)
          {
            CreateBullet(Vector3.left * 14, playerT.forward * 6000, playerT.right * -4000, Quaternion.AngleAxis(-20, Vector3.up));
            CreateBullet(Vector3.right * 16, playerT.forward * 6000, playerT.right * 4000, Quaternion.AngleAxis(20, Vector3.up));
          }
        }
        if (level >= 3)
        {
          if (focus == true)
          {
            CreateBullet(Vector3.left * 18, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
            CreateBullet(Vector3.right * 20, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
          }
          if (spreader == true)
          {
            CreateBullet(Vector3.left * 18, playerT.forward * 6000, playerT.right * -6000, Quaternion.AngleAxis(-40, Vector3.up));
            CreateBullet(Vector3.right * 20, playerT.forward * 6000, playerT.right * 6000, Quaternion.AngleAxis(40, Vector3.up));
          }
        }
        if (level >= 4)
        {
          if (focus == true)
          {
            CreateBullet(Vector3.left * 22, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
            CreateBullet(Vector3.right * 24, playerT.forward * 6000, Vector3.zero, Quaternion.identity);
          }
          if (spreader == true)
          {
            CreateBullet(Vector3.left * 22, playerT.forward * 6000, playerT.right * -8000, Quaternion.AngleAxis(-50, Vector3.up));
            CreateBullet(Vector3.right * 24, playerT.forward * 6000, playerT.right * 8000, Quaternion.AngleAxis(50, Vector3.up));

          }
        }
      }
      if ((missiles == true) && (mTimer <= 0))
      {
        Rigidbody missileInstance;
        missilePrefabTransform.position = playerT.position;
        mTimer = 0.4;
        CreateMissiles();
      }
    }

    //Turn missiles on and off
    if (Input.GetButtonDown("Fire2"))
    {
      missiles = !missiles;
    }

    //Switch between spreader and focus mode
    if (Input.GetKeyDown(switchGunKey))
    {
      if (focus == true)
      {
        spreader = true;
        focus = false;
      }
      else
      {
        spreader = false;
        focus = true;
      }
    }
  }

  private void CreateMissiles()
  {
    Rigidbody missileInstance;
    Quaternion rotation = Quaternion.identity;
    if (flip)
      rotation = Quaternion.AngleAxis(-180, Vector3.right);
      missilePrefabTransform.Translate(Vector3.left * 2);
      missileInstance = Instantiate(missilePrefab, missilePrefabTransform.position, missilePrefabTransform.rotation * rotation ) as Rigidbody;
      missileInstance.AddForce(playerT.forward * 4000);
      Destroy(missileInstance.gameObject, 4.0f);
      missilePrefabTransform.Translate(Vector3.right * 4);
      missileInstance = Instantiate(missilePrefab, missilePrefabTransform.position, missilePrefabTransform.rotation * rotation ) as Rigidbody;
      missileInstance.AddForce(playerT.forward * 4000);
      Destroy(missileInstance.gameObject, 4.0f);
  }

  private void SetBulletProperties(Rigidbody bulletInstance)
  {
    if (affinity == true)
    {
      bulletInstance.gameObject.GetComponent<Renderer>().material.color = Color.white;
      bulletInstance.gameObject.name = "bulletWhite";
    }
    else
    {
      bulletInstance.gameObject.GetComponent<Renderer>().material.color = Color.black;
      bulletInstance.gameObject.name = "bulletBlack";
    }
  }

  // Update is called once per frame
  void Update()
  {
    explosion.transform.position = playerT.position;
    bladeOX = playerT.position.x;
    bladeOY = playerT.position.y;
    bladeOZ = playerT.position.z;
    if (quit == true)
    {
      quitCountDown -= Time.deltaTime;
      playerT.gameObject.GetComponent<Renderer>().enabled = false;
      shoot = false;
      if (quitCountDown <= 0)
      {
        Application.LoadLevel("mainmenu");
      }
    }
    //Pause 
    if (Input.GetKeyUp("p"))
    {
      pause = !pause;
    }
    if (pause == false)
    {
      Time.timeScale = 1;
    }
    else
    {
      Time.timeScale = 0;
    }

    if (shoot == false)
    {
      if (Input.GetKey("r"))
      {
        lives -= 1;
        shoot = true;
        pause = false;
        playerT.gameObject.GetComponent<Renderer>().enabled = true;
        healthBarT.Translate(Vector3.down * (-playerHealth + 75));
        energyBarT.position = ebOld.position;
        GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: 0";
        playerHealth = 75;
        level = 0;
      }
    }
    else
    {
      if (GameObject.Find("restartButton") != null)
      {
        Destroy(GameObject.Find("restartButton"));
      }
    }

    if (pause == false)
    {
      //Boundaries
      dodgeCancel = false;
      if (playerT.position.x >= 72)
      {
        playerXC -= 1;
        dodgeCancel = true;
      }
      if (playerT.position.x <= -63)
      {
        playerXC += 1;
        dodgeCancel = true;
      }
      if (playerT.position.z <= 176)
      {
        playerZC += 1;
        dodgeCancel = true;
      }
      if (playerT.position.z >= 284)
      {
        playerZC -= 1;
        dodgeCancel = true;
      }

      if (Input.GetButtonDown("HeightUp") && IsLower)
      {
        IsLower = false;

      }
      if (Input.GetButtonDown("HeightDown") && IsLower == false)
      {
        IsLower = true;
      }

      if (IsLower)
        playerYC = 60;
      else
        playerYC = 70;
      //Movement
      playerT.position = new Vector3(playerXC, playerYC, playerZC);
      if (dodge == false)
      {
        if (dodgeTimer <= 0.0)
        {
          boost = false;
          dodge = true;
        }
        else
        {
          dodgeTimer -= Time.deltaTime;
          dodgeTimer2 = 1.0;
        }
      }
      else
      {
        dodgeTimer2 -= Time.deltaTime;
        if (dodgeTimer2 <= 0.0)
        {
          boost = true;
          dodgeTimer = 0.1;
        }
      }
      float vertical = Input.GetAxis("Vertical");
      if (vertical != 0)
      {
        if (vertical < 0)
        {
          up = true;
          down = false;
        }
        else
        {
          down = true;
          up = false;
        }
        float sign = -Mathf.Sign(vertical);
        playerZC += sign * 1;
        if (Input.GetButtonDown("Dodge") && (dodge == true) && (boost == true))
        {
          dodge = false;
        }
        if (dodge == false)
        {
          if (dodgeCancel == false)
          {
            playerZC += sign * 6;
          }
        }
      }
      else
      {
        down = false;
        up = false;
      }
      float horizontal = Input.GetAxis("Horizontal");

      if (horizontal != 0)
      {
        if (horizontal < 0)
        {
          left = true;
          right = false;
        }
        else
        {
          left = false;
          right = true;
        }
        float sign = -Mathf.Sign(horizontal);

        playerXC += sign * 1;
        if (Input.GetButtonDown("Dodge") && (dodge == true) && (boost == true))
        {
          dodge = false;
        }
        if (dodge == false)
        {
          if (dodgeCancel == false)
          {
            playerXC += sign * 6;
          }
        }
      }
      else
      {
        left = false;
        right = false;
      }

      //Lean and Flip
      if (Input.GetButtonDown("Flip"))
      {
        if (leanLeft == true)
        {
          if (flip == false)
          {
            playerT.Rotate(Vector3.down * 90);
          }
          if (flip == true)
          {
            playerT.Rotate(Vector3.down * -90);
          }
        }
        else if (leanRight == true)
        {
          if (flip == false)
          {
            playerT.Rotate(Vector3.down * -90);
          }
          if (flip == true)
          {
            playerT.Rotate(Vector3.down * 90);
          }
        }
        else if ((leanLeft == false) && (leanRight == false))
        {
          playerT.Rotate(Vector3.down * 180);
        }

        //Flip
        if (flip == false)
        {
          flip = true;
        }
        else
        {
          flip = false;
        }
      }
      if ((turnUp == false) && (turnDown == false))
      {
        float turn = Input.GetAxis("Turn");
        if (flip == false)
        {
          if (turn > 0)
          {
            if (center == true)
            {
              turnUp = true;
              leanRight = true;
              leanLeft = false;
              center = false;
            }
            if (leanLeft == true)
            {
              turnUp = true;
              leanRight = false;
              leanLeft = false;
              center = true;
            }
          }
          else if (turn < 0)
          {
            if (center == true)
            {
              turnDown = true;
              leanRight = false;
              leanLeft = true;
              center = false;
            }
            if (leanRight == true)
            {
              turnDown = true;
              leanRight = false;
              leanLeft = false;
              center = true;
            }
          }
        }
        if (flip == true)
        {
          if (turn > 0)
          {
            if (center == true)
            {
              turnDown = true;
              leanRight = true;
              leanLeft = false;
              center = false;
            }
            if (leanLeft == true)
            {
              turnDown = true;
              leanRight = false;
              leanLeft = false;
              center = true;
            }
          }
          else if (turn < 0)
          {
            if (center == true)
            {
              turnUp = true;
              leanRight = false;
              leanLeft = true;
              center = false;
            }
            if (leanRight == true)
            {
              turnUp = true;
              leanRight = false;
              leanLeft = false;
              center = true;
            }
          }
        }
      }

      if (turnDown == true)
      {
        down45degrees();
        turnUp = false;
      }
      if (turnUp == true)
      {
        up45degrees();
        turnDown = false;
      }

      //Shoot 
      if (shoot == true)
      {
        gun();
      }

    }
  }
}
