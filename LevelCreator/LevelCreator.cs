using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject m_selectedGameObject;
    public List<GameObject> m_gameObejcts = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapCircle(touchPos, 1);

            if(collider)
            {
                collider.gameObject.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
            }
        }        
    }
}
