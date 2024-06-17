using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;


public class SaveSlotsMenuButtons : MonoBehaviour
{
    static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    
    [SerializeField] private int saveFileSlot;
    int saveNumber;
    //[SerializeField] private SOInt SaveFileNumber;
    private FileInfo[] saveFiles;
    SaveObject saveObject;
    string saveString;
    private Button _button;
    private FileInfo saveSelected;

    [SerializeField] TextMeshProUGUI saveSlots;
    DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);


    void Awake()
    {
      _button = GetComponent<Button>();
    }
    

    public void OnButtonClick()
    {
        SaveSystemEvents.current.ButtonClick(saveFileSlot);
        
    }

    private void OnEnable()
    {
        saveFiles = directoryInfo.GetFiles();
        saveSelected = null;
        
        
        if (saveFiles.Length -1 >= saveFileSlot || saveFiles.Length  == saveFileSlot)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
        
        
        Refresh();
        if (saveFiles.Length == 0)
        {
            saveSlots.text = "Empty Save Slot";
        }
    }

    private void Refresh()
    {
        for (int i = 0; i < saveFiles.Length; i++)
        {
            if (saveFiles[i].Name.Contains(saveFileSlot.ToString()))
            {
                 saveSelected = saveFiles[i];
                if (saveSelected != null)
                {
                    saveString = File.ReadAllText(SAVE_FOLDER + "/save" + saveFileSlot + ".txt");
                    saveObject = JsonUtility.FromJson<SaveObject>(saveString);

                    if (saveObject != null)
                    {
                        saveSlots.text = "day:" + saveObject.dayCount + " Money:" + saveObject.moneyAmount;
                        break;
                    }
                }   
            }
            else
            {
                saveSlots.text = "Empty Save Slot";
            }
        }
    }

    private class SaveObject
    {
        public float moneyAmount;
        public float rentAmount;
        public int dayCount;
    }
}
