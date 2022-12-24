using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBorads : MonoBehaviour
{
    public GameObject leaderboard_item;
    public RectTransform canvas;
    public GameObject loading;
    public TMPro.TMP_Text palyer_score;
    public TMPro.TMP_Text palyer_nickname;

    GameObject _loading;

    private void Start() {
        if(SceneManager.GetActiveScene().name == "Scoreboard scene")
        {
            palyer_score.text = $"Your score : {PlayerPrefs.GetInt("score" , 0)}";
            palyer_nickname.text = $"{PlayerPrefs.GetString("nickname" ,"")}";

            GetHighScores();
        }
    }
    public void GetHighScores()
    {
        _loading = Instantiate(loading , canvas.transform);

        var phone_guid = RSA.Encrypt(PlayerPrefs.GetString("guid"));

        APIHelper.HighScoreDelegate del = DelegateMethod;   

        StartCoroutine(APIHelper.HighScores(phone_guid , del));
    }

    public void DelegateMethod(List<ScoreModel> scoreModels ,bool success)
    {
        if(success)
        {
            Destroy(_loading);
            foreach (var score in scoreModels)
            {
                var nickname = PlayerPrefs.GetString("nickname");
                var item = Instantiate(leaderboard_item , canvas.transform);
                item.GetComponent<LeaderBoard_Item>().SetScore(score.nickname , score.score.ToString() , nickname == score.nickname);
            }
        }
        else
        {
            Destroy(_loading , 2);
            _loading.GetComponentInChildren<TMPro.TMP_Text>().text = "Failed to Fetch Data";
        }
    }

    public void SubmitScore(int score)
    {
        _loading = Instantiate(loading , canvas.transform);

        ScoreModel scoreModel = new ScoreModel();
        scoreModel.phone_guid = RSA.Encrypt(PlayerPrefs.GetString("guid"));
        scoreModel.score = score;

        APIHelper.ScoreDelegate del = OnSubmit;   

        StartCoroutine(APIHelper.SubmitScore(scoreModel , del));

        // SceneManager.LoadScene("Scoreboard scene");
    }

    public void OnSubmit(ScoreModel licenseModel ,bool success)
    {
        if(!success)
        {
            Destroy(_loading , 2);
            _loading.GetComponentInChildren<TMPro.TMP_Text>().text = "Failed to Submit Data";
        }
        else
        {
            Destroy(_loading);
            SceneManager.LoadScene("Scoreboard scene");
        }
    }
}
