using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public GameObject m_ball1;
    public GameObject m_ball2;
    public GameObject m_teather;

    public float m_rotationSpeed = 60f;
    public float m_clickFrequency = 0.5f;
    private float m_timeSinceLastClick = 1f;

    private bool m_ball1Rotating = true;

    // Update is called once per frame
    void Update()
    {
        //Handle click/touch input
        m_timeSinceLastClick += Time.deltaTime;
        if (m_timeSinceLastClick > m_clickFrequency)
        {
            //Handle screen touches
            if (Input.touchCount > 0)
            {
                m_ball1Rotating = !m_ball1Rotating;
                m_timeSinceLastClick = 0;
            }

            //Handle mouse clicks
            if (Input.GetMouseButton(0))
            {
                m_ball1Rotating = !m_ball1Rotating;
                m_timeSinceLastClick = 0;
            }
        }      

        //Handle rotation of balls
        if (m_ball1Rotating)
        {
            m_ball1.transform.RotateAround(m_ball2.transform.position, new Vector3(0,0,1), m_rotationSpeed * Time.deltaTime);
        }
        else 
        {
            m_ball2.transform.RotateAround(m_ball1.transform.position, new Vector3(0, 0, 1), m_rotationSpeed * Time.deltaTime);
        }

        PositionTeather();
    }

    void PositionTeather()
    {
        //Set midpoint
        m_teather.transform.position = new Vector3((m_ball1.transform.position.x + m_ball2.transform.position.x) / 2, (m_ball1.transform.position.y + m_ball2.transform.position.y) / 2);

        //Find angle
        Vector2 difference = m_ball1.transform.position - m_ball2.transform.position;
        float sign = m_ball1.transform.position.y < m_ball2.transform.position.y ? -1f : 1f;
        float rotation = Vector2.Angle(Vector2.right, difference) * sign;

        m_teather.transform.localEulerAngles = new Vector3(0, 0, rotation);
    }
}
