using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SaveSystemHandler : MonoBehaviour
{
    static readonly string SAVE_FOLDER = Application.dataPath + "Saves";

    float money;
    float rentToPay;
    int dayCount;
    public Dictionary<Quaternion, Vector3> playerValue = new Dictionary<Quaternion, Vector3>();
    
    public List<Vector3> itemVector = new List<Vector3>();
    public List<GameObject> items = new List<GameObject>();
    
    int saveNumber;
    FileInfo saveSelected;
    [FormerlySerializedAs("saveNumberSO")]
    [SerializeField] private SOInt SaveFileNumber;

    [SerializeField] private SOFloat SOmoney;
    Scene activeScene;

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
        SaveSystemEvents.current.OnItemSave += OnItemSave;
        Load();
    }

    void OnItemSave(GameObject item, Vector3 itemPostion)
    {
        itemVector.Add(itemPostion);
        items.Add(item);
        SaveWait();
    }


    void OnSaveGame(float moneyE, float rentToPayE, int dayPassedE,Dictionary<Quaternion,Vector3> playerValueSaves)
    {
        money = moneyE;
        rentToPay = rentToPayE;
        dayCount = dayPassedE;
        playerValue = playerValueSaves;
    }
    
    public void Save()
    {
        saveNumber = SaveFileNumber.value;

        SaveObject saveObject = new SaveObject()
        {
            moneyAmount = money,
            rentAmount = rentToPay,
            dayCount = dayCount,
            playerValueSave = playerValue,
            itemVector3 = new List<Vector3>(itemVector),
            itemToSpawn = new List<GameObject>(items)
            
        };
        itemVector.Clear();
        items.Clear();
        playerValue.Clear();
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
                    SaveSystemEvents.current.LoadGame(saveObject.rentAmount, saveObject.dayCount,saveObject.playerValueSave);
                    itemVector = saveObject.itemVector3;
                    StartCoroutine(SaveWait());
                    /* for (int i = 0; i < itemVector.Count; i++)
                     {
                         if(activeScene.name != "Weronika Sandbox 1") return;
                         if (saveObject.itemToSpawn[i] == null) continue;
                         Instantiate(saveObject.itemToSpawn[i], saveObject.itemVector3[i], new Quaternion(90, 0, 0, 0));
                     }
                     itemVector.Clear();*/
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
        public Dictionary<Quaternion, Vector3> playerValueSave = new Dictionary<Quaternion, Vector3>(); 
        public List<Vector3> itemVector3 = new List<Vector3>();
        public List<GameObject> itemToSpawn = new List<GameObject>();
    }

    IEnumerator SaveWait()
    {
        Debug.Log("start");
        string saveString = File.ReadAllText(SAVE_FOLDER + "/save"+ saveNumber +".txt");
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
        yield return new WaitForSeconds(2);
        Debug.Log("Post");
        for (int i = 0; i < itemVector.Count; i++)
        {
            Debug.Log(i + "Test");
            if (saveObject.itemToSpawn[i] == null) continue;
            Instantiate(saveObject.itemToSpawn[i], saveObject.itemVector3[i], new Quaternion(90, 0, 0, 0));
        }
        itemVector.Clear();
    }
}
