using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelCreator : MonoBehaviour
{
    public static string m_levelName;

    public List<GameObject> m_gameObjects = new List<GameObject>();

    //Dragging
    public GameObject m_selectedGameObject;
    public bool m_bIsDragging = false;
   
    //Panning
    public float m_panSpeed = 100;
    bool m_bIsPanning = false;
    Vector3 m_oldPanPosition;

    void Start()
    {
        Debug.Log(m_levelName);
    }

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
                    m_selectedGameObject.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
                }
                else
                {
                    m_bIsPanning = true;
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
        if(m_selectedGameObject)
        {
            m_selectedGameObject.transform.Rotate(-Vector3.forward * 10);
        }
    }

    public void RotateLeftSelected()
    {
        if (m_selectedGameObject)
        {
            m_selectedGameObject.transform.Rotate(Vector3.forward * 10);
        }
    }

    public void SaveGameObjects()
    {
        string path = Application.persistentDataPath + "/createdLevel.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        foreach(GameObject go in m_gameObjects)
        {           
            writer.WriteLine(go.name + ":" + go.transform.position.x + ":" + go.transform.position.y + ":" + go.transform.localRotation.eulerAngles.z);
        }       

        writer.Close();

        /*
        string path2 = Application.persistentDataPath + "/test.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path2);
        Debug.Log("output of file:");
        Debug.Log(reader.ReadToEnd());
        reader.Close();*/
    }
}
