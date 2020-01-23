using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Target;
    public TextTag TextTag;
    public Vector2 offset;
    public Transform UIRoot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Trigger()
    {
        TextTag textTagInstance = Object.Instantiate(TextTag);
        textTagInstance.transform.SetParent(UIRoot);
        textTagInstance.StartAnimation(Target, offset, "YOHO~", Camera.main);
    }
}
