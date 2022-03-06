using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    public static MenuManager m_instance;

    [SerializeField]
    private MenuWindow[] _windows;
    [SerializeField]
    private Animator _loadingAnim;

    void Awake(){
        if(m_instance == null)
            m_instance = this;
    }

    void Start(){
        StartCoroutine(Loading());
    }

    #region PublicMethods

    public void OpenWindow(string windowName){
        for(int i=0; i<_windows.Length; i++){
            if(_windows[i].m_windowName == windowName){
                OpenWindow(_windows[i]);
            }
            else if(_windows[i].m_isOpenned){
                CloseWindow(_windows[i]);
            }
        }
    }

    public void OpenWindow(MenuWindow window){
        for(int i=0; i<_windows.Length; i++){
            if(_windows[i].m_isOpenned){
                CloseWindow(_windows[i]);
            }
        }
        window.Open();
    }
    public void CloseWindow(MenuWindow window){
        window.Close();
    }

    #endregion

    IEnumerator Loading(){
        yield return new WaitForSeconds(1);
        OpenWindow("home");
        StopAllCoroutines();
    }
}
