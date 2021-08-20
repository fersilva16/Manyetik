using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
  public string nomeDaCena;

  public void MudarCena()
  {
    SceneManager.LoadScene(nomeDaCena);
  }

  public void Sair()
  {
    Application.Quit();
  }

  public void ReiniciarCena()
  {
    SceneManager.LoadScene(nomeDaCena);
  }
}
