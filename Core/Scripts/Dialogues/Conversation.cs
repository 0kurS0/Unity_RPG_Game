#pragma warning disable 0649
using UnityEngine;

[CreateAssetMenu(fileName = "Add Conversation", menuName = "MoRF/Dialogues/Add Conversation")]
public class Conversation : ScriptableObject{
	[SerializeField]
	private DialogueLine[] _dialogues;

	public DialogueLine DialogueStory(int id){
		return _dialogues[id];
	}

	public int LengthDialogs(){
		return _dialogues.Length - 1;
	}
}