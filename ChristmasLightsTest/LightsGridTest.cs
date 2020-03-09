using ChristmasLights;
using NUnit.Framework;
using System;

namespace ChristmasLightsTest
{
    public class Tests
    {
        LightsGrid grid;

        [SetUp]
        public void Setup()
        {
            grid = new LightsGrid(1000, 1000);
        }

        [Test]
        public void SantasInstructionsTest()
        {
            grid.TurnOn((0, 0), (999, 999));
            grid.Toggle((0, 0), (999, 0));
            grid.TurnOff((499, 499), (500, 500));
            Assert.AreEqual(1001996, grid.TotalBrightness);
        }

        [Test]
        public void StartFromBottomRight()
        {
            grid.TurnOn((999, 999), (0, 0));
            grid.Toggle((999, 0), (0, 0));
            grid.TurnOff((500, 500), (499, 499));
            Assert.AreEqual(1001996, grid.TotalBrightness);
        }

        [Test]
        public void TurnOn_IndexOutOfRangeTest()
        {
            Assert.Throws<IndexOutOfRangeException>(() => grid.TurnOn((1000, 0), (0, 0)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.TurnOn((0, 1000), (0, 0)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.TurnOn((0, 0), (1000, 0)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.TurnOn((0, 0), (0, 1000)));
        }

        [Test]
        public void TurnOff_IndexOutOfRangeTest()
        {
            Assert.Throws<IndexOutOfRangeException>(() => grid.TurnOff((1000, 0), (0, 0)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.TurnOff((0, 1000), (0, 0)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.TurnOff((0, 0), (1000, 0)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.TurnOff((0, 0), (0, 1000)));
        }

        [Test]
        public void Toggle_IndexOutOfRangeTest()
        {
            Assert.Throws<IndexOutOfRangeException>(() => grid.Toggle((1000, 0), (0, 0)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.Toggle((0, 1000), (0, 0)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.Toggle((0, 0), (1000, 0)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.Toggle((0, 0), (0, 1000)));
        }
    }
}