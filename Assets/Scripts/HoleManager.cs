﻿using UnityEngine;

public class HoleManager : MonoBehaviour {
    public static HoleManager instance;
    Camera mainCamera;
    public GameObject screwPreFab;
    public bool hasScrewInside = false;
    public bool isSpawn = false;

    private void Awake() {
        instance = this;
    }

    void Start() {
        mainCamera = Camera.main;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (IsTouchingThisObject()) {
                if (ScrewManager.currentOutScrew != null) {
                    if (ScrewManager.currentOutScrew != null) {
                        Destroy(ScrewManager.currentOutScrew);
                        ScrewManager.currentOutScrew = null;
                    }
                    Instantiate(screwPreFab, transform.position, Quaternion.identity);
                    hasScrewInside = true;
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
