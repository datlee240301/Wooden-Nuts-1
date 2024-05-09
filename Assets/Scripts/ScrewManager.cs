using UnityEngine;

public class ScrewManager : MonoBehaviour {
    Animator animator;
    static GameObject currentOutScrew = null;
    bool isTouchingOutScrew = false; // Biến kiểm tra xem có chạm vào screw đang go out hay không

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    if (GetComponent<Collider2D>().OverlapPoint(touchPosition)) {
                        // Kiểm tra nếu chạm vào screw đang go out
                        if (currentOutScrew == gameObject) {
                            // Gọi hàm SetTrigger để screw đó go in
                            animator.SetTrigger("isGoIn");
                            // Reset biến kiểm tra và lần chạm
                            isTouchingOutScrew = false;
                            currentOutScrew = null;
                        } else {
                            // Kiểm tra nếu có screw đang go out và không phải là screw hiện tại
                            if (currentOutScrew != null && currentOutScrew != gameObject) {
                                currentOutScrew.GetComponent<Animator>().SetTrigger("isGoIn");
                            }
                            if (currentOutScrew != gameObject) {
                                animator.SetTrigger("isGoOut");
                                currentOutScrew = gameObject;
                                // Đặt biến kiểm tra thành true khi chạm vào screw đang go out
                                isTouchingOutScrew = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
