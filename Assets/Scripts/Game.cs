using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _spawnManager;

    private void OnEnable()
    {
        _player.SetActive(true);
        _spawnManager.SetActive(true);
        
    }
    private void OnDisable()
    {
        _spawnManager.SetActive(false);
        _player.SetActive(false);
    }


}
