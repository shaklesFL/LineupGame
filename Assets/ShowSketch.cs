using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShowSketch : MonoBehaviour
{
    public GameObject image;
    private Sprite screenshot;

    // Start is called before the first frame update
    void Start()
    {
        if (Engine.settings.playerType == 1)
        {
            image.SetActive(false);
            gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnter() {

        image.GetComponent<Image>().color = new Color32(255, 255, 255, 220);
        string folderPath = Directory.GetCurrentDirectory() + "/Screenshots/Screenshot.png";
        screenshot = IMG2Sprite.LoadNewSprite(folderPath, 100.0f);
        image.GetComponent<Image>().sprite = screenshot;
        
    }

    public void OnExit()
    {
        image.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }
}
