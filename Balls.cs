using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Balls : MonoBehaviour
{
    //Gameobjects
    public GameObject m_ball1;
    public GameObject m_ball2;
    public GameObject m_teather;

    //Balls rotation
    public float m_rotationSpeed = 60f;
    private bool m_bTouchOccuring = false;
    private bool m_bClickOccuring = false;
    private bool m_ball1Rotating = true;

    //Checking if mouse is clicking on UI
    public EventSystem m_eventSystem;
    public GraphicRaycaster m_raycaster;

    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        //Handle screen touches
        if (Input.touchCount > 0 && !m_bTouchOccuring)
        {
            m_bTouchOccuring = true;
            foreach (Touch touch in Input.touches)
            {
                //Make sure isnt clicking on UI
                if (!mouseOnUI(new Vector3(touch.position.x, touch.position.y)))
                {
                    m_ball1Rotating = !m_ball1Rotating;
                    break;
                }
            }
        }
        else if(Input.touchCount == 0)
        {
            m_bTouchOccuring = false;
        }

        //Handle mouse clicks
        if (Input.GetMouseButton(0) && !m_bClickOccuring)
        {
            m_bClickOccuring = true;
            //Make sure mouse isnt clicking on UI
            if (!mouseOnUI(Input.mousePosition))
            {
                m_ball1Rotating = !m_ball1Rotating;
            }
        }
        else if(!Input.GetMouseButton(0))
        {
            m_bClickOccuring = false;
        }

        //Handle rotation of balls
        if (m_ball1Rotating)
        {
            m_ball1.transform.RotateAround(m_ball2.transform.position, new Vector3(0,0,1), m_rotationSpeed * Time.deltaTime);
        }
        else 
        {
            m_ball2.transform.RotateAround(m_ball1.transform.position, new Vector3(0, 0, 1), m_rotationSpeed * Time.deltaTime);
        }

        PositionTeather();
    }

    void PositionTeather()
    {
        //Set midpoint
        m_teather.transform.position = new Vector3((m_ball1.transform.position.x + m_ball2.transform.position.x) / 2, (m_ball1.transform.position.y + m_ball2.transform.position.y) / 2);

        //Find angle
        Vector2 difference = m_ball1.transform.position - m_ball2.transform.position;
        float sign = m_ball1.transform.position.y < m_ball2.transform.position.y ? -1f : 1f;
        float rotation = Vector2.Angle(Vector2.right, difference) * sign;

        m_teather.transform.localEulerAngles = new Vector3(0, 0, rotation);
    }

    bool mouseOnUI(Vector3 mousePosition)
    {
        //Check were not clicking in ui area
        List<RaycastResult> results = new List<RaycastResult>();
        PointerEventData pointerEventData = new PointerEventData(m_eventSystem);
        pointerEventData.position = mousePosition;
        m_raycaster.Raycast(pointerEventData, results);

        return results.Count != 0;
    }
}
