using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReviveController : MonoBehaviour
{
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(MoveOverSeconds());
    }

    public IEnumerator MoveOverSeconds()
    {
        float elapsedTime = 5;

        while (elapsedTime > 0)
        {
            countdownText.text = ""+(int)(elapsedTime % 60);

            elapsedTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (GameManager.IsPaused == false)
            gameObject.SetActive(false);
        else
        {
            GameManager.IsPaused = false;
            SceneManager.LoadScene(0);
        }
    }
}
