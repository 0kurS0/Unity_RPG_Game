using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWindow : MonoBehaviour
{
    public string m_windowName;
    public bool m_isOpenned;

    public void Open(){
        m_isOpenned = true;
        gameObject.SetActive(true);
    }

    public void Close(){
        m_isOpenned = false;
        gameObject.SetActive(false);
    }
}
