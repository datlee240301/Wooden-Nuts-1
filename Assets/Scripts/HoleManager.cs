using UnityEngine;

public class HoleManager : MonoBehaviour {
    Camera mainCamera;
    public GameObject screwPreFab;
    bool hasScrewInside = false; // Biến kiểm tra xem đã có "Screw" trong HoleManager hay chưa

    void Start() {
        mainCamera = Camera.main;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (IsTouchingThisObject()) {
                if (!hasScrewInside) {
                    Instantiate(screwPreFab, transform.position, Quaternion.identity);
                    hasScrewInside = true; // Đặt biến này thành true khi sinh ra "Screw" mới
                }
            }
        }
    }

    bool IsTouchingThisObject() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject) {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Screw")) {
            hasScrewInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Screw")) {
            hasScrewInside = false;
        }
    }
}
