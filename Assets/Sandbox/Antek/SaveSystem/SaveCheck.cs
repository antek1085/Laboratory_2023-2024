using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCheck : MonoBehaviour
{
    static readonly string SAVE_FOLDER = Application.dataPath + "Saves";
    // Start is called before the first frame update
    private void Awake()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }
}
