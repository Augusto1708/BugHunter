using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem 
{
    private static string fileName = "progresPlayer.json";

   public static void SaveLevels(LevelsData data)
    {
        string json=JsonUtility.ToJson(data);
        string path =Path.Combine(Application.persistentDataPath,fileName);
        File.WriteAllText(path, json);

        Debug.Log("Juego Guardado en: " + path);

    }
    public static void LoadLevels(LevelsData data)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);

       
        if (File.Exists(path))
        {           
            string json = File.ReadAllText(path);         
            JsonUtility.FromJsonOverwrite(json, data);
            #if UNITY_EDITOR
            Debug.Log("juego cargado correctamente");
            #endif

        }
        else
        {
            #if UNITY_EDITOR
            Debug.LogWarning("No se encontró archivo de guardado Se usaran los datos por defecto.");
            #endif

        }
    }
}
