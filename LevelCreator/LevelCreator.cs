using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject m_selectedGameObject;
    bool m_bIsDragging = false;
    public List<GameObject> m_gameObejcts = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(!m_bIsDragging)
            {
                Collider2D collider = Physics2D.OverlapCircle(touchPos, 1);
                if (collider)
                {
                    m_selectedGameObject = collider.gameObject;
                    m_bIsDragging = true;
                    m_selectedGameObject.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
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
        }

        
    }
}
