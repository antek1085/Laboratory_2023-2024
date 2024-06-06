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
    
    

    void Awake()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
        SaveSystemEvents.current.onSaveGame += OnSaveGame;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnSaveGame(float moneyE, float rentToPayE, int dayPassedE)
    {
        money = moneyE;
        rentToPay = rentToPayE;
        dayCount = dayPassedE;
    }



    private void Save()
    {
        SaveObject saveObject = new SaveObject()
        {
            moneyAmount = money,
            rentAmount = rentToPay,
            dayCount = dayCount
        };
        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(SAVE_FOLDER + "/save.txt", json);

    }


    private void Load()
    {
        if (File.Exists(SAVE_FOLDER + "/save.txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "/save.txt");
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
