using UnityEngine;

public class ScrewManager : MonoBehaviour {
    public Animator animator;
    public static GameObject currentOutScrew = null;
    public bool isTouchingOutScrew = false;
    int touchCount = 0;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Collider2D[] colliders = Physics2D.OverlapPointAll(touchPosition);
                    foreach (Collider2D collider in colliders) {
                        if (collider.gameObject.tag == "Screw") {
                            ScrewManager screwManager = collider.gameObject.GetComponent<ScrewManager>();
                            if (screwManager != null && screwManager.animator != null) {
                                if (!screwManager.isTouchingOutScrew) {
                                    if (currentOutScrew != null && currentOutScrew != collider.gameObject) {
                                        ScrewManager otherScrewManager = currentOutScrew.GetComponent<ScrewManager>();
                                        if (otherScrewManager != null && otherScrewManager.animator != null) {
                                            otherScrewManager.animator.SetTrigger("isGoIn");
                                            otherScrewManager.isTouchingOutScrew = false;
                                        }
                                    }
                                    screwManager.animator.SetTrigger("isGoOut");
                                    screwManager.isTouchingOutScrew = true;
                                    currentOutScrew = collider.gameObject;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
