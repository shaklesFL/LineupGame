using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspectEntity : MonoBehaviour
{
  Vector3 initialPosition;
  public float heightDif;
  // Start is called before the first frame update
  void Start()
  {
    initialPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = Vector3.Lerp(transform.position, initialPosition + new Vector3(0, heightDif, 0), 0.05f * Time.deltaTime * 60f);
  }
}
