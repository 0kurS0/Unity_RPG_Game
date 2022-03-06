#pragma warning disable 0649
using UnityEngine;

[CreateAssetMenu(fileName = "Add Dialogue Speaker", menuName = "MoRF/Dialogues/Add Dialogue Speaker")]
public class Speaker : ScriptableObject{
	[SerializeField]
	private string _speakerName;
	[SerializeField]
	private Sprite _speakerAvatar;

	public string SpeakerName(){
		return _speakerName;
	}

	public Sprite SpeakerAvatar(){
		return _speakerAvatar;
	}
}