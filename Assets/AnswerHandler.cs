using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerHandler : MonoBehaviour
{
  public TextMeshProUGUI sentence;

  public void Start()
  {
    SetSentence(Engine.witnessManager.currentQueuedAnswer);
  }

  public void SetSentence(string phrase)
  {
    sentence.text = phrase;
  }
}
