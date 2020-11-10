using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCreator : MonoBehaviour
{
  public ElementBlock[] elements;

  public Dictionary<string, ElementBlock> elementList =
    new Dictionary<string, ElementBlock>();

  // Start is called before the first frame update
  void Start()
  {
    // Add all of the elements into a dictionary for easy reference
    for (int i = 0; i < elements.Length; i++)
    {
      elementList.Add(elements[i].refName, elements[i]);
    }
  }
}
