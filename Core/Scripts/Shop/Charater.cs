using UnityEngine;

public class Character : MonoBehaviour{
	public static Character m_instance;

	public int m_price;
	public bool m_isBought = false;

	void Awake(){
		if(m_instance == null)
			m_instance = this;

		if(m_price == 0)
			m_isBought = true;
	}

	public void Buy(){
		if(SelectCharacter.m_instance.m_playerMoney >= m_price){
			SelectCharacter.m_instance.m_playerMoney -= m_price;
			m_isBought = true;
		}
	}
}