using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneButtonManager : MonoBehaviour {
    public static PlaySceneButtonManager instance;
    public GameObject hammer, hammerIcon;
    public GameObject unscrewIcon, undoIcon;
    public GameObject itemNoticePanel, screwNoticeText, woodNoticeText;
    public GameObject unscrewAmountTextIcon, undoAmountTextIcon, hammerAmoutTextIcon;
    public TextMeshProUGUI unscrewAmountText, undoAmountText, hammerAmoutText;
    public int unscrewAmount, undoAmount, hammerAmount;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        unscrewAmount = PlayerPrefs.GetInt(StringsManager.UnscrewAmount, 3);
        undoAmount = PlayerPrefs.GetInt(StringsManager.UndoAmount, 3);
        hammerAmount = PlayerPrefs.GetInt(StringsManager.HammerAmount, 3);
    }

    private void Update() {
        if (unscrewAmountTextIcon.activeSelf) {
            if (unscrewAmount < 0) unscrewAmount = 0;
            unscrewAmount = PlayerPrefs.GetInt(StringsManager.UnscrewAmount);
            unscrewAmountText.text = unscrewAmount.ToString();
        } else if (undoAmountTextIcon.activeSelf) {
            if (undoAmount < 0) undoAmount = 0;
            undoAmount = PlayerPrefs.GetInt(StringsManager.UndoAmount);
            undoAmountText.text = undoAmount.ToString();
        } else if (hammerAmoutTextIcon.activeSelf) {
            if (hammerAmount < 0) hammerAmount = 0;
            hammerAmount = PlayerPrefs.GetInt(StringsManager.HammerAmount);
            hammerAmoutText.text = hammerAmount.ToString();
        }
    }

    public void ActiveHammer() {
        if (hammerIcon.activeSelf && hammerAmount >0) {
            PlayerPrefs.SetInt(StringsManager.HammerAmount, hammerAmount-=1);
            ItemManager.instance.SetCanDestroyWood(true);
            hammer.SetActive(true);
            itemNoticePanel.SetActive(true);
            woodNoticeText.SetActive(true);
            ItemManager.instance.SetCanDestroyScrew(false);
        } else if (unscrewIcon.activeSelf && unscrewAmount >0) {
            PlayerPrefs.SetInt(StringsManager.UnscrewAmount, unscrewAmount -= 1);
            ItemManager.instance.SetCanDestroyWood(false);
            ItemManager.instance.SetCanDestroyScrew(true);
            itemNoticePanel.SetActive(true);
            screwNoticeText.SetActive(true);
        } else if (undoIcon.activeSelf && undoAmount > 0) {
            BarrierManager.Instance.RestoreHiddenWood();
            PlayerPrefs.SetInt(StringsManager.UndoAmount, undoAmount -= 1);
            ItemManager.instance.SetCanDestroyWood(false);
            ItemManager.instance.SetCanDestroyScrew(false);
            ScrewManager.instance.MoveToOldHole();
            //BarrierManager.Instance.ResetLastMovedWoodPosition();
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

    public void PopSound() {
        PlaySoundManager.instance.audioSource.PlayOneShot(PlaySoundManager.instance.popSound);
    }

    public void BuyItem() {
        if (unscrewIcon.activeSelf) {
            unscrewAmount++;
            PlayerPrefs.SetInt(StringsManager.UnscrewAmount, unscrewAmount);
        } else if(undoIcon.activeSelf) {
            undoAmount++;
            PlayerPrefs.SetInt(StringsManager.UndoAmount, undoAmount);
        } else if(hammerIcon.activeSelf) {
            hammerAmount++;
            PlayerPrefs.SetInt(StringsManager.HammerAmount, hammerAmount);
        }
    }
}
