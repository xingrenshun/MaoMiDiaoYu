using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour {

    public TextMeshProUGUI textTarget, textLevel;
    float timeDelay;
	// Use this for initialization
	void Start () {
       
        textTarget.text = "" + CGameManager.instance.GetScoreTarget(CGameManager.instance.levelCurrent).ToString();
        textLevel.text = "第 " + CGameManager.instance.levelCurrent+ " 关 ";
	}
	
	// Update is called once per frame
	void Update () {
        timeDelay += UnityEngine.Time.deltaTime * 10;
        if(timeDelay > 25)
        {
            //Application.LoadLevel("NghiaDemo");
            int level = CGameManager.instance.levelCurrent;
            string sceneName;
            if(level <= 10)
            {
                sceneName = "Level" + level;
            }
            else
            {
                int ran = Random.RandomRange(1, 10);
                sceneName = "Level" + ran;
            }
            
            // 使用异步加载场景
            SceneManager.LoadSceneAsync(sceneName);
            //else if(level > 10 && level <= 20)
            //{
            //    level -= 10;
            //    Application.LoadLevel("Level" + level);
            //}
            //else if (level > 20 && level <= 30)
            //{
            //    level -= 20;
            //    Application.LoadLevel("Level" + level);
            //}
            //else if (level > 30 && level <= 40)
            //{
            //    level -= 30;
            //    Application.LoadLevel("Level" + level);
            //}
            //else if (level > 40 && level <= 50)
            //{
            //    level -= 40;
            //    Application.LoadLevel("Level" + level);
            //}
            
        }
	}
}
