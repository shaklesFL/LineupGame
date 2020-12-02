using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ElementType 
{
  public string name;
  public Sprite[] images;
  public Color colour = Color.white;
  public float number = 0;
  public Sprite image => images[0];
}
