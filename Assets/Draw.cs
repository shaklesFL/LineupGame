using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    private int selected_colour;
    private int sorting_order = 0;

    public Camera m_camera;
    public GameObject brush;

    // brush colours
    public Material black;
    public Material green;
    public Material blue;
    public Material red;
    public Material cyan;
    public Material yellow;
    public Material pink;
    public Material white;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;


    private void Update() {
        Drawing();
    }

    public void Drawing() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            CreateBrush();
            //m_camera.gameObject.transform.position.z +=1;

            //m_camera.gameObject.transform.position.z -= 1;

            m_camera.gameObject.transform.position = m_camera.gameObject.transform.position + new Vector3(0, 0, -0.5f);
        
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos != lastPos)
            {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else 
        {
            currentLineRenderer = null;
        }
    }

    public void CreateBrush() {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        ChooseColour(selected_colour);
        //currentLineRenderer.sortingOrder++;
        sorting_order++;
        Debug.Log("The sorting order is " + currentLineRenderer.sortingOrder);
        //Destroy(currentLineRenderer.gameObject, 5);

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    public void AddAPoint(Vector2 pointPos) {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    public void ChangeBlack()
    {
        selected_colour = 0;
    }
    public void ChangeGreen()
    {
        selected_colour = 1;
    }
    public void ChangeBlue()
    {
        selected_colour = 2;
    }
    public void ChangeRed()
    {
        selected_colour = 3;
    }
    public void ChangeCyan()
    {
        selected_colour = 4;
    }
    public void ChangeYellow()
    {
        selected_colour = 5;
    }
    public void ChangePink()
    {
        selected_colour = 6;
    }
    public void ChangeWhite()
    {
        selected_colour = 7;
    }

    public void ChooseColour(int colour)
    {
        switch (colour)
        {
            case 0:
                currentLineRenderer.material = black;
                currentLineRenderer.sortingOrder = sorting_order;
                break;
            case 1:
                currentLineRenderer.material = green;
                currentLineRenderer.sortingOrder = sorting_order;
                break;
            case 2:
                currentLineRenderer.material = blue;
                currentLineRenderer.sortingOrder = sorting_order;
                break;
            case 3:
                currentLineRenderer.material = red;
                currentLineRenderer.sortingOrder = sorting_order;
                break;
            case 4:
                currentLineRenderer.material = cyan;
                currentLineRenderer.sortingOrder = sorting_order;
                break;
            case 5:
                currentLineRenderer.material = yellow;
                currentLineRenderer.sortingOrder = sorting_order;
                break;
            case 6:
                currentLineRenderer.material = pink;
                currentLineRenderer.sortingOrder = sorting_order;
                break;
            case 7:
                currentLineRenderer.material = white;
                currentLineRenderer.sortingOrder = sorting_order;
                currentLineRenderer.startWidth = 1;
                //LineRenderer.Reset()

                break;
        }
    }

}
