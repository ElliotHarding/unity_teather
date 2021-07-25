using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    //Dragging
    public GameObject m_selectedGameObject;
    bool m_bIsDragging = false;
    
    public List<GameObject> m_gameObjects = new List<GameObject>();

    //Panning
    public float m_panSpeed = 100;
    bool m_bIsPanning = false;
    Vector3 m_oldPanPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (m_bIsPanning)
            {
                Vector3 difference = m_oldPanPosition - touchPos;
                UnityEngine.Camera.main.transform.position += difference * Time.deltaTime * m_panSpeed;

                m_oldPanPosition = touchPos;
            }
            else if (!m_bIsDragging)
            {
                Collider2D collider = Physics2D.OverlapCircle(touchPos, 1);
                if (collider)
                {
                    m_selectedGameObject = collider.gameObject;
                    m_bIsDragging = true;
                    m_bIsPanning = false;
                    m_selectedGameObject.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
                }
                else
                {
                    m_bIsPanning = true;
                    m_bIsDragging = false;
                    m_oldPanPosition = touchPos;
                }                
            }
            else
            {
                m_selectedGameObject.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
            }
        }     
        else
        {
            m_bIsDragging = false;
            m_bIsPanning = false;
        }
    }

    public void DeleteSelected()
    {
        m_gameObjects.Remove(m_selectedGameObject);
        Destroy(m_selectedGameObject);
    }

    public void RotateRightSelected()
    {
        m_selectedGameObject.transform.Rotate(-Vector3.forward * 10);
    }

    public void RotateLeftSelected()
    {
        m_selectedGameObject.transform.Rotate(Vector3.forward * 10);
    }
}
