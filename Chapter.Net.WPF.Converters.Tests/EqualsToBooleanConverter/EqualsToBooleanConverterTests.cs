﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class EqualsToBooleanConverterTests : ValueConverterTester<EqualsToBooleanConverter>
{
    [TestCase(1, 1, true, false, true)]
    [TestCase(1, 1, false, true, false)]
    [TestCase(1, 1, null, false, null)]
    [TestCase(1, 1.0, true, false, false)]
    [TestCase(1, 1.0, false, true, true)]
    [TestCase(1, 1.0, true, null, null)]
    [TestCase(1, 2, true, false, false)]
    [TestCase(1, 2, false, true, true)]
    [TestCase(1, 2, true, null, null)]
    [TestCase("First", "First", true, false, true)]
    [TestCase("First", "First", false, true, false)]
    [TestCase("First", "First", null, false, null)]
    [TestCase("First", "Second", true, false, false)]
    [TestCase("First", "Second", false, true, true)]
    [TestCase("First", "Second", true, null, null)]
    public void Convert_Called_Compares(object first, object second, bool? isEqual, bool? isNotEqual, bool? expectation)
    {
        _target.IsEqual = isEqual;
        _target.IsNotEqual = isNotEqual;
        _target.CompareWith = second;

        Convert(first, expectation);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}