using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{

    //режим игры
    int GameMode = 0;

    public GameObject Snake; //ссылка на змею
    GameObject SnakeObj; //змея
    float XX = 0, YY = 0; //направление
    public GameObject Eat; //для создания еды

    //для появления еды
    int TimeSpeed = 50;
    int Buff = 0;

    //функция добавления яблок
    void AddEat()
    {
        Instantiate(Eat);

    }

    //функция добавления змеи на экран
    void CreateSnake()
    {
        //ставим змею на поле
        SnakeObj = Instantiate(Snake) as GameObject;
        SnakeObj.name = "Snake";

        GameMode = 1;
    }

    // Use this for initialization
    void Start()
    {
        //CreateSnake();
    }

    // Update is called once per frame
    void Update()
    {
        if (SnakeObj != null)
        {
            XX = 0;
            YY = 0;
            if (Input.GetAxis("Horizontal") > 0)
            {
                XX = 1;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                XX = -1;
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                YY = 1;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                YY = -1;
            }

            if ((XX != 0) || (YY != 0))
            {
                SnakeLive S = SnakeObj.GetComponent<SnakeLive>();

                if (XX != 0)
                {
                    S.DirectionHod = new Vector2(XX, 0);
                }
                if (YY != 0)
                {
                    S.DirectionHod = new Vector2(0, YY);
                }
            }
        }
        else
        {
            GameMode = 0;
        }

        if (GameMode > 0)
        {
            Buff++;
            if (Buff > TimeSpeed)
            {
                AddEat();
                Buff = 0;
            }
        }

    }

    //кнопка старта
    void OnGUI()
    {
        int posX = Screen.height / 2;
        int posY = Screen.width / 2;

        switch (GameMode)
        {
            case 0:
               if( GUI.Button(new Rect(new Vector2(posX, posY-100), new Vector2(200, 30)), "Start"))
                {
                    CreateSnake();
                }
                if (GUI.Button(new Rect(new Vector2(posX, posY-40), new Vector2(200, 30)), "Quit"))
                {
                    Application.Quit();
                }
                break;

            case 1:
                SnakeLive S = SnakeObj.GetComponent<SnakeLive>();

                int Score = 0;

                if (S != null)
                {
                    Score = S.ScoreSnake;
                }
                GUI.Label(new Rect(new Vector2(posX+100, 0), new Vector2(200, 30)), "Score:" + Score);

                break;
        }
    }
}