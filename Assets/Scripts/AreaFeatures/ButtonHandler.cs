using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
  public GameObject _witnessSlot;

  public void Start()
  {
    if (_witnessSlot != null)
    {
      Engine.witnessManager._witnessList[Engine.witnessManager.currentWitnessId].moveCharacterTo(_witnessSlot.transform.position, _witnessSlot.transform.localScale);
    }
  }

  public void NextScreen()
  {
    Engine.areaManager.GoToScreenIndex(Engine.areaManager.currentIndex);
  }

  public void GoToScreen(string name)
  {
    Engine.areaManager.GoToScreen(name);
  }

  public void RemoveWitnesses()
  {
    Engine.witnessManager.DeleteWitnesses();
  }

  public void GoBackToWitness()
  {
    //Engine.areaManager.GoToScreen(name);
  }

  public void GoToQuestionIndex(int index)
  {
    //Engine.areaManager.GoToScreen(name);
  }

  public void SelectPlayerType(int type)
  {
    Engine.settings.SetPlayerType(type);
    Engine.caseManager.InitElements();
  }

  public void QuestionOption1()
  {
    Engine.areaManager.GoToScreen("Answer");
  }

  public void QuestionOption2()
  {
    Engine.areaManager.GoToScreen("Answer");
  }

  public void QuestionOption3()
  {
    Engine.areaManager.GoToScreen("Answer");
  }

  public void QuestionOption4()
  {
    Engine.areaManager.GoToScreen("Answer");
  }

  public void PickSuspect(int id)
  {
    Engine.caseManager.pickedSuspect = id;
    GetComponent<SuspectScreen>().PickSuspect(id);
  }

  public void RestartGame()
  {
    SceneManager.LoadScene("Game");
  }


  // Witnesses ---------------------------------------------

  public void Witness(int id)
  {
    Engine.areaManager.GoToScreen("Questions");
    Engine.witnessManager.currentWitnessId = id;
    //print(id);

  }

  public void SelectSeed(string name)
  {
    Engine.settings.SetSeed(GetComponent<SeedInputHandler>().seedBox.text);
    print("SEED IS: " + Engine.settings.seed);
    Engine.areaManager.GoToScreen(name);
  }
}
