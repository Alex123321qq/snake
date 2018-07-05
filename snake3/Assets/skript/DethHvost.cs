using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethHvost : MonoBehaviour {


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        SnakeLive S = collision.gameObject.GetComponent<SnakeLive>();
        if (S != null)
        {
            S.SnakeDestroy(); //исчезновение змеи при ударе со стеной

        }
    }
}