using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneButtonManager : MonoBehaviour {
    public static PlaySceneButtonManager instance;
    public GameObject hammer, hammerIcon;
    public GameObject unscrewIcon, undoIcon;
    public GameObject itemNoticePanel, screwNoticeText, woodNoticeText;

    private void Awake() {
        instance = this;
    }

    public void ActiveHammer() {
        if (hammerIcon.activeSelf) {
            ItemManager.instance.SetCanDestroyWood(true);
            hammer.SetActive(true);
            itemNoticePanel.SetActive(true);
            woodNoticeText.SetActive(true);
            ItemManager.instance.SetCanDestroyScrew(false);
        } else if (unscrewIcon.activeSelf) {
            ItemManager.instance.SetCanDestroyWood(false);
            ItemManager.instance.SetCanDestroyScrew(true);
            itemNoticePanel.SetActive(true);
            screwNoticeText.SetActive(true);
        } else if (undoIcon.activeSelf) {
            ItemManager.instance.SetCanDestroyWood(false);
            ItemManager.instance.SetCanDestroyScrew(false);
            //ScrewManager.instance.UndoScrewMove();
        }
    }

    public IEnumerator CounteractItemNoticePanel() {
        yield return new WaitForSeconds(0.5f);
        itemNoticePanel.SetActive(false);
        screwNoticeText.SetActive(false);
    }

    public IEnumerator CounteractWoodNoticePanel() {
        yield return new WaitForSeconds(0.5f);
        itemNoticePanel.SetActive(false);
        woodNoticeText.SetActive(false);
    }

    public void LoadHomeScene() {
        //LevelDisplay.Instance.UpdateLevel();  
        SceneManager.LoadScene("HomeScene");
    }

    public void LoadNextLevel() {
        //LevelDisplay.Instance.UpdateLevel();
        SceneManager.LoadScene("PlayScene");
    }

    public void LoadCurrentScene() {
        SceneManager.LoadScene("PlayScene");
    }

    public void LoadHomeSceneAfterLosing() {
        SceneManager.LoadScene("HomeScene");
    }

    public void StopCountDown() {
        TimeManager.instance.StopTimer();
    }

    public void ContinueCountDown() {
        TimeManager.instance.RemainTimer();
    }
}
