using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
 public void PlayGame()
 {
    SceneManager.LoadSceneAsync(1);
 }
}
