using UnityEngine;

public class HoleScript : MonoBehaviour {
    Camera mainCamera;
    public GameObject screwPreFab;
    bool screwSpawned = false; // Biến để kiểm tra xem screwPrefab đã được sinh ra hay chưa

    void Start() {
        mainCamera = Camera.main;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (IsTouchingThisObject()) {
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
                if (hitCollider != null) {
                    if (hitCollider.CompareTag("Screw")) {
                        Debug.Log("Collision");
                    } else {
                        // Kiểm tra nếu chưa có screwPrefab được sinh ra
                        if (!screwSpawned) {
                            Instantiate(screwPreFab, transform.position, Quaternion.identity);
                            screwSpawned = true; // Đánh dấu là screwPrefab đã được sinh ra
                        }
                    }
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
}
