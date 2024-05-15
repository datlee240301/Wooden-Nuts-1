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
        SceneManager.LoadScene("HomeScene");
    }
}
