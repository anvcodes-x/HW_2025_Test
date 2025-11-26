using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class ConfigLoader : MonoBehaviour
{
    public static GameConfig Config;
    public bool IsLoaded { get; private set; } = false;

    public IEnumerator LoadConfig()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "doofus_diary.json");
        string json = "";

        if (path.Contains("://") || path.Contains(":///"))
        {
            using (UnityWebRequest www = UnityWebRequest.Get(path))
            {
                yield return www.SendWebRequest();
                if (www.result == UnityWebRequest.Result.Success)
                    json = www.downloadHandler.text;
                else
                    Debug.LogError("Error: " + www.error);
            }
        }
        else
        {
            if (File.Exists(path))
                json = File.ReadAllText(path);
        }

        if (!string.IsNullOrEmpty(json))
        {
            Config = JsonUtility.FromJson<GameConfig>(json);
            IsLoaded = true;
            Debug.Log("Level 1: Config Loaded! Speed is " + Config.player_data.speed);
        }
        yield return null;
    }
}
