using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text scoreText,Winning;
    public Transform Ball,Player,Ai;
    Vector3 BallVec, PlayerVec, AiVec;
    byte PlayerScore = 0,AiScore=0;
    private void Start()
    {
        WriteText();
        BallVec = Ball.position;
        PlayerVec = Player.position;
        AiVec = Ai.position;
        Winning.enabled = false;
    }
    void Update()
    {
        PlayerGoal();
        AiGoal();
        IsOver();
        Restart();
    }
    void PlayerGoal() 
    {
        if (Ball.transform.position.x>81)
        {
            PlayerScore++;
            WriteText();
            StartLocation();
        }
    }
    void AiGoal()
    {
        if (Ball.transform.position.x < -81)
        {
            AiScore++;
            WriteText();
            StartLocation();
        }
    }
    void WriteText()
    {
        scoreText.text = "Player " + PlayerScore + ":" + AiScore + " Computer";
    }
    void StartLocation()
    {
        Ai.position = AiVec;
        Player.position = PlayerVec;
        Ball.position = BallVec;
    }
    void IsOver()
    {
        if(PlayerScore==3)
        {
            Winning.enabled = true;
            Winning.text = "Player Won\n Tekrar oynamak için SPACE basýnýz";
            Winning.color=Color.blue;
        }
        else if (AiScore == 3)
        {
            Winning.enabled = true;
            Winning.text = "Computer Won\n Tekrar oynamak için SPACE basýnýz";
            Winning.color = Color.red;
        }
    }
    void Restart()
    {
        if (PlayerScore == 3||AiScore==3)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Match_Scene");
                Time.timeScale = 1;
            }
        }
    }
}
