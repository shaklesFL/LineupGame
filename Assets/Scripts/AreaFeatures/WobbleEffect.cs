using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleEffect : MonoBehaviour
{
  Vector3 initialLocalPos;
  public float wobbleDistance;
  public float wobbleSpeed;
  Vector2 sineDir;

  // Start is called before the first frame update
  void Start()
  {
    initialLocalPos = transform.localPosition;
    sineDir.x = Random.Range(0, 4);
    sineDir.y = Random.Range(0, 4);
  }

  // Update is called once per frame
  void Update()
  {
    sineDir.x += wobbleSpeed * 0.6767f * Time.deltaTime*60f;
    sineDir.y += wobbleSpeed * Time.deltaTime * 60f;
    Vector3 addPos = new Vector3(Mathf.Sin(sineDir.x) * wobbleDistance, Mathf.Sin(sineDir.y) * wobbleDistance, 0);
    transform.localPosition = initialLocalPos + addPos;
  }
}
