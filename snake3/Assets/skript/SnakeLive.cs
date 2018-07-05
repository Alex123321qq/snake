using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLive : MonoBehaviour
{

    public int ScoreSnake = 0; //количество собранных яблок
    int TimeSpeed = 10; //скорость задержки до следующего движения змейки
    int buff = 0; //накопление времени скорости   

    public GameObject SnakeBody; //хвост змеи 1 часть

    List<GameObject> BodySnake = new List<GameObject>(); //тело змеи

    public Vector2 DirectionHod; //направление движения змеи

    float SpeedMove = 3; //расстояние движения

    //функция увеличения хвоста
    public
        void AddChank()
    {
        Vector3 Position = transform.position; //получаем текущую позицию головы
        //проверка на наличие хвоста у змеи
        if (BodySnake.Count > 0)
        {
            Position = BodySnake[BodySnake.Count - 1].transform.position; //получаем текущую позицию хвоста
        }
        Position.y+=0.5f;
        //создание еще одной части хвоста
        GameObject Body = Instantiate(SnakeBody, Position, Quaternion.identity) as GameObject;

        BodySnake.Add(Body);//добавление части к хвосту
    }

    //функция движения змеи
    void SnakeStep()
    {
        if ((DirectionHod.x != 0) || (DirectionHod.y != 0))
        {
            Rigidbody ComponentRig = GetComponent<Rigidbody>(); //текущая позиция головы змеи

            //задаем новую позицию головы змеи
            ComponentRig.velocity = new Vector3(DirectionHod.x * SpeedMove, DirectionHod.y * SpeedMove, 0);

            //для задания новой позиции хвоста змеи
            if (BodySnake.Count > 0)
            {
                BodySnake[0].transform.position = transform.position;

                //двигаем хвост по голове
                for (int BodyIndex = BodySnake.Count - 1; BodyIndex > 0; BodyIndex--)
                {
                    BodySnake[BodyIndex].transform.position = BodySnake[BodyIndex - 1].transform.position;
                }
            }
        }
    }

    //функция смерти змеи
    public void SnakeDestroy()
    {
        //остановка
        DirectionHod = new Vector2(0, 0);
        //убираем хвост
        foreach (GameObject o in BodySnake) DestroyObject(o.gameObject);
        //убираем голову
        DestroyObject(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        BodySnake.Clear();

        //создаем начальный хвост длиной 3
        for (int i = 0; i < 3; i++)
        {
            AddChank();
        }
    }

    // Update is called once per frame
    void Update()
    {
        buff++;
        if (buff > TimeSpeed)
        {
            SnakeStep();
            buff = 0;
        }
    }
    void OnCollisionEnter(Collision SnakeBody)
    {
        SnakeLive S = SnakeBody.gameObject.GetComponent<SnakeLive>();
        if (S != null)
        {
            S.SnakeDestroy(); //исчезновение змеи при ударе со стеной

        }
    }
}





