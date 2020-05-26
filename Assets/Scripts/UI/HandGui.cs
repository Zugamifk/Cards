using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGui : MonoBehaviour {

    [SerializeField]
    CardGui m_CardPrefab;
    [SerializeField]
    Transform m_CardParent;

    public void AddCard(ICardState card)
    {
        var c = Instantiate(m_CardPrefab);
        c.Initialize(card);
        c.transform.SetParent(m_CardParent, false);
    }
}
