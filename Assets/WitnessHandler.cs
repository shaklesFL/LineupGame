using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitnessHandler : MonoBehaviour
{
  public string[] regularHairStatements;
  public string[] regularClothesStatements;
  public string[] regularBodyStatements;
  public string[] regularFaceStatements;


  public ElementCreator elementList;


  public WitnessEntity[] witnesses;

  public string currentQueuedAnswer;



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
    int chosenIndex = Random.Range(0, regularHairStatements.Length);
    string chosenAnswer = regularHairStatements[chosenIndex];
    chosenAnswer = FormSentence(chosenAnswer);
    return chosenAnswer;
  }
  public string GetBodyAnswer()
  {
    int chosenIndex = Random.Range(0, regularBodyStatements.Length);
    string chosenAnswer = regularBodyStatements[chosenIndex];
    chosenAnswer = FormSentence(chosenAnswer);
    return chosenAnswer;
  }

  public string GetClothesAnswer()
  {
    int chosenIndex = Random.Range(0, regularClothesStatements.Length);
    string chosenAnswer = regularClothesStatements[chosenIndex];
    chosenAnswer = FormSentence(chosenAnswer);
    return chosenAnswer;
  }

  public string GetFaceAnswer()
  {
    int chosenIndex = Random.Range(0, regularFaceStatements.Length);
    string chosenAnswer = regularFaceStatements[chosenIndex];
    chosenAnswer = FormSentence(chosenAnswer);
    return chosenAnswer;
  }


  string FormSentence(string sentence)
  {
    // go through each element and replace the keywords associated with them
    foreach (var el in elementList.elementList.Values)
    {
      print("PART1");
      if (sentence.Contains(el.refName))
      {
        print("PART2");
        int typeIndex = Random.Range(0, el.types.Length);
        string victimString = "[" + el.refName + "]";
        string killerString = "<color=red>" + el.types[typeIndex] + "</color>";
        sentence = sentence.Replace(victimString, killerString);
      }
    }

    return sentence;
  }

}
