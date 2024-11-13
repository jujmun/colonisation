using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int scoreInt;
    public Text scoreText;

    public void addScore(){
        scoreInt++;
        scoreText.text = scoreInt.ToString();
    }
}
