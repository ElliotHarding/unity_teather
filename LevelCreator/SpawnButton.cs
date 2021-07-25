using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject m_spawnObject;

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 worldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newSpawnObject = Instantiate(m_spawnObject, new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);
        newSpawnObject.GetComponent<Draggable>().m_canDrag = true;
    }
}
