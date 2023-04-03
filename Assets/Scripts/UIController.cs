using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    int coins = 0;
    float hpFill = 1;
    [SerializeField]
    TMP_Text coinText;
    [SerializeField]
    TMP_Text deathCoinText;
    [SerializeField]
    Image HPImage;
    

    void Start()
    {

    }
    void Update()
    {
        coinText.text="Монетки: "+coins.ToString();
        deathCoinText.text = "Монеток собрано: " + coins.ToString();
        HPImage.fillAmount = hpFill;
    }
    public void ChangeCoins(int _number)
    {
        coins += _number;
        if (coins < 0)
        {
            coins = 0;
        }
    }
    public void ChangeHP(int _number) 
    {
        hpFill = (float)_number/100;
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;
    }
}
