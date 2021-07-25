using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool m_canDrag = false;
    public bool m_isDragging = false;

    void OnMouseDrag()
    {
        if(m_canDrag)
        {
            Vector3 curPosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(curPosition.x, curPosition.y, 0);
        }
    }
}
