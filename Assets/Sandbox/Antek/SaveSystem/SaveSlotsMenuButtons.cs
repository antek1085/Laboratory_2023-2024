using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotsMenuButtons : MonoBehaviour
{
    [SerializeField] private int saveFileSlot;

    public void OnButtonClick()
    {
        SaveSystemEvents.current.ButtonClick(saveFileSlot);
    }
}
