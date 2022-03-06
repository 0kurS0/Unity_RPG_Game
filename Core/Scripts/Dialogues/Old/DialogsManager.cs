using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogsManager : MonoBehaviour
{
    public TMP_Text m_nameText;
    public TMP_Text m_dialogText;

    public Animator m_dialogButtonAnim;
    public Animator m_dialogWindowAnim;

    private Queue<string> _dialogAreas;

    void Start(){
        _dialogAreas = new Queue<string>();
    }

    public void StartDialog(Dialog dialog){
        m_dialogWindowAnim.SetBool("isOpenned", true);
        m_dialogButtonAnim.SetBool("isOpenned", false);

        m_nameText.text = dialog.m_name;
        _dialogAreas.Clear();

        foreach(string dialogText in dialog.m_dialogAreas){
            _dialogAreas.Enqueue(dialogText);
        }

        StartNewDialogText();
    }

    public void StartNewDialogText(){
        if(_dialogAreas.Count == 0){
            EndDialog();
            return;
        }

        string dialogText = _dialogAreas.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeDialog(dialogText));
    }

    IEnumerator TypeDialog(string dialogText){
        m_dialogText.text = "";

        foreach(char letter in dialogText.ToCharArray()){
            m_dialogText.text += letter;
            yield return null;
        }
    }

    public void EndDialog(){
        m_dialogWindowAnim.SetBool("isOpenned", false);
    }
}
