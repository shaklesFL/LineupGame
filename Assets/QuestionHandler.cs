using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class QuestionHandler : MonoBehaviour
{
  public Button[] optionBtn;

  // Start is called before the first frame update
  void Start()
  {
    // Apprently you can't put this in a for loop... dope.
    optionBtn[0].onClick.AddListener(delegate { OptionClicked(0); });
    optionBtn[1].onClick.AddListener(delegate { OptionClicked(1); });
    optionBtn[2].onClick.AddListener(delegate { OptionClicked(2); });
    optionBtn[3].onClick.AddListener(delegate { OptionClicked(3); });
  }

  public void OptionClicked(int option)
  {

    Engine.areaManager.GoToScreen("Answer");
    Engine.witnessManager.UpdateSentence(option);
  }

}
