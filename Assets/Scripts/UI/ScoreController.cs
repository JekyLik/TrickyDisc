using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ScoreController: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreLabel;
    [SerializeField]
    private int _rewardPerEnemy;
    [SerializeField]
    private float _animationDuration;
    [SerializeField]
    private float _scaleFactor;
    [SerializeField]
    private AudioSource _scoreChangeAudioClip;

    private int _score;
    
    [UsedImplicitly]
    public void AddScore() //вызывается по ивенту, когда игрок уничтожил врага
    {
        _score += _rewardPerEnemy;
        _scoreChangeAudioClip.Play();
        _scoreLabel.text = _score.ToString();
        _scoreLabel.transform
            .DOPunchScale(Vector3.one * _scaleFactor, _animationDuration, 0)
            .OnComplete(() => _scoreLabel.transform.localScale = Vector3.one);
    }
    
    private void Awake()
    {
        _scoreLabel.text = "0";
    }
    
    private void OnDestroy()
    {
        PlayerPrefs.SetInt(GlobalConstants.SCORE_PREFS_KEY, _score);
        PlayerPrefs.Save();
    }
}
