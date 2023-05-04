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
        //애니메이터 isOpen 트루
        transform.Find("front").gameObject.SetActive(true);
        //프론트 셋액티브 트루
        transform.Find("back").gameObject.SetActive(false);
        //백 셋액티브 폴스

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
