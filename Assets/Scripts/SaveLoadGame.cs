using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadGame : MonoBehaviour
{
    public Save save;

    public void SaveGame(string name, bool[] achivment)
    {
        if (save.levelsName.Count == 0 || save.levelsName.Find(x => x == name) == null)
        {
            save.levelsName.Add(name);
            save.levelsAchivments.Add(achivment);
        }
        else if (save.levelsName.Find(x => x == name) != null)
        {
            int indexLevel = save.levelsName.FindIndex(x => x == name);
            bool[] levelAchivments = save.levelsAchivments[indexLevel];
            if(achivment[0] == true)
            {
                levelAchivments[0] = true;
            }
            if(achivment[1] == true)
            {
                levelAchivments[1] = true;
            }
            if(achivment[2] == true)
            {
                levelAchivments[2] = true;
            }
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.dat");
        bf.Serialize(file, save);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.dat", FileMode.Open);
            save = (Save)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            save = new Save();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/gamesave.dat");
            bf.Serialize(file, save);
            file.Close();
        }
    }
}
