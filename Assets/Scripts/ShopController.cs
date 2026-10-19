using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour {

    public static ShopController instance;
    public TextMeshProUGUI textLevel, textDollar;
    public Transform panelShop;
    public GameObject[] instanceItems = new GameObject[3];
    int[] randomCreateItem = new int[3];

    public AudioSource audioSound;
    public AudioClip pressButton;
    //GameObject[] item = new GameObject[3];
	// Use this for initialization
	void Start () {
        CGameManager.instance.DisableItems();
        UnityEngine.Time.timeScale = 1;
        MakeInstance();
        RandomItem();
        DisplayItems(1, 1);
        // 首次进商城时 MaxLevel 仍为 0，这里显示当前要挑战的关卡（第 1 关）
        int currentLevel = (CGameManager.instance != null && CGameManager.instance.levelCurrent > 0)
            ? CGameManager.instance.levelCurrent
            : Mathf.Max(1, PlayerPrefs.GetInt("MaxLevel"));
        textLevel.text = "关卡 " + currentLevel;
        SetTextMoney();
	}
	
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("MainMenu");
        }
	}
    public void addCoin_fun()
    {
        AdManager.Instance.ShowRewardedVideoAd(onSuccess: () =>
        {
            // 看完广告后增加10金币
            int currentMoney = PlayerPrefs.GetInt("MaxDollar");
            PlayerPrefs.SetInt("MaxDollar", currentMoney + 500);
            
            // 播放按钮音效
            audioSound.PlayOneShot(pressButton);
            
            // 更新UI显示
            SetTextMoney();
            
            Debug.Log("看完广告，成功获得500金币");

        }, onFail: (error) =>
        {
            Debug.LogError($"广告播放失败，无法获得金币: {error}");
        });
    }
    public void SetTextMoney()
    {
        audioSound.PlayOneShot(pressButton);
        textDollar.text = "" + PlayerPrefs.GetInt("MaxDollar");
    }
    void RandomItem()
    {
        for(int i = 0; i < 3; i++)
        {
            int count = 0;
            while(count < 3)
            {
                int ran = Random.RandomRange(1, 7);
                if (!CheckSame(ran))
                {
                    randomCreateItem[i] = ran;
                    count++;
                }
            }
            
            
        }
    }

    bool CheckSame(int m)
    {
        for(int i = 0; i < 3; i++)
        {
            if (randomCreateItem[i] == m)
            {
                return true;
            }
        }
        return false;
    }
    void DisplayItems(int position, int item)
    {
        //switch (position)
        //{
        //    case 1:
        //        Vector3 vector1 = new Vector3(-130, -260, 0);
        //        Instantiate(Resources.Load("" + item), vector1, Quaternion.identity);
        //        break;
        //    case 2:
        //        Vector3 vector2 = new Vector3(-290, -260, 0);
        //        Instantiate(Resources.Load("" + item), vector2, Quaternion.identity);
        //        break;
        //    case 3:
        //        Vector3 vector3 = new Vector3(-450, -260, 0);
        //        Instantiate(Resources.Load("" + item), vector3, Quaternion.identity);
        //        break;
        //    case 4:
        //        Vector3 vector4 = new Vector3(-610, -260, 0);
        //        Instantiate(Resources.Load("" + item), vector4, Quaternion.identity);
        //        break;
        //    case 5:
        //        Vector3 vector5 = new Vector3(-770, -260, 0);
        //        Instantiate(Resources.Load("" + item), vector5, Quaternion.identity);
        //        break;
        //}
        for(int i = 0; i < 3; i++)
        {
            Vector3 vector3 = new Vector3(0, 120 - 225*i, 0);
            string nameLoad = "Item" + randomCreateItem[i];
            // 添加空检查，确保资源存在
            Object prefab = Resources.Load(nameLoad);
            if (prefab != null)
            {
                instanceItems[i] = Instantiate(prefab, vector3, Quaternion.identity) as GameObject;
                if (instanceItems[i] != null && panelShop != null)
                {
                    instanceItems[i].transform.SetParent(panelShop, false);
                }
            }
            //item[i] = Instantiate(Resources.Load("Panel 1"), vector3, Quaternion.identity) as GameObject;
        }
    }
    public void PlayLevel()
    {
        audioSound.PlayOneShot(pressButton);
        // 使用异步加载场景
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("NextLevel");
    }
}
