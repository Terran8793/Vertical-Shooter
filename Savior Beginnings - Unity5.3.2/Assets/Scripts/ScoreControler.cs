using UnityEngine;
using System.Collections;
using System;

public class ScoreControler : MonoBehaviour
{
  private static ScoreControler _controler;
  public static ScoreControler Get()
  {
    return _controler;
  }
	// Use this for initialization
	void Start ()
	{
	  _controler = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  internal void AddScore(float increment)
  {
    throw new NotImplementedException();
  }
}
