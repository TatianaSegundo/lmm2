using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
public Animator transition; 
public float transitionTime = 1f;
   // void Start()
    //{
      /* PARA FUTURO SONIDO
      Scene = sceneManager.GetActiveScene();
      if(scene.name == "MainMenu")
      {
        AudioManager.instance.backgroundMusic.Stop();
      } */
       // Time.timeScale = 1;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadNextLevel()
    {
      StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }
    IEnumerator LoadLevel(int levelIndex)
    {
      //Play animation
      transition.SetTrigger( "Start"); //Le pasamos el nombre de la animacion inicial

      //Wait
      yield return new WaitForSeconds(transitionTime);
      //Load scene
      SceneManager.LoadScene(levelIndex);
    }
}
