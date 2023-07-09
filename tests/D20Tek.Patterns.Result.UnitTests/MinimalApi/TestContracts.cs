﻿//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Patterns.Result.UnitTests.MinimalApi;

[ExcludeFromCodeCoverage]
public record TestResponse(int Id, string Message);

[ExcludeFromCodeCoverage]
public record TestEntity(int Id, string Message, DateTime CreatedDate);
