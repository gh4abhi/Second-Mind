using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{

   public void playGame(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
