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
        Vector3 worldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_levelCreator.m_gameObjects.Add(Instantiate(m_spawnObject, new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity));
    }
}
