using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WitnessScreen : MonoBehaviour
{
  public TextMeshProUGUI counterText;

  public GameObject[] _witnessSlots;

  public void Start()
  {
    counterText.text = Engine.settings.counterNumber.ToString();

    for (int i = 0; i < _witnessSlots.Length; i++)
    {
      Engine.witnessManager._witnessList[i].moveCharacterTo(_witnessSlots[i].transform.position, _witnessSlots[i].transform.localScale);
    }
  }
}
