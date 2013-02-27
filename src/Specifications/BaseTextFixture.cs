using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;

namespace Specifications
{
    /// <summary>
    /// BaseTestFixture is used to create BDD style specifications.
    /// Based on source code in http://cre8ivethought.com/blog/2009/12/22/specifications
    /// </summary>
    [Specification]
    public abstract class BaseTestFixture
    {
        protected Exception CaughtException;
        protected virtual void Given() { }
        protected abstract void When();
        protected virtual void Finally() { }

        [Given]
        public void Setup()
        {
            CaughtException = new ThereWasNoExceptionButOneWasExpectedException();
            Given();

            try
            {
                When();
            }
            catch (Exception exception)
            {
                CaughtException = exception;
            }
            finally
            {
                Finally();
            }
        }
    }

    [Specification]
    public abstract class BaseTestFixture<TSubjectUnderTest>
    {
        private Dictionary<Type, object> mocks;

        protected Dictionary<Type, object> DoNotMock;
        protected TSubjectUnderTest SubjectUnderTest;
        protected Exception CaughtException;
        protected virtual void SetupDependencies() { }
        protected virtual void Given() { }
        protected abstract void When();
        protected virtual void Finally() { }

        [Given]
        public void Setup()
        {
            mocks = new Dictionary<Type, object>();
            DoNotMock = DoNotMock ?? new Dictionary<Type, object>();
            CaughtException = new ThereWasNoExceptionButOneWasExpectedException();

            BuildMocks();
            SetupDependencies();
            SubjectUnderTest = BuildSubjectUnderTest();

            Given();

            try
            {
                When();
            }
            catch (Exception exception)
            {
                CaughtException = exception;
            }
            finally
            {
                Finally();
            }
        }

        public Fake<TType> OnDependency<TType>() where TType : class
        {
            return ((Fake<TType>)mocks[typeof(TType)]);
        }

        private TSubjectUnderTest BuildSubjectUnderTest()
        {
            var constructorInfo = typeof(TSubjectUnderTest).GetConstructors().First();

            var parameters = new List<object>();
            foreach (var mock in mocks)
            {
                object theObject;
                if (!DoNotMock.TryGetValue(mock.Key, out theObject))
                {
                    theObject = mock.Value;
                    parameters.Add(theObject.GetType().GetProperty("FakedObject").GetValue(theObject, null));
                }
                else
                {
                    parameters.Add(theObject);
                }

                
            }

            return (TSubjectUnderTest)constructorInfo.Invoke(parameters.ToArray());
        }

        private void BuildMocks()
        {
            var constructorInfo = typeof(TSubjectUnderTest).GetConstructors().First();

            foreach (var parameter in constructorInfo.GetParameters())
            {
                mocks.Add(parameter.ParameterType, CreateMock(parameter.ParameterType));
            }
        }

        private static object CreateMock(Type type)
        {
            var constructorInfo = typeof(Fake<>).MakeGenericType(type).GetConstructors().First();
            return constructorInfo.Invoke(new object[] { });
        }
    }

    public class GivenAttribute : SetUpAttribute { }

    public class ThenAttribute : TestAttribute { }

    public class SpecificationAttribute : TestFixtureAttribute { }

    public class ThereWasNoExceptionButOneWasExpectedException : Exception
    {
    }
}
