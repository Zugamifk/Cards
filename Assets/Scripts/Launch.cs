using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField]
    GameObject m_GameController;

    private void Awake()
    {
        Instantiate(m_GameController);
    }
}
