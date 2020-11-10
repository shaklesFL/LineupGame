using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
  [SerializeField]
  private string _seed;
  public string seed => _seed;

  [SerializeField]
  private int _playerType;
  public int playerType => _playerType;

  public void SetSeed(string newSeed)
  {
    _seed = newSeed;
    Random.InitState(_seed.GetHashCode());
  }

  public void SetPlayerType(int playerChoice)
  {
    _playerType = playerChoice;
  }
}
