using UnityEngine;

public class HammerController : MonoBehaviour
{
    public static HammerController instance;
    public Animator animator;

    private void Awake() {
        instance = this;
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
