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

    for (int i=0;i<4;i++)
    {
      if (Engine.witnessManager.witnesses[Engine.witnessManager.currentWitnessId].activeButtons[i]==false)
      {
        optionBtn[i].gameObject.GetComponent<Image>().color = Color.red;
      }
    }
  }

  public void OptionClicked(int option)
  {
    if (Engine.witnessManager.witnesses[Engine.witnessManager.currentWitnessId].activeButtons[option])
    {
      if (Engine.settings.counterNumber >= 1)
      {
        Engine.areaManager.GoToScreen("Answer");
        Engine.witnessManager.UpdateSentence(option);
        Engine.witnessManager.witnesses[Engine.witnessManager.currentWitnessId].activeButtons[option] = false;
      }
    }
  }

}
