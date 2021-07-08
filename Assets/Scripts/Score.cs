using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Animator _scoreAnimator;
    private ObstacleDestructionZone _destructionZone;

    private void Start()
    {
        _destructionZone = FindObjectOfType<ObstacleDestructionZone>();
        _destructionZone.ObstacleDestroyed += CountScore;
    }

    private void CountScore()
    {
        if (_scoreAnimator != null)
        {
            _score++;
            _scoreText.text = _score.ToString();
            _scoreAnimator.SetTrigger("ScoreChange");
            Debug.Log("check");
        }
    }

    private void OnDestroy()
    {
        _destructionZone.ObstacleDestroyed -= CountScore;
    }
}
