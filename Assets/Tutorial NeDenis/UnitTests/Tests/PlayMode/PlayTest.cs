using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Undertale;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayTest
{
    [UnityTest]
    public IEnumerator HeartMoveTest()
    {
        var direction = new Vector3(1, 0);
        var heart = new GameObject().AddComponent<Heart>();
        heart.Move(direction);
        var time = Time.deltaTime;
        yield return null;
        
        Assert.AreEqual(heart.Speed * time, heart.transform.position.x);
    }
}