﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
  public Dictionary<string, int> elementAnswers =
  new Dictionary<string, int>();

  public int killerId;

  public string[] suspectNames;

  public string[] _randomNameList;

  [HideInInspector]
  public int pickedSuspect;

  public void InitElements()
  {
    pickedSuspect = -1;
    elementAnswers.Clear();

    int seenElementId;
    for (int i = 0; i < Engine.witnessManager.elementList.elements.Length; i++)
    {
      seenElementId = Random.Range(0, Engine.witnessManager.elementList.elements[i].types.Length);
      elementAnswers.Add(Engine.witnessManager.elementList.elements[i].refName, seenElementId);
    }

    RandomizeKiller();
  }

  public void RandomizeEverything()
  {
    InitElements();
    RandomizeKiller();
  }

  public void RandomizeKiller()
  {

    // Randomize killer position
    killerId = Random.Range(0, 5);

    // Make pool of name ids, they'll be reduced to only unpicked ones.
    List<int> freeNames = new List<int>();
    for (int i=0;i<_randomNameList.Length;i++)
    {
      freeNames.Add(i);
    }

    // Create new suspect names
    suspectNames = new string[5];
    for (int i = 0; i < 5; i++)
    {
      int poolId = Random.Range(0, freeNames.Count);
      int pickedId = freeNames[poolId];

      print("Pool Id: " + poolId);
      print("Picked Id: " + pickedId);

      suspectNames[i] = _randomNameList[pickedId];


      // Remove name id from pool
      freeNames.RemoveAt(poolId);
    }
  }

}