using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
  public Dictionary<string, int> elementAnswers =
  new Dictionary<string, int>();

  public int killerId;
  [HideInInspector]
  public string[] suspectNames;

  public string[] _randomSuspectNameList;
  [HideInInspector]
  public string[] witnessNames;

  public string[] _randomWitnessNameList;

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

    /*elementAnswers["hairLength"] = 2;
    elementAnswers["hairColour"] = 0;
    elementAnswers["hairType"] = 0;
    elementAnswers["skinColour"] = 0;
    elementAnswers["height"] = 1;
    elementAnswers["mouthSize"] = 1;
    elementAnswers["noseSize"] = 1;
    elementAnswers["eyeColour"] = 2;
    elementAnswers["glassesType"] = 2;
    elementAnswers["shirtType"] = 1;
    elementAnswers["shirtColour"] = 1;
    elementAnswers["earringType"] = 1;*/

    RandomizeKiller();
    RandomizeWitnessNames();
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
    //killerId = 1;

    // Make pool of name ids, they'll be reduced to only unpicked ones.
    List<int> freeNames = new List<int>();
    for (int i = 0; i < _randomSuspectNameList.Length; i++)
    {
      freeNames.Add(i);
    }

    // Create new suspect names
    suspectNames = new string[5];
    for (int i = 0; i < 5; i++)
    {
      int poolId = Random.Range(0, freeNames.Count);
      int pickedId = freeNames[poolId];

      //print("Pool Id: " + poolId);
      //print("Picked Id: " + pickedId);

      suspectNames[i] = _randomSuspectNameList[pickedId];


      // Remove name id from pool
      freeNames.RemoveAt(poolId);
    }
  }

  public void RandomizeWitnessNames()
  {

    // Make pool of name ids, they'll be reduced to only unpicked ones.
    List<int> freeNames = new List<int>();
    for (int i = 0; i < _randomWitnessNameList.Length; i++)
    {
      freeNames.Add(i);
    }

    // Create new suspect names
    witnessNames = new string[5];
    for (int i = 0; i < 5; i++)
    {
      int poolId = Random.Range(0, freeNames.Count);
      int pickedId = freeNames[poolId];

      //print("Pool Id: " + poolId);
      //print("Picked Id: " + pickedId);

      witnessNames[i] = _randomWitnessNameList[pickedId];


      // Remove name id from pool
      freeNames.RemoveAt(poolId);
    }

  }

}
