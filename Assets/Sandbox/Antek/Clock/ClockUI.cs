using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public const float realSeconddsPerIngameDay = 180f;
    [SerializeField] Transform clockHandTransform;
    private float day;
    private float dayNormalized;
    private float rotationDegreesPerDay = 360f;
    
    
    private string hoursString;
    private string minuteString;
    [SerializeField] TextMeshProUGUI timeText;
    

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / realSeconddsPerIngameDay;
        dayNormalized = day % 1f;
        clockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

        hoursString = Mathf.Floor(dayNormalized * 24).ToString("00");
        minuteString = Mathf.Floor(((dayNormalized * 24) % 1f) * 60).ToString("00");
        timeText.text = hoursString + ":" + minuteString;
    }
}
