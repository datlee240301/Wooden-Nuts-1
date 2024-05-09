using UnityEngine;

public class ScrewManager : MonoBehaviour {
    Animator animator;
    static GameObject currentOutScrew = null;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    if (GetComponent<Collider2D>().OverlapPoint(touchPosition)) {
                        // Kiểm tra nếu có screw nào khác đang go out, thì set trigger isGoIn cho chúng
                        if (currentOutScrew != null && currentOutScrew != gameObject) {
                            currentOutScrew.GetComponent<Animator>().SetTrigger("isGoIn");
                        }

                        // Nếu screw hiện tại chưa go out thì set trigger isGoOut cho nó
                        if (currentOutScrew != gameObject) {
                            animator.SetTrigger("isGoOut");
                            currentOutScrew = gameObject;
                        }
                    }
                }
            }
        }
    }
}
