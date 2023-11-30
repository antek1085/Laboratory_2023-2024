using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
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

    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    // Update is called once per frame

    void Update()
    {
        PlayerRotation();
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


    // void LookAt()
    // {
    //     RaycastHit hit;
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         Vector3 position = hit.point - transform.position;
    //         position.y = 0.656f;
    //         if (Vector3.Distance(hit.point, transform.position) < 1.5f)
    //         {
    //             return;
    //         }
    //         Quaternion rotation = Quaternion.LookRotation(position.normalized);
    //         transform.rotation = rotation;
    //     }
    // }

    void PlayerRotation()
    {
        horizontal = -Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector2 InputVector = new Vector2(horizontal, vertical);

        if(InputVector == Vector2.zero)
            return;
        transform.rotation = Quaternion.Euler(0,Vector2.SignedAngle(Vector2.up, InputVector),0);
        // Quaternion forwardQuaternion = Quaternion.Euler(0,0,0);
        // Quaternion backQuaternion = Quaternion.Euler(0,180,0);
        // Quaternion leftQuaternion = Quaternion.Euler(0,270,0);
        // Quaternion rightQuaternion = Quaternion.Euler(0,90,0);
        // switch (horizontal)
        // {
        //     case > 0:
        //         transform.rotation = forwardQuaternion;
        //         break;
        //     case < 0 :
        //         transform.rotation = backQuaternion;
        //         break;
        //     default:
        //         break;
        // }
        //     //chdozenei na boki do zrobienia 
        // switch (vertical)
        // {
        //     case > 0 :
        //         transform.rotation = leftQuaternion;
        //         break;
        //     case < 0 :
        //         transform.rotation = rightQuaternion;
        //         break;
        //     default:
        //         break;
        // }
    }
}