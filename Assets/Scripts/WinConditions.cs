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
                winBoard.SetActive(true);
                TimeManager.instance.StopTimer();
            }
        }
    }
}
