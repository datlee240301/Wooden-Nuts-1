using UnityEngine;

public class PlaySceneButtonManager : MonoBehaviour
{
    public GameObject hammer, hammerIcon;
    public GameObject unscrewIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveHammer() {
        if(hammerIcon.activeSelf) {
            hammer.SetActive(true);
        }
        else if(unscrewIcon.activeSelf) {
            ItemManager.instance.EnableDestroyScrew();
        }
    }
}
