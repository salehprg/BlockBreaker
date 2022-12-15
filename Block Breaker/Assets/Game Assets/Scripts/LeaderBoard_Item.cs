using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard_Item : MonoBehaviour
{
    public TMPro.TMP_Text player_name;
    public TMPro.TMP_Text score_display;
    
    public void SetScore(string name , string score)
    {
        player_name.text = name;
        score_display.text = score;
    }
}
