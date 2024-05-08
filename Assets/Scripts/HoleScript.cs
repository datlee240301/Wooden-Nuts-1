using UnityEngine;

public class HoleScript : MonoBehaviour {
    Camera mainCamera;

    // Start is called before the first frame update
    void Start() {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (IsTouchingThisObject()) {
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
                if (hitCollider != null) {
                    Debug.Log("Collision");
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
    public void Log() {
        Debug.Log("Collision");
    }
}
