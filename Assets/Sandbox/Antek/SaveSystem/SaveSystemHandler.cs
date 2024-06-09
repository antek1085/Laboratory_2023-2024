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

    void Awake()
    {
        SaveSystemEvents.current.onSaveGame += OnSaveGame;
        
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
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
