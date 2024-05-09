using UnityEngine;

public class ScrewManager : MonoBehaviour {
    Animator animator;
    public static GameObject currentOutScrew = null;
    bool isTouchingOutScrew = false;
    int touchCount = 0;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    if (GetComponent<Collider2D>().OverlapPoint(touchPosition)) {
                        touchCount++;
                        if (touchCount == 1) {
                            animator.SetTrigger("isGoOut");
                            isTouchingOutScrew = true;
                            currentOutScrew = gameObject;
                        } else if (touchCount == 2) {
                            animator.SetTrigger("isGoIn");
                            isTouchingOutScrew = false;
                            currentOutScrew = null;
                            touchCount = 0;
                        }
                    }
                }
            }
        }
    }
}
