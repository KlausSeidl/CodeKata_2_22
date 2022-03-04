using FluentAssertions;
using NUnit.Framework;

[TestFixture]
public class FirstTest
{
    [Test]
    public void Add()
    {
        int a = 2;
        int b = 3;

        var result = Calculator.Add(a, b);

        result.Should().Be(5);
    }

    [Test]
    public void Sub()
    {
        int a = 2;
        int b = 3;

        var result = Calculator.Sub(a, b);

        result.Should().Be(-1);
    }
}