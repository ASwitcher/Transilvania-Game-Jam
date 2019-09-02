using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator transitionAnim;
    public GameObject Dracula_Boss;
    public GameObject Panel;
    public GameObject Usturoi;

    private int levelToLoad;

    public void StartTheGame()
    {
        Panel.SetActive(true);
        Dracula_Boss.SetActive(false);
        Usturoi.SetActive(false);
        transitionAnim.SetTrigger("Fade");
    }
    
    public void NIMIC(int level)
    {
        levelToLoad = level;
        //transitionAnim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);

    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Title");
            
        }
    }
}
