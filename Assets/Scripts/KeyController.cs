using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    GameObject uicontroller;
    void Start()
    {
        uicontroller = GameObject.Find("Canvas");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //переписать на синглтон
            uicontroller.GetComponent<UIController>().ChangeKeys(1);
            Destroy(gameObject);
        }
    }
}
