using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour, IPointerDownHandler
{
    public LevelCreator m_levelCreator;
    public GameObject m_spawnObject;

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 worldMousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldMousePos, Vector2.zero);

        if (hit.collider == null)
        {            
            m_levelCreator.m_gameObjects.Add(Instantiate(m_spawnObject, new Vector3(worldMousePos.x, worldMousePos.y, 0), Quaternion.identity));
        }    
    }
}
