using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGui : MonoBehaviour {

    [SerializeField]
    Text m_Title;
    [SerializeField]
    Text m_Description;

    public void Initialize(CardData card)
    {
        m_Title.text = card.Title;
        m_Description.text = card.DescriptionText;
    }
}
