using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReviveController : MonoBehaviour
{
    public Text countdownText;
    public GameObject GoalsRewardPopupGO;


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
            countdownText.text = "" + (int)(elapsedTime % 60);

            elapsedTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (GameManager.IsPaused == false)
        {
            gameObject.SetActive(false);
        }
        else
        {
            BugsPool.bugsPool.DeactivateAllBugs();
            PlayerController.player.AddBJToTotal();

            if (PlayerController.player.level.checkAllGoals())
            {
                GoalsRewardPopupGO.SetActive(true);
            }
            else {
                UIController.uIController.LoadResult();
            }
           
        }
    }
}
