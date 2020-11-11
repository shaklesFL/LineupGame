using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Confidence
{
  public int part;
  public int total;
}

public class WitnessHandler : MonoBehaviour
{

  public ElementCreator elementList;
  public StatementCreator statementList;

  public WitnessEntity[] witnesses;
  public int currentWitnessId = 0;

  public string currentQueuedAnswer;
  public Confidence confidence;

  public void Start()
  {
    witnesses = new WitnessEntity[4];
    confidence.part = 1;
    confidence.total = 1;
    for (int i = 0; i < 4; i++)
    {
      witnesses[i] = new WitnessEntity();
      witnesses[i].InitElements();
    }
  }

  public void UpdateSentence(int button)
  {
    print(button);
    switch (button)
    {
      case 0:
        currentQueuedAnswer = GetHairAnswer();
        break;
      case 1:
        currentQueuedAnswer = GetFaceAnswer();
        break;
      case 2:
        currentQueuedAnswer = GetClothesAnswer();
        break;
      case 3:
        currentQueuedAnswer = GetBodyAnswer();
        break;
    }
  }

  public string GetHairAnswer()
  {
    int chosenIndex = Random.Range(0, statementList.regularHairStatements.Length);
    string chosenAnswer = statementList.regularHairStatements[chosenIndex];
    chosenAnswer = FormSentence(chosenAnswer);
    return chosenAnswer;
  }
  public string GetBodyAnswer()
  {
    int chosenIndex = Random.Range(0, statementList.regularBodyStatements.Length);
    string chosenAnswer = statementList.regularBodyStatements[chosenIndex];
    chosenAnswer = FormSentence(chosenAnswer);
    return chosenAnswer;
  }

  public string GetClothesAnswer()
  {
    int chosenIndex = Random.Range(0, statementList.regularClothesStatements.Length);
    string chosenAnswer = statementList.regularClothesStatements[chosenIndex];
    chosenAnswer = FormSentence(chosenAnswer);
    return chosenAnswer;
  }

  public string GetFaceAnswer()
  {
    int chosenIndex = Random.Range(0, statementList.regularFaceStatements.Length);
    string chosenAnswer = statementList.regularFaceStatements[chosenIndex];
    chosenAnswer = FormSentence(chosenAnswer);
    return chosenAnswer;
  }

  bool isElementTrue(string refName, int typeId)
  {
    if (!Engine.caseManager.elementAnswers.ContainsKey(refName))
      return false;

    if (Engine.caseManager.elementAnswers[refName] == typeId)
      return true;
    else
      return false;
  }

  string FormSentence(string sentence)
  {
    int trueCount = 0;
    int totalCount = 0;
    // go through each element in sentence and replace the keywords associated with them
    foreach (var el in elementList.elementList.Values)
    {
      if (sentence.Contains(el.refName))
      {
        int typeIndex = Random.Range(0, el.types.Length);

        // Check to see if true
        if (isElementTrue(el.refName, typeIndex))
        {
          print("Truth: " + el.types[typeIndex]);
          trueCount++;
        }
        totalCount++;

        string victimString = "[" + el.refName + "]";
        string killerString = "<color=red>" + el.types[typeIndex] + "</color>";
        sentence = sentence.Replace(victimString, killerString);
      }
    }
    Engine.witnessManager.confidence.part = trueCount;
    Engine.witnessManager.confidence.total = totalCount;
    Engine.settings.AddQuestionNumber(-1);

    return sentence;
  }

}
