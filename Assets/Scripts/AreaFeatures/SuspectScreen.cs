using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuspectScreen : MonoBehaviour
{
  public TextMeshProUGUI resultText;
  public TextMeshProUGUI[] suspectNames;

  public SuspectEntity[] suspectObjects;
  public GameObject restartButton;

  private int[] notSelectedSuspects;
  private int chosenSuspect = -1;

  private int revealState = 0;
  private float anticipCounter;

  public float _anticipationTime;



  private void OnEnable()
  {
    restartButton.SetActive(false);

    if (Engine.settings.playerType == 1)
    {
      for (int i = Mathf.CeilToInt(suspectObjects.Length / 2)+1; i < suspectObjects.Length; i++)
      {
        suspectObjects[i].isActive = false;
        suspectObjects[i].gameObject.GetComponentInChildren<CharacterManager>().SetDarkened(true);
      }
    }
    else
    {
      for (int i = 0; i < Mathf.CeilToInt(suspectObjects.Length / 2)+1; i++)
      {
        suspectObjects[i].isActive = false;
        suspectObjects[i].gameObject.GetComponentInChildren<CharacterManager>().SetDarkened(true);
      }
    }


    resultText.text = "";
    for (int i = 0; i < suspectNames.Length; i++)
    {
      suspectNames[i].text = Engine.caseManager.suspectNames[i];
      if (i == Engine.caseManager.killerId)
      {
        suspectObjects[i].gameObject.GetComponentInChildren<CharacterManager>().isKiller = true;
      }
      else
      {
        suspectObjects[i].gameObject.GetComponentInChildren<CharacterManager>().isSuspect = true;
      }
    }
    notSelectedSuspects = new int[4];
    anticipCounter = _anticipationTime;
  }

  private void Update()
  {
    // Hide unpicked suspects
    if (revealState == 1)
    {
      foreach (int id in notSelectedSuspects)
      {
        suspectObjects[id].heightDif = -6f;
      }
      revealState = 2;
    }
    // Wait... then reveal killer
    if (revealState == 2)
    {
      anticipCounter -= 1 * Time.deltaTime * 60f;
      if (anticipCounter <= 0)
      {
        suspectObjects[Engine.caseManager.killerId].heightDif = 0;
        suspectObjects[Engine.caseManager.killerId].gameObject.GetComponentInChildren<CharacterManager>().SetDarkened(false);
        suspectNames[Engine.caseManager.killerId].color = Color.red;
        restartButton.SetActive(true);

        SetResultText(Engine.caseManager.killerId == chosenSuspect);

        revealState = 3;
      }
    }
  }

  public void PickSuspect(int id)
  {

    // Get list of not selected suspects
    int notSelectedCounter = 0;
    for (int i = 0; i < suspectObjects.Length; i++)
    {
      if (i != id)
      {
        notSelectedSuspects[notSelectedCounter] = i;
        notSelectedCounter += 1;
      }
    }
    chosenSuspect = id;
    revealState = 1;
  }

  public void SetResultText(bool win)
  {
    if (win)
    {
      resultText.text = "<color=green>YOU GOT THE KILLER! YOU WIN!</color>";
    }
    else
    {
      resultText.text = "<color=red>THE KILLER ROAMS FREE! YOU LOSE!</color>";
    }
  }

  public bool HasPickedSuspect()
  {
    return (chosenSuspect == -1 ? false : true);
  }


}
