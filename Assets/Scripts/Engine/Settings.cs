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

  [SerializeField]
  private int _counterNumber = 10;
  public int counterNumber => _counterNumber;

  public void SetSeed(string newSeed)
  {
    _seed = newSeed;
    Random.InitState(_seed.GetHashCode());
  }

  public void SetPlayerType(int playerChoice)
  {
    _playerType = playerChoice;
  }

  public void SetQuestionCounter(int number)
  {
    _counterNumber = number;
  }

  public void AddQuestionNumber(int change)
  {
    _counterNumber += change;
  }
}
