using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _currentScoreLabel;
    [SerializeField]
    private TextMeshProUGUI _bestScoreLabel;
    [SerializeField]
    private float _newBestScoreAnimationDuration;
    [SerializeField]
    private AudioSource _bestScoreChangedSound;
    
    [UsedImplicitly]
    public void RestartGame() //вызывается при нажатии на кнопку рестарта игры
    {
        SceneManager.LoadSceneAsync(GlobalConstants.GAME_SCENE);
    }

    [UsedImplicitly]
    public void ExitGame() //вызывается при нажатии на кнопку выхода из игры
    {
#if UNITY_EDITOR //данная конструкция выполняется только в редакторе Unity
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    
    private void SaveNewBestSore(int bestScore)
    {
        PlayerPrefs.SetInt(GlobalConstants.BEST_SCORE_PREFS_KEY, bestScore);
        PlayerPrefs.Save();
    }
    
    private void Awake()
    {
        var currentScore = PlayerPrefs.GetInt(GlobalConstants.SCORE_PREFS_KEY);
        var bestScore = PlayerPrefs.GetInt(GlobalConstants.BEST_SCORE_PREFS_KEY);
        
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            SaveNewBestSore(bestScore);
            ShowNewBestScoreAnimation();
        }
        
        _currentScoreLabel.text = currentScore.ToString();
        _bestScoreLabel.text = $"BEST {bestScore.ToString()}";
    }
    
    private void ShowNewBestScoreAnimation()
    {
        _bestScoreLabel.transform.DOPunchScale(Vector3.one, _newBestScoreAnimationDuration, 0);
        _bestScoreChangedSound.Play();
    }
}