using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguesManager : MonoBehaviour{
	public static DialoguesManager m_instance;

	public TextMeshProUGUI m_speakerName, m_dialogue, m_nextButtonText;
	public Image m_speakerAvatar;
	public Animator m_dialogueWindowAnim;

	int _currentID;

	Conversation _currentConv;
	Coroutine _typing;

	void Awake(){
		if(m_instance == null)
			m_instance = this;
		else
			Destroy(gameObject);
	}

	#region PublicMethods

	public static void StartConversation(Conversation conv){
		m_instance.m_dialogueWindowAnim.SetBool("isOpenned", true);
		m_instance._currentID = 0;
		m_instance._currentConv = conv;
		m_instance.m_speakerName.text = "";
		m_instance.m_dialogue.text = "";
		m_instance.m_nextButtonText.text = "Next>>";

		m_instance.NextConversation();
	}

	public void NextConversation(){
		if(_currentID > _currentConv.LengthDialogs()){
			m_instance.m_dialogueWindowAnim.SetBool("isOpenned", false);
			return;
		}

		m_speakerName.text = _currentConv.DialogueStory(_currentID).m_speaker.SpeakerName();

		if(_typing == null){
			_typing = m_instance.StartCoroutine(TypeText(_currentConv.DialogueStory(_currentID).m_dialogue));
		}
		else{
			m_instance.StopCoroutine(_typing);
			_typing = null;
			_typing = m_instance.StartCoroutine(TypeText(_currentConv.DialogueStory(_currentID).m_dialogue));
		}

		m_speakerAvatar.sprite = _currentConv.DialogueStory(_currentID).m_speaker.SpeakerAvatar();
		_currentID++;

		if(_currentID >= _currentConv.LengthDialogs()){
			m_nextButtonText.text = "Next>>";
		}
	}

	#endregion

	IEnumerator TypeText(string text){
		m_dialogue.text = "";
		bool _isEnded = false;
		int id = 0;

		while(!_isEnded){
			m_dialogue.text += text[id];
			id++;
			yield return new WaitForSeconds(0.02f);

			if(id == text.Length)
				_isEnded = true;
		}

		_typing = null;
	}
}