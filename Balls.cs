using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Balls : MonoBehaviour
{
    //Gameobjects
    public GameObject m_ball1;
    public GameObject m_ball2;
    public GameObject m_teather;

    //Balls rotation
    public float m_rotationSpeed = 60f;
    private bool m_bClickOccuring = false;
    private bool m_ball1Rotating = true;

    //Checking if mouse is clicking on UI
    public EventSystem m_eventSystem;
    public GraphicRaycaster m_raycaster;

    //UI
    public GameObject m_gameOverPanel;
    public GameObject m_levelWonPanel;

    // Update is called once per frame
    void Update()
    {
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Contains("wall"))
        {
            m_gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if(col.gameObject.name.Contains("Goal"))
        {
            m_levelWonPanel.SetActive(true);
            Time.timeScale = 0;

            //get current level number
            string sceneName = SceneManager.GetActiveScene().name;
            string levelNum = sceneName.Substring(5, sceneName.Length - 5);
            int iLevelNum = int.Parse(levelNum);

            //compare current level number with number of completed levels, if more then set new completed levels
            int completedLevels = PlayerPrefs.GetInt("CompletedLevels", 0);
            if(iLevelNum > completedLevels)
            {
                PlayerPrefs.SetInt("CompletedLevels", iLevelNum);
            }
        }       
    }
}
