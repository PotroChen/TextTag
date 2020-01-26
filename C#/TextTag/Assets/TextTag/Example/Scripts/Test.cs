using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public TextTagFactory textTagFactory;
    public GameObject Target;
    public int typeId;
    public Vector2 offset;
    public Transform UIRoot;

    void Awake()
    {
        textTagFactory.Init();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        textTagFactory.Dispose();
    }

    public void Trigger()
    {
        TextTag textTagInstance = textTagFactory.Get(typeId);
        textTagInstance.transform.SetParent(UIRoot);
        textTagInstance.StartAnimation(Target, offset, "YOHO~", Camera.main);
    }
}
