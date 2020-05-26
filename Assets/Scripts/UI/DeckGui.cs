using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckGui : MonoBehaviour
{
    [SerializeField]
    Button m_Button;

    public event System.Action OnClicked;

    private void Awake()
    {
        m_Button.onClick.AddListener(() => OnClicked?.Invoke());
    }
}
