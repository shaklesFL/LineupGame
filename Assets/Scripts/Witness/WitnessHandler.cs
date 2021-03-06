﻿using System.Collections;
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

  public int currentWitnessId = 0;

  public string currentQueuedAnswer;
  public Confidence confidence;

  public List<CharacterManager> _witnessList;
  public GameObject characterObject;

  public void Start()
  {
    confidence.part = 1;
    confidence.total = 1;

    // Create witness objects
    createWitnesses(4);
  }

  public void UpdateSentence(int button)
  {
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
    int chanceOfTruth = 20;
    // Chance of having full struth instead of random pick

    int trueCount = 0;
    int totalCount = 0;

    // go through each element in sentence and replace the keywords associated with them
    foreach (int id in elementList.allElementsList.Values)
    {
      ElementBlock el = elementList.elements[id];
      print(el.refName);
      print(elementList.allElementsList.Count);
      if (sentence.Contains(el.refName))
      {
        print("HIT");
        int typeIndex = 0;

        // Only gives full correct answer if there's only been less than 2 correct so far
        if (Random.Range(0, 100) <= chanceOfTruth && trueCount<=0)
        {
          typeIndex = Engine.caseManager.elementAnswers[el.refName];
        }
        else { 
          typeIndex = Random.Range(0, el.types.Length);
        }

        // Check to see if true
        if (isElementTrue(el.refName, typeIndex))
        {
          //print("Truth: " + el.types[typeIndex]);
          trueCount++;
        }
        totalCount++;

        string victimString = "[" + el.refName + "]";
        string killerString = "<color=red><u>" + el.types[typeIndex].name + "</u></color>";
        sentence = sentence.Replace(victimString, killerString);
      }
    }
    confidence.part = trueCount;
    confidence.total = totalCount;
    Engine.settings.AddQuestionNumber(-1);

    sentence = System.String.Format("\u201C{0}\"", sentence);

    return sentence;
  }

  public void createWitnesses(int witnessNumber)
  {
    _witnessList.Clear();
    for (int i = 0; i < witnessNumber; i++)
    {
      GameObject ob = Instantiate(characterObject, Vector3.zero, Quaternion.identity);
      ob.gameObject.transform.position += new Vector3(0, 0, 1);
      _witnessList.Add(ob.GetComponent<CharacterManager>());
    }
  }

  public ElementBlock GetElementBlockFromRef(string refName)
  {
    if (elementList.allElementsList.ContainsKey(refName))
    {
      int id = elementList.allElementsList[refName];
      ElementBlock el = elementList.elements[id];
      return el;
    }
    else
      return null;
  }

  public ElementBlock GetElementBlockFromType(int type)
  {
    print(type);
    if (elementList.allElementsIdList.ContainsKey(type))
    {
      int id = elementList.allElementsIdList[type];
      ElementBlock el = elementList.elements[id];
      print(id);
      return el;
    }
    else
      return null;
  }

  public void DeleteWitnesses()
  {
    foreach (CharacterManager cha in _witnessList)
    {
      Destroy(cha.gameObject);
    }
  }
}
