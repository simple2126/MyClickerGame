using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager Instance;
    public GameObject Player { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            if (Instance == this)
            {
                Destroy(gameObject);
            }

        }

        Player = GameObject.FindGameObjectWithTag("Player");
    }
}
