using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawningSystem : MonoBehaviour
{
    [SerializeField] GameObject material;
    [SerializeField] Transform spawnPoint;
    bool isThereMaterial;
    void Start()
    {
        
    }
    
    void Update()
    {
        if(isThereMaterial == false)
        {
            isThereMaterial = true;
            StartCoroutine(ItemSpawn());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material")
        {
            isThereMaterial = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Material")
        {
            isThereMaterial = false;
        }
    }
    IEnumerator ItemSpawn()
    {
        yield return new WaitForSeconds(2);
        Instantiate(material, spawnPoint.position, spawnPoint.rotation);
        StopCoroutine(ItemSpawn());
    }
}
