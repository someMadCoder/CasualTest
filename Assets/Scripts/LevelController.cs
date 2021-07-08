using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    private FinishZone _finishZone;
    private Player _player;

    private void Start()
    {
        _finishZone = FindObjectOfType<FinishZone>();
        _finishZone.PlayerWon += PlayerWon;
        _player = FindObjectOfType<Player>();
        _player.PlayerLost += PlayerLost;
    }

    private void PlayerWon()
    {
        _winPanel?.SetActive(true);
    }

    private void PlayerLost()
    {
        _losePanel?.SetActive(true);
    }

    private void OnDestroy()
    {
        _finishZone.PlayerWon -= PlayerWon;
        _player.PlayerLost -= PlayerLost;
    }

}
