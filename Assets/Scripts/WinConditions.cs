using UnityEngine;

public class WinConditions : MonoBehaviour {
    public GameObject winBoard;

    // Update is called once per frame
    void Update() {
        GameObject[] woodObjects = GameObject.FindGameObjectsWithTag("Wood");
        if (woodObjects.Length == 0) {
            if (winBoard != null) {
                winBoard.SetActive(true);
            }
        }
    }
}
