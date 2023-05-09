using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Text timeTxt;
    public GameObject endTxt;
    float time;
    public GameObject card;
    public static gameManager I;
    public GameObject firstCard;
    public GameObject secondCard;
    public AudioClip match;
    public AudioSource AudioSource;

    private void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();  //����Ʈ ������ ������ ������ ����

        for (int i =0; i<16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i % 4) * 1.4f -2.1f;
            float y = (i / 4) * 1.4f -3f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if(time > 3f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void isMatched() //ī�� ��Ī�� �Ǵ��ϴ� �Լ�
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if(firstCardImage == secondCardImage)
        {
            AudioSource.PlayOneShot(match);
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            
            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }
        firstCard = null;
        secondCard = null;
    }

    void GameEnd()
    {
        Time.timeScale = 0f;
        endTxt.SetActive(true);
    }
    public void retryGame()
    {
        SceneManager.LoadScene("MainScene");

    }
}
