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

    public GameObject brush_indicator;
    private float brush_width = 0.07f;

    // brush colours
    public Color32 black_ind = new Color32(0,0,0,255);
    public Color32 green_ind = new Color32(0, 255, 0, 255);
    public Color32 blue_ind = new Color32(0, 0, 255, 255);
    public Color32 red_ind = new Color32(255, 0, 0, 255);
    public Color32 cyan_ind = new Color32(0, 255, 255, 255);
    public Color32 yellow_ind = new Color32(255, 255, 0, 255);
    public Color32 pink_ind = new Color32(255, 0, 255, 255);
    public Color32 grey_ind = new Color32(230, 230, 230, 255);

    private void Start()
    {
        brush_indicator.transform.localScale = new Vector2(0.05f, 0.05f);
    }


    private void Update() {

        Vector3 mousePos = Input.mousePosition;
        brush_indicator.transform.position = mousePos;

        Drawing();
    }

    public void brushUpdate(float value) {
        brush_indicator.transform.localScale = new Vector2((0.05f + (value * 0.40f)), (0.05f + (value * 0.40f)));
        brush_width = 0.07f + (value * 0.7f);
        Debug.Log("value" + value);

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
            if (mousePos != lastPos)
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
        brushInstance.transform.parent = GameObject.FindGameObjectWithTag("LineHolder").transform;
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        ChooseColour(selected_colour);
        setBrushSize();
        //currentLineRenderer.sortingOrder++;
        sorting_order++;
        Debug.Log("The sorting order is " + currentLineRenderer.sortingOrder);
        //Destroy(currentLineRenderer.gameObject, 5);

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    public void setBrushSize() {
        currentLineRenderer.startWidth = brush_width;
    }

    public void AddAPoint(Vector2 pointPos) {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, new Vector3(pointPos.x, pointPos.y, -1));
    }

    public void ChangeBlack()
    {
        selected_colour = 0;
        brush_indicator.GetComponent<Image>().color = black_ind;
    }
    public void ChangeGreen()
    {
        selected_colour = 1;
        brush_indicator.GetComponent<Image>().color = green_ind;
    }
    public void ChangeBlue()
    {
        selected_colour = 2;
        brush_indicator.GetComponent<Image>().color = blue_ind;
    }
    public void ChangeRed()
    {
        selected_colour = 3;
        brush_indicator.GetComponent<Image>().color = red_ind;
    }
    public void ChangeCyan()
    {
        selected_colour = 4;
        brush_indicator.GetComponent<Image>().color = cyan_ind;
    }
    public void ChangeYellow()
    {
        selected_colour = 5;
        brush_indicator.GetComponent<Image>().color = yellow_ind;
    }
    public void ChangePink()
    {
        selected_colour = 6;
        brush_indicator.GetComponent<Image>().color = pink_ind;
    }
    public void ChangeWhite()
    {
        selected_colour = 7;
        brush_indicator.GetComponent<Image>().color = grey_ind;
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
                //LineRenderer.Reset()

                break;
        }
    }

}