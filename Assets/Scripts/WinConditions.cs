using System.Collections;
using UnityEngine;

public class WinConditions : MonoBehaviour {
    public static WinConditions Instance;
    public GameObject winBoard;

    private void Awake() {
        Instance = this;
    }

    void Update() {
        GameObject[] woodObjects = GameObject.FindGameObjectsWithTag("Wood");
        if (woodObjects.Length == 0) {
            if (winBoard != null) {
                TimeManager.instance.StopTimer();
                StartCoroutine(ShowWinBoard());
            }
        }
    }

    IEnumerator ShowWinBoard() {
        LevelDisplay.Instance.UpdateLevel();
        yield return new WaitForSeconds(1f);
        winBoard.SetActive(true);
    }
}
