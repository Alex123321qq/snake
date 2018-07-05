using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCode : MonoBehaviour {

    //для уничтожения еды
    int TimeDeath = 500;
    int Buff = 0;

    // Use this for initialization
    void Start () {
        //параметры позиции яблока
        float XX = Random.Range(-8, 8);
        float YY = Random.Range(-11, 11);
        //позиция яблока
        this.transform.position = new Vector3(XX, YY, 0);

	}
	
	// Update is called once per frame
	void Update () {
        Buff++;
        if (Buff > TimeDeath)
        {
            DestroyObject(this.gameObject);
        }

    }

    //логика яблока, срабаывает при столкновении объектов
    void OnCollisionEnter(Collision collision)
    {
        SnakeLive S = collision.gameObject.GetComponent<SnakeLive>();
        if (S != null)
        {
            S.AddChank();  //увеличили хвост
            S.ScoreSnake++; //увеличили кол-во очков

            DestroyObject(this.gameObject); //удаление яблока

        }
    }
}
