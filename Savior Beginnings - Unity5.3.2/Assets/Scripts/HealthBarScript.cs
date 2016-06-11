using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour
{
  public playerControls player;
  int MaxHealth;
  float unit;
  RectTransform t;
  RectTransform barTransform;
  int CurrentHealth;

	// Use this for initialization
	void Start ()
	{
	  MaxHealth = player.MaxHealth;
	  t =(RectTransform) transform;
	  CurrentHealth = player.GetHealth();
	  unit = t.rect.height/MaxHealth;
	  barTransform = GetComponentInChildren<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
    int diff = CurrentHealth - player.GetHealth();
	  if (diff != 0)
	  {
	    if (player.GetHealth() < MaxHealth)
	    {
	      barTransform.transform.Translate(Vector3.down*diff);
	      CurrentHealth  = player.GetHealth();
	    }
	    else
	    {
	      barTransform.transform.Translate(Vector3.up*(MaxHealth - CurrentHealth));
	      CurrentHealth = MaxHealth;
	    }
	  }
	}
}
