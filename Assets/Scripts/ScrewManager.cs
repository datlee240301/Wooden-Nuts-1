using UnityEngine;

public class ScrewManager : MonoBehaviour {
    public Animator animator;
    public static ScrewManager currentOutScrew = null;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Collider2D[] colliders = Physics2D.OverlapPointAll(touchPosition);

                    // Kiểm tra xem có va chạm với đối tượng có tag "UI" hay không
                    bool isTouchingUI = false;
                    foreach (Collider2D collider in colliders) {
                        if (collider.CompareTag("UI")) {
                            isTouchingUI = true;
                            break;
                        }
                    }

                    if (isTouchingUI) {
                        // Không cho phép tương tác với Screw nếu chạm vào UI
                        continue;
                    }

                    foreach (Collider2D collider in colliders) {
                        if (collider.gameObject == gameObject) {
                            if (currentOutScrew != this) {
                                if (currentOutScrew != null) {
                                    currentOutScrew.GoIn();
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

    public void GoIn() {
        animator.SetTrigger("isGoIn");
    }
}
