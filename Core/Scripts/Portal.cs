using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Animator m_vignetteAnim;
    public string m_nextSceneIndex = "Game2";

    float _countDown = 4f;

    bool _isInTrigger = false;

    #region PrivateMethods

    void Update(){
        if(_isInTrigger){
            m_vignetteAnim.SetBool("isOpenned", true);
            _countDown -= Time.deltaTime;
            if(_countDown < 1f){
                SceneManager.LoadScene(m_nextSceneIndex);
            }
        }
        else{
            m_vignetteAnim.SetBool("isOpenned", false);
            _countDown = 4f;
        }
    }

    #endregion

    #region TriggerMethods

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            _isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            _isInTrigger = false;
        }
    }

    #endregion
}
