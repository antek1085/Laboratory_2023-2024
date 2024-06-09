using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemHandler : MonoBehaviour
{
    static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    float money;
    float rentToPay;
    int dayCount;
    
    int saveNumber;
    FileInfo saveSelected;
    [SerializeField] private SOInt saveNumberSO;

    void Awake()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
        SaveSystemEvents.current.onSaveGame += OnSaveGame;
        SaveSystemEvents.current.onButtonClick += OnButtonClick;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonClick(int saveFileNumber)
    {
        saveNumber = saveFileNumber;
        saveNumberSO.value = saveNumber;
        if (File.Exists(SAVE_FOLDER + "/save" + saveNumber + ".txt"))
        {
            Load();
        }
        else
        {
            Save();
        }
    }


    void OnSaveGame(float moneyE, float rentToPayE, int dayPassedE)
    {
        money = moneyE;
        rentToPay = rentToPayE;
        dayCount = dayPassedE;
    }



    public void Save()
    {
        saveNumber = saveNumberSO.value;

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
        saveNumber = saveNumberSO.value;
        
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
