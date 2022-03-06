using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectCharacter : MonoBehaviour
{
    public static SelectCharacter m_instance;

    public Character[] m_characters;
    public GameObject m_rightArrow;
    public GameObject m_leftArrow;
    public Button m_buyButton;
    public TMP_Text m_buyButtonText;

    public float m_playerMoney;

    int _characterID;
    int _currentCharacter;

    void Awake(){
        if(m_instance == null)
            m_instance = this;
    }

    void Start(){
        if(PlayerPrefs.HasKey("SelectedCharacter")){
            _characterID = PlayerPrefs.GetInt("SelectedCharacter");
            _currentCharacter = PlayerPrefs.GetInt("SelectedCharacter");

            m_buyButton.interactable = false;
            m_buyButtonText.text = "Selected";
        }
        else{
            PlayerPrefs.SetInt("SelectedCharacter", _characterID);
        }

        m_characters[_characterID].gameObject.SetActive(true);

        if(_characterID > 0){
            m_leftArrow.SetActive(true);
        }

        if(_characterID == m_characters.Length){
            m_rightArrow.SetActive(false);
        }
    }

    #region PublicMethods

    public void NextCharacter(){
        if(_characterID < m_characters.Length){
            if(_characterID == 0){
                m_leftArrow.SetActive(true);
            }

            m_characters[_characterID].gameObject.SetActive(false);
            _characterID++;
            m_characters[_characterID].gameObject.SetActive(true);

            if(_currentCharacter == _characterID){
                m_buyButton.interactable = false;
                m_buyButtonText.text = "SELECTED";
            }
            else if(!m_characters[_characterID].m_isBought){
                m_buyButton.interactable = true;
                m_buyButtonText.text = "BUY";
            }
            else{
                m_buyButton.interactable = true;
                m_buyButtonText.text = "SELECT";
            }

            if(_characterID+1 == m_characters.Length)
                m_rightArrow.SetActive(false);
        }
    }

    public void PreviousCharacter(){
        if(_characterID < m_characters.Length){
            m_characters[_characterID].gameObject.SetActive(false);
            _characterID--;
            m_characters[_characterID].gameObject.SetActive(true);
            m_rightArrow.SetActive(true);

            if(_currentCharacter == _characterID && m_characters[_characterID].m_isBought){
                m_buyButton.interactable = false;
                m_buyButtonText.text = "SELECTED";
            }
            else if(!m_characters[_characterID].m_isBought){
                m_buyButton.interactable = true;
                m_buyButtonText.text = "BUY";
            }
            else{
                m_buyButton.interactable = true;
                m_buyButtonText.text = "SELECT";
            }

            if(_characterID == 0){
                m_leftArrow.SetActive(false);
            }
        }
    }

    public void SelectChr(){
        PlayerPrefs.SetInt("SelectedCharacter", _characterID);
        _currentCharacter = _characterID;

        m_buyButton.interactable = false;
        m_buyButtonText.text = "SELECTED";
    }

    public void BuyCharacter(){
        m_characters[_characterID].Buy();
    }

    #endregion
}
