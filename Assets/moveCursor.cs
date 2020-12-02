using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (Input.GetMouseButton(0))
        {
            Debug.Log("my message " + worldPosition);
            transform.position = new Vector3(worldPosition.x*499, worldPosition.y*280, worldPosition.z); ;

        }


    }
}
