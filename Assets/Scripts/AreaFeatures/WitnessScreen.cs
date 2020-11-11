using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WitnessScreen : MonoBehaviour
{
  public TextMeshProUGUI counterText;

  public void Start()
  {
    counterText.text = Engine.settings.counterNumber.ToString();
  }
}
