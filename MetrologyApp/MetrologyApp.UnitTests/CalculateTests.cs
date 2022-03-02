using NUnit.Framework;
using MetrologyApp.Mathematics;
using MetrologyApp.Models;
using System;

namespace MetrologyApp.UnitTests
{
    public class CalculateTests
    {
        NominalPoint? _nominalPoint;
        ActualPoint? _actualPoint;
        double x;
        int i;

        [SetUp]
        public void Setup()
        {
            _nominalPoint = new NominalPoint();
            _actualPoint = new ActualPoint();

            _nominalPoint.Id = 1;
            _nominalPoint.X = 1;
            _nominalPoint.Y = 1;
            _nominalPoint.Z = 1;

            _actualPoint.Id = 2;
            _actualPoint.X = 2;
            _actualPoint.Y = 2;
            _actualPoint.Z = 2;

            x = 1;
            i = 1;
        }

        #region Deviation
        [Test]
        public void CalculateDeviationWith_NullParam_ReturnsFalse()
        {
            _actualPoint = null ;

            var result = Calculate.Deviation(_nominalPoint, _actualPoint);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void CalculateDeviationWith_EqualToZero_ReturnsFalse()
        {
            _nominalPoint.X = 0;

            var result = Calculate.Deviation(_nominalPoint, _actualPoint);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void CalculateDeviationWith_NegativeValue_ReturnsFalse()
        {
            _nominalPoint.X = -2;

            var result = Calculate.Deviation(_nominalPoint, _actualPoint);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void CalculateDeviationWith_PositiveValue_ReturnsTrue()
        {
            var result = Math.Round(Calculate.Deviation(_nominalPoint, _actualPoint),2);

            Assert.That(result, Is.EqualTo(1.73));
        }
        #endregion

        #region AveragePoint
        [Test]
        public void CalculateAveragePointWith_PointValEqualToZero_ReturnFalse()
        {
            x = 0;

            var result = Calculate.AveragePoint(x, i);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void CalculateAveragePointWith_PointValNegative_ReturnFalse()
        {
            x = -1;

            var result = Calculate.AveragePoint(x, i);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void CalculateAveragePointWith_DividedByZero_ReturnFalse()
        {
            x = 0;

            var result = Calculate.AveragePoint(x, i);

            Assert.That(result, Is.EqualTo(-1));
        }
        [Test]
        public void CalculateAveragePointWith_DividedByNegative_ReturnFalse()
        {
            x = 0;

            var result = Calculate.AveragePoint(x, i);

            Assert.That(result, Is.EqualTo(-1));
        }
        [Test]
        public void CalculateAveragePointWith_PointValPositive_ReturnTrue()
        {

            var result = Calculate.AveragePoint(x, i);

            Assert.That(result, Is.EqualTo(1));
        }
        #endregion
    }
}