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
    [SerializeField] TextMeshProUGUI componentInChildren;

    
    
    
    [SerializeField] private int SaveFileSlot;

    private void Awake()
    {
         button = GetComponent<Button>();
         
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
        
        
        for (int i = 0; i < saveFiles.Length; i++)
        {
            if (saveFiles[i].Name == "save" + SaveFileSlot + ".txt")
            {
                FileInfo saveSelected = saveFiles[i];
                if (saveSelected != null)
                {
                    saveString = File.ReadAllText(SAVE_FOLDER + "/save" + SaveFileSlot + ".txt");
                    saveObject = JsonUtility.FromJson<SaveObject>(saveString);

                    if (saveObject != null)
                    {
                        button.interactable = true;
                        componentInChildren.text = "day:" + saveObject.dayCount + " Money:" + saveObject.moneyAmount;
                        break;
                    }
                }   
            }
            else
            {
                button.interactable = false;
                componentInChildren.text = "Empty Save Slot";
            }
        }
        if (saveFiles.Length == 0)
        {
            button.interactable = false;
            componentInChildren.text = "Empty Save Slot";
        }
        
    }


    public void DeleteSave()
    {
        File.Delete(SAVE_FOLDER + "/save" + SaveFileSlot + ".txt");
        button.interactable = false;
        componentInChildren.text = "Empty Save Slot";
        transform.parent.gameObject.SetActive(false);
    }
    
    private class SaveObject
    {
        public float moneyAmount;
        public float rentAmount;
        public int dayCount;
    }
    
}
