using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class EventListenerTest : MonoBehaviour
{
    public void EventTest_Listener(EventTypeTest data)
    {
        Debug.Log(transform.name + "\n" + data.name + "\n" + data.id + "\n" + data.value);
    }
}
