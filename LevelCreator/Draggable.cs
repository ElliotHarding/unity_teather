using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool m_canDrag = false;
    public bool m_isDragging = false;

    void OnMouseDown()
    {
        if(m_canDrag)
        {
            m_isDragging = true;
        }
    }

    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            m_isDragging = false;
        }

        if (m_isDragging)
        {
            Vector3 curPosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(curPosition.x, curPosition.y, 0);
        }
    }
}
