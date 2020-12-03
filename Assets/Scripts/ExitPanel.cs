using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPanel : MonoBehaviour
{
    public static bool pause = false;
    public GameObject exitpanel;

    // Start is called before the first frame update
    void Start()
    {
        exitpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            //ig game is paused
            if (pause == true)
            {
                pause = false;
                exitpanel.SetActive(false);
                Debug.Log("unpaused");

            }
            else {
                pause = true;
                exitpanel.SetActive(true);
                Debug.Log("paused");
            }
            
        }

    }

    //restart Game
    public void Restart()
    {
        Debug.Log("Load");
        SceneManager.LoadScene(0);
    }


    //Quit Game
    public void QuitMenu()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
