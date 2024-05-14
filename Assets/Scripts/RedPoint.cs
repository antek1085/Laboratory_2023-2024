using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPoint : MonoBehaviour
{
    public GameObject[] fields;
    private int fieldCount = 0;

    private Collision2D hit = null;

    void OnCollisionEnter2D(Collision2D collision) => OnEnter(collision);
    void OnCollisionExit2D(Collision2D collision) => OnExit(collision);

    [SerializeField] int miniGameId;

    private void Start()
    {
        
        fieldCount = fields.Length;

        for(int i = 0; i < (fieldCount-1); i++)
        {
            fields[i].SetActive(false);
        }
    }

    void OnEnter(Collision2D collision)
    {
        hit = collision;
    }
    void OnExit(Collision2D collision)
    {
        hit = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfOverField();
        }
    }
    void CheckIfOverField()
    {
        if (hit != null)
        {
            Destroy(hit.gameObject);
            hit = null;
            fieldCount -= 1;
            Audio.Play("SucessEvent");

            if (fieldCount <= 0)
            {
                EventCraftMortar.current.MiniGameEnd(miniGameId);
            }
            else
            {
                fields[fieldCount - 1].SetActive(true);
            }
        }
    }
}
