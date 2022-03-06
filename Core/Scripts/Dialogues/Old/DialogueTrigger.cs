using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialog m_dialog;

    #region PublicMethods

    public void OpenDialog(){
        FindObjectOfType<DialogsManager>().StartDialog(m_dialog);
    }

    #endregion
}
