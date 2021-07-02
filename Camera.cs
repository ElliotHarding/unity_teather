using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject m_teather;
    public float m_zPosition = -1;
    public float m_moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(m_teather.transform.position.x, m_teather.transform.position.y, m_zPosition);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = m_teather.transform.position - transform.position;
        transform.position += new Vector3(diff.x * Time.deltaTime * m_moveSpeed, diff.y * Time.deltaTime * m_moveSpeed);
    }
}
