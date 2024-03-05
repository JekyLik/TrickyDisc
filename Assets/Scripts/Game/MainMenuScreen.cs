using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen: MonoBehaviour
{
    [UsedImplicitly]
    public void StartGame() //вызывается при нажатии на кнопку старта игры
    {
        SceneManager.LoadSceneAsync(GlobalConstants.GAME_SCENE);
    }
}
