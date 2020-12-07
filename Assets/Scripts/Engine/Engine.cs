using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyFeatures // your custom enumeration
{
  Base,
  Clothing,
  Eyes,
  Nose,
  Mouth,
  Hair,
  Earrings,
  Glasses
};

public class Engine : MonoBehaviour
{
  public static AudioManager audioManager;
  public static Settings settings;
  public static AreaIndex areaManager;
  public static WitnessHandler witnessManager;
  public static Case caseManager;
  public static Camera mainCamera;

  [SerializeField]
  private AudioManager audioEntity;
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
    audioManager = audioEntity;
    settings = settingsEntity;
    caseManager = caseManagerEntity;

    FindObjectOfType<AudioManager>().Play("theme");

    areaManager = Instantiate(screenManagerEntity).GetComponent<AreaIndex>();
    witnessManager = Instantiate(witnessHandlerEntity).GetComponent<WitnessHandler>();

    mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
  }

  /*private void Update()
  {
    if(Input.GetKeyDown(KeyCode.L))
    {
      areaManager.GoToScreen("Suspects");
    }
  }*/

}
