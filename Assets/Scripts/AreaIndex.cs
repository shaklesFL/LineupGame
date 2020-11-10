using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaIndex : MonoBehaviour
{
  [SerializeField]
  private AreaAsset[] _areas;

  Dictionary<string, int> areaList =
    new Dictionary<string, int>();

  public int lastScreen = -1;
  private GameObject lastScreenObject;

  [SerializeField]
  private int _currentIndex = 0;
  public int currentIndex=>_currentIndex;

  public void Start()
  {
    // Add all of the areas into a dictionary for easy reference
    for(int i=0;i<_areas.Length;i++)
    {
      areaList.Add(_areas[i].areaName, i);
    }
    GoToScreenIndex(0);
  }

  public void Update()
  {
    if (Input.GetKeyDown("space"))
    {
      _currentIndex += 1;
      GoToScreenIndex(currentIndex);
    }
  }

  public void GoToScreenIndex(int newScreen)
  {
    SwitchScreenWith(newScreen);
  }

  public void GoToScreen(string newScreen)
  {
    int screenIndex = areaList[newScreen];

    SwitchScreenWith(screenIndex);
  }

  private void SwitchScreenWith(int screenIndex)
  {
    // Destroy last screen
    if (lastScreen != -1)
    {
      Destroy(transform.GetChild(0).gameObject);
    }
    lastScreen = currentIndex;

    // Create new screen
    GameObject newScreen = Instantiate(_areas[screenIndex].areaObject);
    newScreen.transform.parent = gameObject.transform;

    _currentIndex = screenIndex;
  }
}

