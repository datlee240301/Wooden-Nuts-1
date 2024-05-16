using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneButtonManager : MonoBehaviour
{
    public static PlaySceneButtonManager instance;
    public GameObject hammer, hammerIcon;
    public GameObject unscrewIcon;
    public GameObject itemNoticePanel, screwNoticeText, woodNoticeText;

    private void Awake() {
        instance = this;
    }

    public void ActiveHammer() {
        if(hammerIcon.activeSelf) {
            hammer.SetActive(true);
            itemNoticePanel.SetActive(true);
            woodNoticeText.SetActive(true);
            PlayerPrefs.SetInt(AnimationStrings.CanDestroyWood, 1);
        }
        else if(unscrewIcon.activeSelf) {
            ItemManager.instance.EnableDestroyScrew();
            itemNoticePanel.SetActive(true);
            screwNoticeText.SetActive(true);
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
        LevelDisplay.Instance.UpdateLevel();
        SceneManager.LoadScene("HomeScene");
    }

    public void LoadNextLEvel() {
        LevelDisplay.Instance.UpdateLevel();
        SceneManager.LoadScene("PlayScene");
    }
    
    public void LoadCurrentScene() {
        SceneManager.LoadScene("PlayScene");
    }
    
    public void LoadHomeSceneAfterLosing() {
        SceneManager.LoadScene("HomeScene");
    }
}
