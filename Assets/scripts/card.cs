using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openCard()
    {
        anim.SetBool("isOpen", true);
        //�ִϸ����� isOpen Ʈ��
        transform.Find("front").gameObject.SetActive(true);
        //����Ʈ �¾�Ƽ�� Ʈ��
        transform.Find("back").gameObject.SetActive(false);
        //�� �¾�Ƽ�� ����

        if(gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
        }
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
        }
    }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 0.03f);
    }
    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void closeCard()
    {
        Invoke("closeCardInvoke", 1f);
    }
    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("front").gameObject.SetActive(false);
        transform.Find("back").gameObject.SetActive(true);
    }
}
