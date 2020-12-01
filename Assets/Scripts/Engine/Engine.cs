using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyFeatures // your custom enumeration
{
  Base,
  Spots,
  Eyes,
  Nose,
  Mouth,
  Hair,
  HairLength
};

public class Engine : MonoBehaviour
{

  public static Settings settings;
  public static AreaIndex areaManager;
  public static WitnessHandler witnessManager;
  public static Case caseManager;
  public static Camera mainCamera;

  [SerializeField]
  private Settings settingsEntity;
  [SerializeField]
  private GameObject screenManagerEntity;
  [SerializeField]
  private GameObject witnessHandlerEntity;
  [SerializeField]
  private Case caseManagerEntity;

  private void Start()
  {
    settings = settingsEntity;
    caseManager = caseManagerEntity;

    areaManager = Instantiate(screenManagerEntity).GetComponent<AreaIndex>();
    witnessManager = Instantiate(witnessHandlerEntity).GetComponent<WitnessHandler>();

    mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
  }

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.L))
    {
      areaManager.GoToScreen("Suspects");
    }
  }

}
