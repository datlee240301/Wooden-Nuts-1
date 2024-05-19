using System.Collections;
using UnityEngine;

public class BarrierManager : MonoBehaviour {
    public static BarrierManager Instance;
    private GameObject hiddenWood;


    private void Awake() {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Wood")) {
            StartCoroutine(CounterWood(collision.gameObject));
        }
    }

    IEnumerator CounterWood(GameObject gameObject) {
        yield return new WaitForSeconds(.5f);
        hiddenWood = gameObject;
        gameObject.SetActive(false);
    }

    public void RestoreHiddenWood() {
        if (hiddenWood != null) {
            hiddenWood.SetActive(true);
            hiddenWood.GetComponent<WoodManager>().ResetPosition();
            hiddenWood = null;
        }
    }
}
