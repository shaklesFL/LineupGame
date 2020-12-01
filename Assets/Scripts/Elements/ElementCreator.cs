using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCreator : MonoBehaviour
{
  public ElementBlock[] elements;

  public Dictionary<string, int> elementList =
    new Dictionary<string, int>();

  public Dictionary<int, int> elementIdList =
    new Dictionary<int, int>();

  public Dictionary<int, int> colourIdList =
    new Dictionary<int, int>();

  // Start is called before the first frame update
  void Start()
  {
    // Add all of the references into dictionaries for easy reference
    for (int i = 0; i < elements.Length; i++)
    {
      if (!elements[i].isColour && !elements[i].isHeight)
      {
        elementList.Add(elements[i].refName, i);
        elementIdList.Add(elements[i].featureType, i);
      }
    }

  }
}
