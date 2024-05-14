// Script HoleManager
using UnityEngine;

public class HoleManager : MonoBehaviour {
    public static HoleManager instance;

    private void Awake() {
        instance = this;
    }

    void Start() {
    }

    void Update() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Collider2D[] colliders = Physics2D.OverlapPointAll(touchPosition);
                    foreach (Collider2D collider in colliders) {
                        if (collider.gameObject == gameObject) {
                            Collider2D[] screws = Physics2D.OverlapPointAll(touchPosition);
                            bool hasScrewInside = false;
                            foreach (Collider2D screw in screws) {
                                if (screw.CompareTag("Screw")) {
                                    hasScrewInside = true;
                                    break;
                                }
                            }
                            if (!hasScrewInside) {
                                if (ScrewManager.currentOutScrew != null) {
                                    ScrewManager.currentOutScrew.transform.position = transform.position;
                                    ScrewManager.currentOutScrew.GoIn();
                                    ScrewManager.currentOutScrew = null;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
