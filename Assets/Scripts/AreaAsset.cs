using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AreaAsset
{
  [SerializeField]
  private GameObject _areaObject;
  public GameObject areaObject => _areaObject;

  [SerializeField]
  private string _areaName;
  public string areaName => _areaName;

  public bool _isActive = false;
}
