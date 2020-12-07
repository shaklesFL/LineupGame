using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class QuestionHandler : MonoBehaviour
{
  public Button[] optionBtn;
  public TextMeshProUGUI nameText;
  public TextMeshProUGUI counterText;

  // Start is called before the first frame update
  void Start()
  {
    counterText.text = Engine.settings.counterNumber.ToString();

    nameText.SetText("What would you like <color=red>" + Engine.caseManager.witnessNames[Engine.witnessManager.currentWitnessId] + "</color> to describe?");

    // Apprently you can't put this in a for loop... dope.
    optionBtn[0].onClick.AddListener(delegate { OptionClicked(0); });
    optionBtn[1].onClick.AddListener(delegate { OptionClicked(1); });
    optionBtn[2].onClick.AddListener(delegate { OptionClicked(2); });
    optionBtn[3].onClick.AddListener(delegate { OptionClicked(3); });

    for (int i = 0; i < 4; i++)
    {
      if (Engine.witnessManager._witnessList[Engine.witnessManager.currentWitnessId].entity.activeButtons[i] == false)
      {
        optionBtn[i].gameObject.GetComponent<Image>().color = Color.red;
      }
    }
  }

  public void OptionClicked(int option)
  {
    if (Engine.witnessManager._witnessList[Engine.witnessManager.currentWitnessId].entity.activeButtons[option])
    {
      if (Engine.settings.counterNumber >= 1)
      {
        string stringId = "alien1";
        if (Random.Range(0, 100) > 50)
        {
          stringId = "alien2";
        }

        Engine.audioManager.Play(stringId);
        Engine.areaManager.GoToScreen("Answer");
        Engine.witnessManager.UpdateSentence(option);
        Engine.witnessManager._witnessList[Engine.witnessManager.currentWitnessId].entity.activeButtons[option] = false;
      }
    }
  }

}
