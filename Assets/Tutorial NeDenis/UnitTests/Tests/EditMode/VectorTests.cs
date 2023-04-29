using System.Collections;
using System.Collections.Generic;
using MrAutofire;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class VectorTests
{
    [Test]
    public void Vector_1_0_Vector_1_0return()
    {
        Assert.AreEqual(new Vector2(0, 0).SetX(1), new Vector2(1, 0));
    }
}
