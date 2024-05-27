using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPoint : MonoBehaviour
{
    public GameObject[] fields;
    private int fieldCount = 0;
    private List<GameObject> leaves = null;
    private Collision2D hit = null;
    private int selected = -1;

    void OnCollisionEnter2D(Collision2D collision) => OnEnter(collision);
    void OnCollisionExit2D(Collision2D collision) => OnExit(collision);

    [SerializeField] int miniGameId;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        leaves = new List<GameObject>();

        fieldCount = 0;
        leaves.AddRange(fields);
        selected = Random.Range(0, fields.Length - 1);

        for (int i = 0; i < fields.Length; i++)
        {
            if (i != selected) fields[i].SetActive(false);
        }

        fields[selected].SetActive(true);
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
            leaves.RemoveAt(selected);
            hit.gameObject.SetActive(false);
            //Destroy(hit.gameObject);
            hit = null;
            fieldCount += 1;
            Audio.Play("SucessEvent");

            if (fieldCount >= 4)
            {
                EventCraftMortar.current.MiniGameEnd(miniGameId);
                Reset();
            }
            else
            {
                selected = Random.Range(0, leaves.Count - 1);
                leaves[selected].SetActive(true);
            }
        }
    }
}
