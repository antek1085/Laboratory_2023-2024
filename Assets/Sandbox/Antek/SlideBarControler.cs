using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideBarControler : MonoBehaviour
{
    [SerializeField] private SOFloat soFloat;
    public Slider slider;
    
    void Update()
    {
        slider.value = soFloat.Value;
    }
}
