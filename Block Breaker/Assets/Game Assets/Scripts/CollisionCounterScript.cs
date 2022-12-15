using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionCounterScript : MonoBehaviour
{
    public int score;
    public TMP_Text text;
    public void addScore(int _score)
    {
        score += _score;

        text.text = score.ToString();
    }
}
