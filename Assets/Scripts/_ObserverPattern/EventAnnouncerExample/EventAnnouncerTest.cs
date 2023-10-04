using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class EventAnnouncerTest : MonoBehaviour
{
    [SerializeField] private TestEvent onTestEvent; //ScriptableObject Link
    // Start is called before the first frame update
    void Start()
    {
        EventTypeTest example = new EventTypeTest()
        {
            name = "Griffin",
            id = 2000,
            value = 0.01f
        };
        
        onTestEvent.Raise(example);
    }
    
}
