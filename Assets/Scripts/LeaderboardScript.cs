using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Assets.Scripts;

public class LeaderboardScript : MonoBehaviour
{
    public static List<RecordData> savedGames = new List<RecordData>();
    public UnityEngine.UI.Text leaderboard;

    private string txt_leaderboard = "Leaderboard\n\n";

    // Start is called before the first frame update
    void Start()
    {
        Load();
        Render();
    }

    void Render()
    {
        txt_leaderboard = "Leaderboard\n\n";
        for (int i = 0; i < savedGames.Count; i++)
        {
            RecordData curData = savedGames[i];
            txt_leaderboard += (i + 1).ToString() + " " + string.Format("{0,2:00}:{1,2:00}", curData.minute, curData.secund + "\n");
        }
        leaderboard.text = txt_leaderboard;
    }

    public static void Save()
    {
        savedGames.Sort();
        Extension.Resize(savedGames, 5);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, LeaderboardScript.savedGames);
        file.Close();
        Debug.Log("save");
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            LeaderboardScript.savedGames = (List<RecordData>)bf.Deserialize(file);
            file.Close();
            Debug.Log("load");
        }
    }
}
