using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGui : MonoBehaviour {

    [SerializeField]
    Text m_Title;
    [SerializeField]
    Text m_Description;

    public void Initialize(ICardState card)
    {
        m_Title.text = card.Data.Name;
        //m_Description.text = card.DescriptionText;
    }
}
