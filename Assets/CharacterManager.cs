﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
  public WitnessEntity entity;
  public CharacterFeatures visualFeatures;

  public CharacterReferences _bodyParts;
  public bool isKiller = false;
  public int killerPosition = -1;

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
    visualFeatures = new CharacterFeatures();
    entity.InitElements();
    if (isKiller)
    {
      visualFeatures.SetAsKiller();
      //Engine.caseManager.killerId = killerPosition;
    }
    visualFeatures.InitFeatures(_bodyParts);
    //_bodyParts.InitReferences();
    AttachBodyParts();
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

  public void AttachBodyParts()
  {
    // Finds the associated images and attaches them to their corresponding bone
    for (int i = 0; i < _bodyParts._bodyParts.Length; i++)
    {
      // get references from element and body
      GameObject point = _bodyParts._bodyParts[i]._bodyPoint;
      BodyPartElements bodyElement = visualFeatures.parts[i];
      ElementBlock block = Engine.witnessManager.elementList.elements[bodyElement.elementIndex];

      print(block.refName);
      SpriteRenderer render = point.GetComponent<SpriteRenderer>();
      render.sprite = block.types[bodyElement.typeIndex].image;
      render.color = bodyElement.color;
      Vector3 scale = render.gameObject.transform.localScale;
      render.gameObject.transform.localScale = new Vector3(scale.x, scale.y * bodyElement.height, scale.z);

    }
  }
}
