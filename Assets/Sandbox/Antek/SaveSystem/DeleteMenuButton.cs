using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeleteMenuButton : MonoBehaviour
{
    static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    FileInfo saveSelected;
    private Button button;
    
    string saveString;
    SaveObject saveObject;
    private TextMeshPro componentInChildren;

    
    
    
    [SerializeField] private int SaveFileSlot;

    private void Awake()
    {
         button = GetComponent<Button>();
         componentInChildren = GetComponentInChildren<TextMeshPro>();
    }

    private void OnEnable()
    {
        
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles();

        // if (saveFiles.Length < SaveFileSlot+ 1)
        // {
        //     button.interactable = false;
        // }
        // else
        // {
        //     button.interactable = true;
        // }
        
        
        for (int i = 0; i < 2; i++)
        {
            saveSelected = saveFiles[i];
            if (saveSelected != null && saveSelected.Name == "save" + i + ".txt")
            {
                saveString = File.ReadAllText(SAVE_FOLDER + "/save" + i + ".txt");
                saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                if (saveObject != null)
                {
                    button.interactable = true;
                    componentInChildren.text = "day:" + saveObject.dayCount + " Money:" + saveObject.moneyAmount;
                }
                else
                {
                    button.interactable = false;
                    componentInChildren.text = "Empty Save Slot";
                }
            }

        }
        
        
    }


    public void DeleteSave()
    {
        File.Delete(SAVE_FOLDER + "/save" + SaveFileSlot + ".txt");
        transform.parent.gameObject.SetActive(false);
    }
    
    private class SaveObject
    {
        public float moneyAmount;
        public float rentAmount;
        public int dayCount;
    }
    
}
