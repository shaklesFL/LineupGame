using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ElementBlock
{
  [Header("----------- ELEMENT -----------")]
  public string refName;
  [Space]
  public ElementType[] types;
  [Space]
  public bool isColour;
  public bool isHeight;
  public bool isMatrix;
  [SerializeField]
  private BodyFeatures _partType;
  [HideInInspector]
  public int featureType
  {
    get { return (int)_partType; }
  }
}
