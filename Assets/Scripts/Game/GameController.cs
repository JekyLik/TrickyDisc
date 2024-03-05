using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour
{
    [SerializeField]
    private float _sceneChangeDelay;
    
    [UsedImplicitly]
    public void OnPlayerDied() //вызывается по ивенту смерти игрока
    {
        StartCoroutine(ShowGameOver());
    }
    
    private void Awake()
    {
        Application.targetFrameRate = 60; //максимальное значение кадров в секунду
    }
    
    private IEnumerator ShowGameOver()
    {
        //задержка, чтобы успели проиграться анимация и звук смерти игрока.
        yield return new WaitForSeconds(_sceneChangeDelay);
        SceneManager.LoadSceneAsync(GlobalConstants.GAME_OVER_SCENE);
    }
    
}
