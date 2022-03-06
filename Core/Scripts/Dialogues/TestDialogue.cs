using UnityEngine;

public class TestDialogue : MonoBehaviour{
	public Conversation m_conv;
	public Animator m_dialogWindowAnim;

	public void OnTriggerEnter(Collider other){
		DialoguesManager.StartConversation(m_conv);
	}

	public void OnTriggerExit(Collider other){
		Destroy(this.gameObject);
	}
}