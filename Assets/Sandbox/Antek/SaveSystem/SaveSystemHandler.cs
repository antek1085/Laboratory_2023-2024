using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SaveSystemHandler : MonoBehaviour
{
    static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    float money;
    float rentToPay;
    int dayCount;
    
    int saveNumber;
    FileInfo saveSelected;
    [FormerlySerializedAs("saveNumberSO")]
    [SerializeField] private SOInt SaveFileNumber;

    [SerializeField] private SOFloat SOmoney;

    void OnEnable()
    {
    }

    void Awake()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    void Start()
    {
        SaveSystemEvents.current.OnSaveGame += OnSaveGame;
        Load();
    }



    void OnSaveGame(float moneyE, float rentToPayE, int dayPassedE)
    {
        money = moneyE;
        rentToPay = rentToPayE;
        dayCount = dayPassedE;
        Save();
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
            string saveString = File.ReadAllText(SAVE_FOLDER + "/save"+ saveNumber +".txt");
            if (saveString != null)
            {
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                SOmoney.Value = saveObject.moneyAmount;
                if (saveObject.dayCount != 0)
                { 
                    SaveSystemEvents.current.LoadGame(saveObject.rentAmount, saveObject.dayCount);  
                }
            }
        }
    }

    void OnDestroy()
    {
        SaveSystemEvents.current.OnSaveGame -= OnSaveGame;
    }


    private class SaveObject
    {
        public float moneyAmount;
        public float rentAmount;
        public int dayCount;
    }
}
