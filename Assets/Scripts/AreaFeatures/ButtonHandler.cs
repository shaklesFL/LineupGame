using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject alien1;
    public GameObject alien2;
    public GameObject alien3;
    public GameObject alien4;

    public void NextScreen()
  {
    Engine.areaManager.GoToScreenIndex(Engine.areaManager.currentIndex);
  }

  public void GoToScreen(string name)
  {
    Engine.areaManager.GoToScreen(name);
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
    if (type==1)
    {
      Engine.caseManager.InitElements();
    }
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


  // Witnesses ---------------------------------------------

  public void Witness(int id)
  {
    Engine.areaManager.GoToScreen("Questions");
    Engine.witnessManager.currentWitnessId = id;
    print(id);       
    
  }

  public void SelectSeed(string name)
  {
    Engine.settings.SetSeed(GetComponent<SeedInputHandler>().seedBox.text);
    print("SEED IS: " + Engine.settings.seed);
    Engine.areaManager.GoToScreen(name);
  }
}
