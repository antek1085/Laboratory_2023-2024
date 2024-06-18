using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MenuSaveHandler : MonoBehaviour
{
    static readonly string SAVE_FOLDER = Application.dataPath + "Saves";

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
        rentToPay -= Time.deltaTime * 0.5f;
        
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
        
        SaveSystemEvents.current.OnButtonClick += OnButtonClick;
    }

    private void OnEnable()
    {
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
        
        if (File.Exists(SAVE_FOLDER + "/save"+ saveNumber +".txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "/save"+ saveNumber +".txt");
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
