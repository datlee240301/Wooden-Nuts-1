using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Wood")) {
            StartCoroutine(CounterWood(collision.gameObject));
        }
    }

    IEnumerator CounterWood(GameObject gameObject) {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}
