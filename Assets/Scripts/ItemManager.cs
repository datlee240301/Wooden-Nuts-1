using UnityEngine;

public class ItemManager : MonoBehaviour {
    public static ItemManager instance;
    private bool canDestroyScrew;
    private bool canDestroyWood;

    private void Awake() {
        instance = this;    
    }

    void Update() {
        if (canDestroyScrew) {
            DestroyScrew();
        }
        if (canDestroyWood) {
            DestroyWood();
        }
    }
    /// <summary>
    /// funtion of destroying screw
    /// </summary>
    void DestroyScrew() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Collider2D[] colliders = Physics2D.OverlapPointAll(touchPosition);
                    foreach (Collider2D collider in colliders) {
                        if (collider.CompareTag("Screw")) {
                            Destroy(collider.gameObject);
                            canDestroyScrew = false; 
                            return; 
                        }
                    }
                }
            }
        }
    }

    public void EnableDestroyScrew() {
        canDestroyScrew = true;
    }
    /// <summary>
    /// function of destroying wood
    /// </summary>
    void DestroyWood() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Collider2D[] colliders = Physics2D.OverlapPointAll(touchPosition);
                    foreach (Collider2D collider in colliders) {
                        if (collider.CompareTag("Wood")) {
                            Destroy(collider.gameObject);
                            canDestroyWood = false; 
                            return; 
                        }
                    }
                }
            }
        }
    }

    public void EnableDestroyWood() {
        canDestroyWood = true;
    }
}
