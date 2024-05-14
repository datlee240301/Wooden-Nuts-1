using System.Collections;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public static ItemManager instance;
    Animator animator;
    private bool canDestroyScrew;
    private bool canDestroyWood;

    private void Awake() {
        instance = this;
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (canDestroyScrew) {
            DestroyScrew();
        }
        //if (canDestroyWood) {
        //    DestroyWood();
        //}
        StartCoroutine(DestroyWood());
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
    public IEnumerator DestroyWood() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Collider2D[] colliders = Physics2D.OverlapPointAll(touchPosition);
                    foreach (Collider2D collider in colliders) {
                        if (collider.CompareTag("Wood")) {
                            animator.SetTrigger("isBreak");
                            transform.position = collider.gameObject.transform.position;
                            yield return new WaitForSeconds(1.0f);
                            Destroy(collider.gameObject);
                            StartCoroutine(ShakeCamera(0.15f, 0.2f));
                            yield return new WaitForSeconds(.5f);
                            gameObject.SetActive(false);
                            canDestroyWood = false;
                            StartCoroutine(ShakeCamera(0.15f, 0.2f)); 
                        }
                    }
                }
            }
        }
    }

    public void EnableDestroyWood() {
        canDestroyWood = true;
    }

    /// <summary>
    /// Shake camera
    /// </summary>
    IEnumerator ShakeCamera(float duration, float magnitude) {
        Vector3 originalPosition = Camera.main.transform.position;
        float elapsed = 0.0f;
        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            Camera.main.transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = originalPosition;
    }
}
