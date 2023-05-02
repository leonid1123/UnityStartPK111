using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CestController : MonoBehaviour
{
    [SerializeField]
    GameObject ChestText;
    [SerializeField]
    List<GameObject> ChestList;
    bool canOpen = true;
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
        if (canOpen)
        {
            float rnd = 1;
            int num = -1;
            do
            {
                rnd = Random.Range(0, 1f);
                if (num == ChestList.Count - 1)
                {
                    num = 0;
                }
                num++;
            } while (rnd > 0.34f);

            Debug.Log(rnd);
            GameObject drop = Instantiate(ChestList[num], transform.position, transform.rotation);
            drop.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 5, ForceMode2D.Impulse);
            canOpen = false;
        }
    }
}
