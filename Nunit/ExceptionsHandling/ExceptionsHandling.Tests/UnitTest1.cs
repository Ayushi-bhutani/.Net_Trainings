using NUnit.Framework;
using ExceptionsHandling.Core;

namespace ExceptionsHandling.Tests;

[TestFixture]
public class ExceptionServiceTests
{
    private ExceptionService _service;

    [SetUp]
    public void Setup()
    {
        _service = new ExceptionService();
    }

    // ✅ SUCCESS CASE
    [Test]
    public void ProcessUserData_ValidInputs_ReturnsResult()
    {
        var result = _service.ProcessUserData("Ayush", 25, 50000, 5);
        Assert.That(result, Is.EqualTo(10000));
    }

    // ❌ ArgumentNullException
    [Test]
    public void ProcessUserData_UsernameNull_ThrowsArgumentNullException()
    {
        Assert.That(() =>
            _service.ProcessUserData(null, 25, 50000, 5),
            Throws.TypeOf<ArgumentNullException>());
    }

    // ❌ ArgumentOutOfRangeException
    [Test]
    public void ProcessUserData_InvalidAge_ThrowsArgumentOutOfRangeException()
    {
        Assert.That(() =>
            _service.ProcessUserData("Ayush", 15, 50000, 5),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // ❌ InvalidOperationException
    [Test]
    public void ProcessUserData_NegativeSalary_ThrowsInvalidOperationException()
    {
        Assert.That(() =>
            _service.ProcessUserData("Ayush", 25, -1000, 5),
            Throws.TypeOf<InvalidOperationException>());
    }

    // ❌ DivideByZeroException
    [Test]
    public void ProcessUserData_DivisorZero_ThrowsDivideByZeroException()
    {
        Assert.That(() =>
            _service.ProcessUserData("Ayush", 25, 50000, 0),
            Throws.TypeOf<DivideByZeroException>());
    }
}
