using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
  public WitnessEntity entity;

  public bool isMoving = false;
  Vector3 targetMovePos;
  Vector3 targetMoveScale;
  Vector3 velocity = Vector3.zero;
  Vector3 velocity2 = Vector3.zero;
  public float smoothTime = 0.5f;

  // Start is called before the first frame update
  void Start()
  {
    entity = new WitnessEntity();
    entity.InitElements();
  }

  // Update is called once per frame
  void Update()
  {
    if (isMoving)
    {
      // Smoothly move the object
      transform.position = Vector3.SmoothDamp(transform.position, targetMovePos, ref velocity, smoothTime);

      // Smoothly scale the object
      transform.localScale = Vector3.SmoothDamp(transform.localScale, targetMoveScale, ref velocity2, smoothTime);
    }

  }

  public void moveCharacterTo(Vector3 pos, Vector3 scale)
  {
    isMoving = true;
    targetMovePos = pos;
    targetMoveScale = scale;
  }
}
