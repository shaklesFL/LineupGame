using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
  public Dictionary<string, int> elementAnswers =
  new Dictionary<string, int>();

  public void InitElements()
  {
    int seenElementId;
    for (int i = 0; i < Engine.witnessManager.elementList.elements.Length; i++)
    {
      seenElementId = Random.Range(0, Engine.witnessManager.elementList.elements[i].types.Length);
      elementAnswers.Add(Engine.witnessManager.elementList.elements[i].refName, seenElementId);
    }
  }
}
