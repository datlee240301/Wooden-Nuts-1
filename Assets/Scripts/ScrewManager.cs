using UnityEngine;

public class ScrewManager : MonoBehaviour {
    public Animator animator;
    private static ScrewManager currentOutScrew = null; 

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
                        if (collider.gameObject == gameObject) {
                            if (currentOutScrew != this) {
                                if (currentOutScrew != null) {
                                    currentOutScrew.animator.SetTrigger("isGoIn");
                                }
                                currentOutScrew = this;
                                animator.SetTrigger("isGoOut");
                            } else {
                                animator.SetTrigger("isGoIn");
                                currentOutScrew = null;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
