using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelexit : MonoBehaviour
{
    [SerializeField] float leveLoadDelay = 1f;
    [SerializeField] AudioClip levelSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }
    IEnumerator LoadNextLevel()
    {
        AudioSource.PlayClipAtPoint(levelSound,transform.position,0.7f); 
        yield return new WaitForSecondsRealtime(leveLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex+1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindAnyObjectByType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
        
    }
}
