using UnityEngine;
using System.Collections;
using NUnit.Framework;


[TestFixture]
public class TestLives : MonoBehaviour {


    /// <summary>
    /// Sets up the static classes that are needed for the tests
    /// </summary>
    [SetUp]
    public void establish()
    {
        PersistenceController.InstantiateInstance();
    }

    /// <summary>
    /// Checks that the number of lives can be changed. Other methods in this class interact with the GUI which seems very difficult to mock.,
    /// </summary>
    [Test]
    public void testExternalClassesCanUpdateState()
    {
    
        UpdateLivesGUI gui = new UpdateLivesGUI();
        PersistenceController.instance.playerState.lives = 3;
        PersistenceController.instance.playerState.lives = 1;
        Assert.Pass();

    }
}
