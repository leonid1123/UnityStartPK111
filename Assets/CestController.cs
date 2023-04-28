using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CestController : MonoBehaviour
{
    [SerializeField]
    GameObject ChestText;
    void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        ChestText.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            ChestText.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            ChestText.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void OpenChest()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        ChestText.GetComponent<TextMesh>().text = "Вы всё забрали отсюда,\n паук и две мышки теперь живут в сундуке.\n Пожалуйста не мешайте им.";
        
    }
}
