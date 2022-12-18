using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard_Item : MonoBehaviour
{
    public TMPro.TMP_Text player_name;
    public TMPro.TMP_Text score_display;
    public Color playerColor;
    
    public void SetScore(string name , string score , bool playerScore = false)
    {
        player_name.text = name;
        score_display.text = score;
        if(playerScore)
        {
            score_display.color = playerColor;
        }
    }
}
