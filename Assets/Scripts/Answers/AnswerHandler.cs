using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerHandler : MonoBehaviour
{
  public TextMeshProUGUI sentence;
  public TextMeshProUGUI confidence;

  public void Start()
  {
    SetSentence(Engine.witnessManager.currentQueuedAnswer);
    SetConfidence(Engine.witnessManager.confidence.part, Engine.witnessManager.confidence.total);
  }

  public void SetSentence(string phrase)
  {
    sentence.text = phrase;
  }

  public void SetConfidence(int correct, int total)
  {
    confidence.text = "<color=green>" + correct + "/" + total + "</color>" + " of the " + "<color=red>statements</color>" + " are correct.";
  }
}
