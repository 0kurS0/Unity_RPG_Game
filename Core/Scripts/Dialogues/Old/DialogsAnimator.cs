using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsAnimator : MonoBehaviour
{
    public Animator m_dialogButtonAnim;
    public DialogsManager m_manager;

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player")
            m_dialogButtonAnim.SetBool("isOpenned", true);
    }

    public void OnTriggerExit(Collider other){
         if(other.gameObject.tag == "Player"){
            m_dialogButtonAnim.SetBool("isOpenned", false);
            m_manager.EndDialog();
            //Destroy(this.gameObject);
         }
    }
}
