using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    int coins = 0;
    [SerializeField]
    TMP_Text coinText;
    

    void Start()
    {

    }
    void Update()
    {
        coinText.text="Монетки: "+coins.ToString();
    }
    public void ChangeCoins(int _number)
    {
        coins += _number;
        if (coins < 0)
        {
            coins = 0;
        }
    }
}
