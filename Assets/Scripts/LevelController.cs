using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    private FinishZone _finishZone;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _finishZone = FindObjectOfType<FinishZone>();
        _finishZone.PlayerWon += PlayerWon;
        _player = FindObjectOfType<Player>();
        _player.PlayerLost += PlayerLost;
    }

    // Update is called once per frame
    void Update()
    {
        
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
