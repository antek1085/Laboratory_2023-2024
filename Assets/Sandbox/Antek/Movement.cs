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
        LookAt();
        if (Input.GetKey(KeyCode.LeftShift) && speed_Limit < 5 && m_Speed_cd_max == 0)
        {
            m_speed = m_Speed_Sprint;
            speed_Limit += Time.deltaTime;
            if (speed_Limit > 5)
            {
                m_Speed_cd_max = 5;
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

        _rigidbody.MovePosition(transform.position + p_Input * Time.deltaTime * m_speed);
    }


    void LookAt()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 position = hit.point - transform.position;
            position.y = 0.656f;
            if (Vector3.Distance(hit.point, transform.position) < 1.5f)
            {
                return;
            }
            Quaternion rotation = Quaternion.LookRotation(position.normalized);
            transform.rotation = rotation;
        }
    }
}