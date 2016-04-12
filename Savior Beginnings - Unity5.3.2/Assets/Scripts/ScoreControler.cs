using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreControler : MonoBehaviour
{
  public float Score;

  private static ScoreControler _controler;
  private bool UpdateNeeded;
  private Text text;

  public static ScoreControler Get()
  {
    return _controler;
  }
  // Use this for initialization
  void Start()
  {
    _controler = this;
    Score = 0;
  }

  // Update is called once per frame
  void Update()
  {
    if (UpdateNeeded)
    {
      text.text = string.Format("Score: {0:F0}", Score);
    }
  }

  internal void AddScore(float increment)
  {
    UpdateNeeded = true;
    Score += increment;
  }
}
