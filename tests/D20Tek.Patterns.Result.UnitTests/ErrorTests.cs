//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Patterns.Result.UnitTests.Validators;

namespace D20Tek.Patterns.Result.UnitTests
{
    [TestClass]
    public class ErrorTests
    {
        [TestMethod]
        public void Unexpected_ShouldCreate_UnexpectedErrorType()
        {
            PerformErrorTest("Test.Unexpected", "Unexpected test error.", ErrorType.Unexpected, Error.Unexpected);
        }

        [TestMethod]
        public void Failure_ShouldCreate_FailureErrorType()
        {
            PerformErrorTest("Test.Failure", "Failure error message.", ErrorType.Failure, Error.Failure);
        }

        [TestMethod]
        public void Validation_ShouldCreate_ValidationErrorType()
        {
            PerformErrorTest("Test.Validation", "Validation error message.", ErrorType.Validation, Error.Validation);
        }

        [TestMethod]
        public void NotFound_ShouldCreate_NotFoundErrorType()
        {
            PerformErrorTest("Test.NotFound", "Not found error message.", ErrorType.NotFound, Error.NotFound);
        }

        [TestMethod]
        public void Conflict_ShouldCreate_ConflictErrorType()
        {
            PerformErrorTest("Test.Conflict", "Conflict error message.", ErrorType.Conflict, Error.Conflict);
        }

        [TestMethod]
        public void Unauthorized_ShouldCreate_UnauthorizedErrorType()
        {
            PerformErrorTest("Test.Unauthorized", "Unauthorized error message.", ErrorType.Unauthorized, Error.Unauthorized);
        }

        [TestMethod]
        public void Forbidden_ShouldCreate_ForbiddenErrorType()
        {
            PerformErrorTest("Test.Forbidden", "Forbidden error message.", ErrorType.Forbidden, Error.Forbidden);
        }

        [TestMethod]
        public void Invalid_ShouldCreate_InvalidErrorType()
        {
            PerformErrorTest("Test.Invalid", "Invalid error message.", ErrorType.Invalid, Error.Invalid);
        }

        [TestMethod]
        public void Custom_ShouldCreate_CustomErrorType()
        {
            // arrange
            var code = "Test.Custom";
            var message = "Custom error message.";
            var errorType = 42;

            // act
            var error = Error.Custom(code, message, errorType);

            // assert
            error.ShouldBe(code, message, errorType);
        }

        private void PerformErrorTest(
            string code,
            string message,
            int errorType,
            Func<string, string, Error> operation)
        { 
            // arrange

            // act
            var error = operation(code, message);

            // assert
            error.ShouldBe(code, message, errorType);
        }
    }
}