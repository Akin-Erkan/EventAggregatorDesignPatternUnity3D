using System;
using UnityEngine;

public abstract class AbstractEventAggregator : MonoBehaviour
{
    public abstract bool HandlerExistsFor(Type messageType);
    public abstract void Subscribe(object subscriber);
    public abstract void Publish(object message);
}