using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterBodyPart
{
  public string _partName;
  public GameObject _bodyPoint;
  [SerializeField]
  private BodyFeatures _partType;
  [HideInInspector]
  public int _partId
  {
    get { return (int)_partType; }
  }

}
