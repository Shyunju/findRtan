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
    }
}
