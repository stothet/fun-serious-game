using UnityEngine;
using UnityEditor;
using NUnit.Framework;

/// <summary>
/// Unit tests for Persistence manager.
/// </summary>
[TestFixture]
public class TestPersistence
{

    /// <summary>
    /// Setup persistence controller to run tests.
    /// </summary>
    [SetUp]
    public void establish()
    {
        PersistenceController.InstantiateInstance();
    }

    /// <summary>
    /// Tests that a persistence controller instance exists.
    /// </summary>
    [Test]
    public void testPersistenceInstanceExists()
    {
        Assert.NotNull(PersistenceController.instance);
    }

    /// <summary>
    /// Tests that a persistence controller can maintain and reset state
    /// </summary>
    [Test]
    public void testStoreAndRetrieve()
    {
        // Reset with instantiate instance
        PersistenceController.instance.inventoryState.currentLine = 3;
        Assert.AreEqual(3, PersistenceController.instance.inventoryState.currentLine);

        PersistenceController.ResetState();
        Assert.AreEqual(0, PersistenceController.instance.inventoryState.currentLine);
    }

}
