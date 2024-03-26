using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveHandler
{
    private static string SaveLocation = Path.Combine(Application.persistentDataPath, "Save.json");
    const int customizableAmount = 10;//Deðiþmesi lazým
    public static SaveData Instance;

    public static void Init()
    {
        Load();
    }

    [System.Serializable]
    public class SaveData
    {
        public CustomizableData customizableData;
        public MoneyData moneyData;
        public LevelData levelData;

        public SaveData() 
        {
            customizableData = new();
            moneyData = new();
            levelData = new();
        }
    }


    [System.Serializable]
    public class CustomizableData
    {
        [System.Serializable]
        public class DataList
        {
            public List<int> data;

            public DataList()
            {
                data = new();

                for (int i = 0; i < customizableAmount; i++)
                {
                    data.Add(-1);
                }

                data[0] = 1;
            }
        }
        // 0: Body, 1: Trail,2: Death Effect 
        // -1: unpurchased,0 = purchased,not in use, 1 = equipped
       public DataList[] dataContainers;

        public static void EquipCustomizable(CustomizableType T,int index)
        {
            UnequipCustomizable(T);
            List<int> list = Instance.customizableData.dataContainers[(int)T].data;
            list[index] = 1;
        }

        public static void UnequipCustomizable(CustomizableType T,int index)
        {
            List<int> list = Instance.customizableData.dataContainers[(int)T].data;
            list[index] = 0;
        }
        public static void UnequipCustomizable(CustomizableType T)
        {
            UnequipCustomizable(T,GetEquippedCustomizable(T));
        }
        private static int GetEquippedCustomizable(CustomizableType T)
        {
            List<int> list = Instance.customizableData.dataContainers[(int)T].data;
            return list.Find(x => x == 1);
        }
        public static void BuyCustomizable(CustomizableType T, int index)
        {
            //Check balance and do reduction if possible
            List<int> list = Instance.customizableData.dataContainers[(int)T].data;
            list[index] = 0;
            EquipCustomizable(T, index);
        }

        public enum CustomizableType
        {
            CustomizableBody  = 0,
            CustomizableTrail = 1,
            CustomizableDeath = 2,
        }

        public CustomizableData()
        {
            dataContainers = new DataList[3];
        }
    }

    [System.Serializable]
    public class MoneyData
    {
        public int cash;
        public bool perk1;
        
        public static void AddCash(int amount)
        {
            Instance.moneyData.cash += amount;
            Save();
        }

        public static void RemoveCash(int amount)
        {
            Instance.moneyData.cash -= amount;
            Save();
        }

        public static bool CheckCash(int amount)
        {
            return Instance.moneyData.cash <= amount;
        }

        public MoneyData()
        {
            cash = 0;
            perk1 = false;
        }
    }

    [System.Serializable]
    public class LevelData
    {
        public int lastLevel;
        public int currentLevel;

        public static void SetLastLevel(int value)
        {
            Instance.levelData.lastLevel = value;
            Save();
        }
        public static void SetCurrentLevel(int value)
        {
            Instance.levelData.currentLevel = value;
            Save();
        }

        public LevelData()
        {
            lastLevel = 1;
            currentLevel = 1;
        }
    }

    
    public static void Save()
    {
        string jsonRepresentation = JsonUtility.ToJson(Instance,true);
        File.WriteAllText(SaveLocation, jsonRepresentation);
    }

    public static void Load() 
    {
        if (File.Exists(SaveLocation))
        {
            string jsonRepresentation = File.ReadAllText(SaveLocation);
            Instance = JsonUtility.FromJson<SaveData>(jsonRepresentation);
        }
        else
        {
            Instance = new();
            Save();
        }
    }
}
