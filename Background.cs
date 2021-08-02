using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Transform[] m_background = null;
    static public float m_scrollSpeed = -1f;

    public float m_leftPosX = 0f;
    public float m_rightPosX = 0f;


    void Start()
    {
        float length = m_background[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        m_leftPosX = -length;
        m_rightPosX = length * m_background.Length;
    }

    void Update()
    {
        for(int i=0; i<m_background.Length; i++)
        {
            m_background[i].position += new Vector3(m_scrollSpeed, 0, 0) * Time.deltaTime;

            if(m_background[i].position.x < m_leftPosX)
            {
                Vector3 selfPos = m_background[i].position;
                selfPos.Set(selfPos.x + m_rightPosX, selfPos.y, selfPos.z);
                m_background[i].position = selfPos;
            }
        }
    }
}
