using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WitnessEntityAnswers
{
  // Hair 
  int hairLength;
  int hairColour;
  int hairType;

  // Body 
  int skinColour;
  int height;

  // Face 
  int mouthSize;
  int noseSize;
  int eyeColour;

  // Clothes 
  int glassesType;
  int shirtType;
  int shirtColour;
  int earringType;
}


public class WitnessEntity
{
  public Dictionary<string, int> elementAnswers =
    new Dictionary<string, int>();

  public WitnessEntityAnswers answers;

  public bool[] activeButtons;

  public void InitElements()
  {
    activeButtons = new bool[4] { true, true, true, true };
    int seenElementId;
    for (int i = 0; i < Engine.witnessManager.elementList.elements.Length; i++)
    {
      seenElementId = Random.Range(0, Engine.witnessManager.elementList.elements[i].types.Length);
      elementAnswers.Add(Engine.witnessManager.elementList.elements[i].refName, seenElementId);
    }
  }
}
