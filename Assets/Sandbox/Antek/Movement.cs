using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] float m_speed;

    [SerializeField] float m_Speed_Sprint;

    [SerializeField] float m_Speed_walk;
    [SerializeField] private float m_Speed_cd_max;
    [SerializeField] private SOFloat moveSpeed;
    private Vector3 mouseposition;

    public float speed_Limit;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && speed_Limit < 5 && m_Speed_cd_max == 0)
        {
            m_speed = m_Speed_Sprint;
            speed_Limit += Time.deltaTime;
            if (speed_Limit > 5)
            {
                m_Speed_cd_max = 1;
            }
        }
        else
        {
            m_speed = m_Speed_walk;
            if (speed_Limit > 0)
            {
                speed_Limit -= Time.deltaTime;
                speed_Limit = Mathf.Max(0, speed_Limit);
                m_Speed_cd_max -= Time.deltaTime;
                m_Speed_cd_max = Mathf.Max(0, m_Speed_cd_max);
            }

        }

        moveSpeed.Value = speed_Limit;
    }

    void FixedUpdate()
    {
        Vector3 p_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _rigidbody.AddForce(p_Input * m_speed,ForceMode.VelocityChange);
    }
    
}