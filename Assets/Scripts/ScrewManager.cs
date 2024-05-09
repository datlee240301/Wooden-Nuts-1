using UnityEngine;

public class ScrewManager : MonoBehaviour {
    Animator animator;
    static GameObject currentOutScrew = null;
    bool isTouchingOutScrew = false; 

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    if (GetComponent<Collider2D>().OverlapPoint(touchPosition)) {
                        if (currentOutScrew == gameObject) {
                            animator.SetTrigger("isGoIn");
                            
                            isTouchingOutScrew = false;
                            currentOutScrew = null;
                        } else {
                            if (currentOutScrew != null && currentOutScrew != gameObject) {
                                currentOutScrew.GetComponent<Animator>().SetTrigger("isGoIn");
                            }
                            if (currentOutScrew != gameObject) {
                                animator.SetTrigger("isGoOut");
                                currentOutScrew = gameObject;
                                isTouchingOutScrew = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
