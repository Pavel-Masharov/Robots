using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int level = 1;
    public int score = 0;
}
public class Progress : MonoBehaviour
{
    public static Progress instance;
    public PlayerInfo playerInfo;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            gameObject.name = "Progress";
            gameObject.transform.SetParent(null);


#if UNITY_EDITOR
            playerInfo = new PlayerInfo();
            playerInfo.level = 1;
            playerInfo.score = 0;

#else

            YandexManagerSDK.GetLevel();
            if (playerInfo.level == 0)
            {
                playerInfo.level = 1;
                SaveData();
            }



            int deiceID = YandexManagerSDK.CheckDeviceInfo();
            if(deiceID != 1)
            {
                SettingsGame.isPhone = true;
            }



#endif


        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
#if UNITY_EDITOR


#else
        
        string json = JsonUtility.ToJson(playerInfo);
        YandexManagerSDK.SetLevel(json);
#endif

    }

    public void LoadData(string value)
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }
}
