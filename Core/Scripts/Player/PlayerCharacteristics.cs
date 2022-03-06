using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacteristics : MonoBehaviour
{
    public Text m_healthText;
    public float m_health;

    void Update(){
        m_healthText.text = m_health.ToString() + "HP";
    }

    public void TakeDamage(float hp){
        m_health -= hp;
    }
}
