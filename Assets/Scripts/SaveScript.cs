using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[RequireComponent(typeof(MazeManager))]
public class SaveScript : MonoBehaviour
{
    private string savePath;
    public PlayerController player;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        savePath = Application.persistentDataPath + "/gamesave.save";
    }

    public void SaveData()
    {
        var save = new Save()
        {
            score = player.GetPoints(),
            zombiesKilled = player.GetZombiesKilled(),
            time = timer.GetTime(),
            health = player.GetHealth()
        };

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        Debug.Log("Data Saved");
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }
            player.points = save.score;
            player.zombiesKilled = save.zombiesKilled;
            timer.time = save.time;
            player.health = save.health;
        }
        else
        {
            Debug.LogWarning("Save file does not exist");
        }
    }
}
