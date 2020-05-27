using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGui : MonoBehaviour {

    [SerializeField]
    Text m_Title;
    [SerializeField]
    Text m_Description;

    public ICardState Card { get; private set; }

    public void SetCard(ICardState card)
    {
        m_Title.text = card.Name;
        //m_Description.text = card.DescriptionText;

        Card = card;
    }
}
