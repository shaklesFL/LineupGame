using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{

  public static Settings settings;
  public static AreaIndex areaManager;
  public static WitnessHandler witnessManager;

  [SerializeField]
  private Settings settingsEntity;
  [SerializeField]
  private GameObject screenManagerEntity;
  [SerializeField]
  private GameObject WitnessHandlerEntity;

  private void Start()
  {
    settings = settingsEntity;

    areaManager = Instantiate(screenManagerEntity).GetComponent<AreaIndex>();
    witnessManager = Instantiate(WitnessHandlerEntity).GetComponent<WitnessHandler>();
  }

}
