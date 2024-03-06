using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveData
{
    private const string OrbKey = "Orbs";
    private const string LevelKey = "Levels";

    public static int Orb;
    public static int levelIndex;

    public static bool Buy(int required)
    {
        if (Orb >= required)
        {
            Orb -= required;
            PlayerPrefs.SetInt(OrbKey, Orb);
            return true;
        }
        return false;
    }

    public static int GetLevel()
    {
        return PlayerPrefs.GetInt(LevelKey,1);
    }

    public static void SaveLevel(int level) 
    {
        PlayerPrefs.SetInt(LevelKey, level);
    }
}
