using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class plants_button : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    public void Toggle()
    {
        Debug.Log("klik");
        if (objectToDisable != null)
            objectToDisable.SetActive(false);

        if (objectToEnable != null)
            objectToEnable.SetActive(true);
    }
}
