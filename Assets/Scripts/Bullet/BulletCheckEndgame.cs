using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCheckEndgame : MonoBehaviour
{
    private float _upPos, _downPos;

    private bool _inGame = false;

    private void Awake()
    {
        _upPos = Camera.main.orthographicSize;
        _downPos = -Camera.main.orthographicSize;

        _inGame = true;

        UIManager.Instance.GetPanel<PlayAgainPanel>().OnWatchAds += ResetGame;
    }


    private void ResetGame() => _inGame = true;

    private void OnDestroy()
    {
        UIManager.Instance.GetPanel<PlayAgainPanel>().OnWatchAds -= ResetGame;
    }

    void Update()
    {
        if (_inGame)
        {
            if( (transform.position.y > _upPos || transform.position.y < _downPos) 
                && GameplayController.Instance.GetCurrentType() != typeof(Win1GameState))
            {
                GameplayController.Instance.LoseLevelState();
                _inGame = false;
                Pooling.DestroyObject(this.gameObject);
            }
        }
    }
}
