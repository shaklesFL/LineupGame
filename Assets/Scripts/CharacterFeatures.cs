using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFeatures
{
  public Dictionary<int, BodyPartElements> parts =
  new Dictionary<int, BodyPartElements>();

  private bool isKiller=false;
  private bool isSuspect = false;

  private List<string> innocentSims = new List<string>();
  private List<string> chosenSims = new List<string>();

  public void InitFeatures(CharacterReferences obj)
  {
    if (isSuspect)
    {
      // If innocent, create list of features to pick to be the killer's features, for similarity
      innocentSims = new List<string>();
      for (int i = 0; i < Engine.witnessManager.elementList.elements.Length; i++)
      {
        innocentSims.Add(Engine.witnessManager.elementList.elements[i].refName);
      }

      for (int i = 0; i < 3; i++)
      {
        int removeIndex = Random.Range(0, innocentSims.Count);
        chosenSims.Add(innocentSims[removeIndex]);
        innocentSims.RemoveAt(removeIndex);
      }
    }

    // Cycle through all body parts
    for (int i = 0; i < obj._bodyParts.Length; i++)
    {
      // Init body part elements
      BodyPartElements el = new BodyPartElements();

      // Cycle through each element 
      int typeId=1;
      for (int j = 0; j < Engine.witnessManager.elementList.elements.Length; j++)
      {
        Debug.Log("PartID: " + obj._bodyParts[i]._partId);

        // Check if body parts are the same
        if (Engine.witnessManager.elementList.elements[j].featureType == obj._bodyParts[i]._partId)
        {
          // If so, set their values
          Debug.Log("CORRECT: " + Engine.witnessManager.elementList.elements[j].featureType + " == " + obj._bodyParts[i]._partId);
          typeId = Random.Range(0, Engine.witnessManager.elementList.elements[j].types.Length);

          if (isKiller)
          {
            typeId = Engine.caseManager.elementAnswers[Engine.witnessManager.elementList.elements[j].refName];
          }

          if (isSuspect && chosenSims.Contains(Engine.witnessManager.elementList.elements[j].refName))       
          {
            typeId = Engine.caseManager.elementAnswers[Engine.witnessManager.elementList.elements[j].refName];
          }

          if (!Engine.witnessManager.elementList.elements[j].isColour && !Engine.witnessManager.elementList.elements[j].isHeight && !Engine.witnessManager.elementList.elements[j].isMatrix)
          {
            Debug.Log("TypeID: " + typeId);
            el.elementIndex = j;
            el.typeIndex = typeId;
          }
          if (Engine.witnessManager.elementList.elements[j].isColour)
          {
            el.color = Engine.witnessManager.elementList.elements[j].types[typeId].colour;
          }
          if (Engine.witnessManager.elementList.elements[j].isHeight)
          {
            el.height = Engine.witnessManager.elementList.elements[j].types[typeId].number;
          }
          if (Engine.witnessManager.elementList.elements[j].isMatrix)
          {
            el.matrixIndex = (int)Engine.witnessManager.elementList.elements[j].types[typeId].number;
          }
        }
      }

      // Finish and apply it
      parts.Add(i, el);
    }
  }

  public void SetAsKiller()
  {
    isKiller = true;
  }

  public void SetAsInnocent()
  {
    isSuspect = true;
  }

  /*public Sprite GetFeatureImage(string refName)
  {
    return (Engine.witnessManager.GetElementBlockFromRef(refName).types[featureList[refName]].image);
  }

  public Sprite GetFeatureImage(int refId)
  {
    return (Engine.witnessManager.GetElementBlockFromType(refId).types[featureIdList[refId]].image);
  }

  public Color GetFeatureColour(int refId)
  {
    if (Engine.witnessManager.GetElementBlockFromType(refId).isColour)
    {
      return (Engine.witnessManager.GetElementBlockFromType(refId).types[featureIdList[refId]].colour);
    }
    else
    {
      return Color.white;
    }
  }*/
}
