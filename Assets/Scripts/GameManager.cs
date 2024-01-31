using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public SimonAnimatorController simon;
    public List<int> simonMoves;
    public List<int> playerMoves;
    public int danceMoves = 3;
    System.Random random;
    public bool isGameOver;

    public bool simonsTurn = false;

    public TMP_Text gameText;
    
    // Start is called before the first frame update
    void Start()
    {
        simon = GameObject.FindGameObjectWithTag("Simon").GetComponent<SimonAnimatorController>();

        isGameOver = true;
        GameOver();
        gameText = GameObject.Find("GameText").GetComponent<TMP_Text>();
        gameText.text = "Press Space to Start";
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGameOver = false;
            GameOver();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false; //How to quit in the Unity Editor
            //Application.Quit(); how you quit a .exe after the game is built
        }
    }


    IEnumerator SimonSays()
    {
        simonsTurn = true;

        random = new System.Random("Jump On It".GetHashCode());

        SetMoves();

        yield return new WaitForSeconds(1f);

        gameText.text = "";

        for(int i = 0; i< simonMoves.Count; i++)
        {
            simon.SimonDances(simonMoves[i]);
            yield return new WaitForSecondsRealtime(simon.animTimes[simonMoves[i]]);
        }

        gameText.text = "Your Turn!";

        yield return new WaitForSeconds(1f);

        gameText.text = "";

        simonsTurn = false;  

        yield return null;

    }

    void SetMoves()
    {
        simonMoves = new List<int>();
        playerMoves = new List<int>();

        for(int i = 0; i < danceMoves; i++)
        {
            simonMoves.Add(random.Next(0,simon.animations.Count));
        }

        danceMoves++;
    }
    void GameOver()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
            simonMoves = new List<int>();
            danceMoves = 3;
        }
        else
        {
            Time.timeScale = 1;
            StartCoroutine(SimonSays());
            gameText.text = "Simon's Turn";
        }
    }

    public void CheckPlayerMoves(int index)
    {
        if(simonMoves[playerMoves.Count-1] != index)
        {
            gameText.text = "Better Luck Next Time!\n\nPress Space to Try Again\n\nPress Escape to Quit";
            isGameOver = true;
            GameOver();
        }

        if(simonMoves.Count == playerMoves.Count)
        {
            StartCoroutine(SimonSays());
        }
    }

}
