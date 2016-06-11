using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

  public playerControls player;
  int MaxEnergy;
  float unit;
  RectTransform t;
  RectTransform barTransform;
  int CurrentEnergy;

  // Use this for initialization
  void Start () {
    MaxEnergy = player.MaxEnergy;
    t = (RectTransform)transform;
    CurrentEnergy = player.GetEnergy();
    unit = t.rect.height / MaxEnergy;
    barTransform = GetComponentInChildren<RectTransform>();
  }

  // Update is called once per frame
  void Update () {
    int diff = CurrentEnergy - player.GetEnergy();
    if (diff != 0)
    {
      if (player.GetHealth() < MaxEnergy)
      {
        barTransform.transform.Translate(Vector3.down * diff);
        CurrentEnergy  = player.GetEnergy();
      }
      else
      {
        barTransform.transform.Translate(Vector3.up * (MaxEnergy - CurrentEnergy));
        CurrentEnergy = MaxEnergy;
      }
    }
  }
}
