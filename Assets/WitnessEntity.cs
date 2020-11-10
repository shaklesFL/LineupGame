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
  public WitnessEntityAnswers answers;

  public bool hairActive = true;
  public bool bodyActive = true;
  public bool faceActive = true;
  public bool clothesActive = true;
}
