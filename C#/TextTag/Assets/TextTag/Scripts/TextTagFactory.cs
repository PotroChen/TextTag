using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TextTagFactory : ScriptableObject
{
    [SerializeField]
    private TextTag[] prefabs;

    public void Init()
    {

    }

    public TextTag Get(int typeIndex)
    {
        TextTag textTagInstance = Object.Instantiate(prefabs[typeIndex]);
        textTagInstance.factory = this;
        return textTagInstance;
    }

    public void Reclaim(TextTag textTag)
    {
        Destroy(textTag.gameObject);
    }

    public void Dispose()
    {

    }
}
