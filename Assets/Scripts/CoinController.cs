using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{ 
    GameObject uicontroller;
    void Start()
    {
        uicontroller = GameObject.Find("Canvas");
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //переписать на синглтон
            uicontroller.GetComponent<UIController>().ChangeCoins(1);
            Destroy(gameObject);
        }
    }
}
