using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBorads : MonoBehaviour
{
    public GameObject leaderboard_item;
    public RectTransform canvas;

    private void Start() {
        if(SceneManager.GetActiveScene().name == "Scoreboard scene")
        {
            GetHighScores();
        }
    }
    public void GetHighScores()
    {
        var phone_guid = RSA.Encrypt(PlayerPrefs.GetString("guid"));

        APIHelper.HighScoreDelegate del = DelegateMethod;   

        StartCoroutine(APIHelper.HighScores(phone_guid , del));
    }

    public void DelegateMethod(List<ScoreModel> scoreModels ,bool success)
    {
        if(success)
        {
            foreach (var score in scoreModels)
            {
                var item = Instantiate(leaderboard_item , canvas.transform);
                item.GetComponent<LeaderBoard_Item>().SetScore(score.nickname , score.score.ToString());
            }
        }
    }

    public void SubmitScore(int score)
    {
        ScoreModel scoreModel = new ScoreModel();
        scoreModel.phone_guid = RSA.Encrypt(PlayerPrefs.GetString("guid"));
        scoreModel.score = score;

        APIHelper.ScoreDelegate del = DelegateMethod;   

        StartCoroutine(APIHelper.SubmitScore(scoreModel , del));
    }

    public void DelegateMethod(ScoreModel licenseModel ,bool success)
    {
        if(!success)
        {
            print("Error Occured");
        }
        else
        {
            SceneManager.LoadScene("Scoreboard scene");
        }
    }
}
