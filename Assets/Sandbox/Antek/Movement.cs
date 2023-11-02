using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] float m_speed;

    [SerializeField] float m_Speed_Sprint;

    [SerializeField] float m_Speed_walk;
    [SerializeField] float m_Speed_cd;

    public float speed_Limit;
    // Start is called before the first frame update
    void Start()
    {
       _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && speed_Limit < 5 && m_Speed_cd == 0)
        {
            m_speed = m_Speed_Sprint;
            speed_Limit = +Time.time;
            if (speed_Limit > 5)
            {
                m_Speed_cd = 5;
            }
        }
        else
        {
            m_speed = m_Speed_walk;
            if (speed_Limit > 0)
            {
                speed_Limit = speed_Limit - Time.time;
            }
            
        }

        if (m_Speed_cd > 0)     
        {
            m_Speed_cd = m_Speed_cd - Time.time;
        }
    }
    void FixedUpdate()
    {
        Vector3 p_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
           
        _rigidbody.MovePosition(transform.position + p_Input *Time.deltaTime * m_speed);
    }
}
