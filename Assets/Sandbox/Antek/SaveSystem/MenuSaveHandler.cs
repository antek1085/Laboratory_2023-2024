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

    void Awake()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles();
        
        

        for (int i = 0; i < saveFiles.Length; i++)
        {
            saveSelected = saveFiles[i];
            if (saveSelected != null)
            {
                saveString = File.ReadAllText(SAVE_FOLDER + saveSelected.FullName);
                saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                
                if(saveObject != null)
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
    void Start()
    {
       
    }


    private class SaveObject
    {
        public float moneyAmount;
        public float rentAmount;
        public int dayCount;
    }

}
