using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MenuSaveHandler : MonoBehaviour
{
    static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    [SerializeField] List<TextMeshProUGUI> saveSlots;
    SaveObject saveObject;
    
    FileInfo saveSelected;
    string saveString;
    
    float money;
    float rentToPay;
    int dayCount;
    
    int saveNumber;
    [SerializeField] private SOInt SaveFileNumber;
    

    void Awake()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
        
        SaveSystemEvents.current.onButtonClick += OnButtonClick;
        
        
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles();



        for (int i = 0; i < saveFiles.Length -1; i++)
        {
            saveSelected = saveFiles[i];
            if (saveSelected != null)
            {
                saveString = File.ReadAllText(SAVE_FOLDER + "/save" + i + ".txt");
                saveObject = JsonUtility.FromJson<SaveObject>(saveString);

                if (saveObject != null)
                {
                    saveSlots[i].text = "day:" + saveObject.dayCount + " Money:" + saveObject.moneyAmount;
                }
                else
                {
                    saveSlots[i].text = "Empty Save Slot";
                }
            }

        }
    }
    
    void OnButtonClick(int saveFileNumber)
    {
        saveNumber = saveFileNumber;
        SaveFileNumber.value = saveNumber;
        if (File.Exists(SAVE_FOLDER + "/save" + saveNumber + ".txt"))
        {
            Load();
        }
        else
        {
            Save();
        }
    }
    
    
    public void Save()
    {
        saveNumber = SaveFileNumber.value;

        SaveObject saveObject = new SaveObject()
        {
            moneyAmount = money,
            rentAmount = rentToPay,
            dayCount = dayCount
        };
        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(SAVE_FOLDER + "/save" + saveNumber +".txt", json);

    }
    
    
    
    public void Load()
    {
        saveNumber = SaveFileNumber.value;
        
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles();

        saveSelected = saveFiles[saveNumber];
        
        if (File.Exists(SAVE_FOLDER + "/save"+saveNumber+".txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + saveSelected.FullName);
            if (saveString != null)
            {
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
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