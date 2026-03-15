using System;
using Loans.Domain.Applications;
using NUnit.Framework;
using Moq;
using Moq.Protected;
namespace Loans.Tests
{
    public class LoanApplicationProcessorShould
    {
        [Test]
        public void DeclineLowSalary()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42,
                                                  product,
                                                  amount,
                                                  "Sarah",
                                                  25,
                                                  "133 Pluralsight Drive, Draper, Utah",
                                                  64_999);

            
            var mockIdentityVerifier=new Mock<IIdentityVerifier>();
            var creditscorer=new Mock<ICreditScorer>();
            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, creditscorer.Object);

            sut.Process(application);

            Assert.That(application.GetIsAccepted(), Is.False);
        }
        delegate void ValidateCallback(string applicantName,int applicantAge,string applicantAddress
            ,ref IdentityVerificationStatus status);
        [Test]
        public void Accept()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42,
                                                  product,
                                                  amount,
                                                  "Sarah",
                                                  25,
                                                  "133 Pluralsight Drive, Draper, Utah",
                                                  65_000);


            var mockIdentityVerifier = new Mock<IIdentityVerifier>(MockBehavior.Strict);
            mockIdentityVerifier.Setup(x => x.Initialize());
            //mockIdentityVerifier.Setup(x => x.Validate(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()))
            //    .Returns(true);
            mockIdentityVerifier.Setup(x => x.Validate("Sarah", 25, "133 Pluralsight Drive, Draper, Utah"))
                .Returns(true);
            //bool isValidOutValue = true;
            //mockIdentityVerifier.Setup(x => x.Validate("Sarah", 25, "133 Pluralsight Drive, Draper, Utah"
            //    , out isValidOutValue));
            //mockIdentityVerifier.Setup(x=>x.Validate("Sarah", 25, "133 Pluralsight Drive, Draper, Utah"
            //    , ref It.Ref<IdentityVerificationStatus>.IsAny))
            //    .Callback(new ValidateCallback((
            //      string ApplicantName,
            //        int applicantAge,
            //        string applicantAddress,ref IdentityVerificationStatus status)
            //    =>status=new IdentityVerificationStatus(true)));

            var mockcreditscorer = new Mock<ICreditScorer>();
            
            mockcreditscorer.SetupAllProperties();
                 mockcreditscorer.Setup(x => x.ScoreResult.ScoreValue.Score).Returns(300);
          //  mockcreditscorer.SetupProperty(x => x.Count);

            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockcreditscorer.Object);

            sut.Process(application);
            mockcreditscorer.VerifyGet(x => x.ScoreResult.ScoreValue.Score,Times.Once);
            mockcreditscorer.VerifySet(x => x.Count=1);

            Assert.That(application.GetIsAccepted(), Is.True);
            Assert.That(mockcreditscorer.Object.Count, Is.EqualTo(1));
        }
        [Test]
        public void DeclineWhenCreditScoreError()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42,
                                                  product,
                                                  amount,
                                                  "Sarah",
                                                  25,
                                                  "133 Pluralsight Drive, Draper, Utah",
                                                  65_000);


            var mockIdentityVerifier = new Mock<IIdentityVerifier>();
            
             mockIdentityVerifier.Setup(x => x.Validate("Sarah", 25, "133 Pluralsight Drive, Draper, Utah"))
                .Returns(true);
           

            var mockcreditscorer = new Mock<ICreditScorer>();
            mockcreditscorer.Setup(x => x.ScoreResult.ScoreValue.Score).Returns(300);
            mockcreditscorer.Setup(x => x.CalculateScore(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<InvalidOperationException>();

            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockcreditscorer.Object);

            sut.Process(application);
            Assert.That(application.GetIsAccepted(),Is.False);
        }
        [Test]
        public void DeclineWhenCreditScore()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42,
                                                  product,
                                                  amount,
                                                  "Sarah",
                                                  25,
                                                  "133 Pluralsight Drive, Draper, Utah",
                                                  65_000);


            var mockIdentityVerifier = new Mock<IIdentityVerifier>();

            mockIdentityVerifier.Setup(x => x.Validate("Sarah", 25, "133 Pluralsight Drive, Draper, Utah"))
               .Returns(true);


            var mockcreditscorer = new Mock<ICreditScorer>();
            mockcreditscorer.Setup(x => x.ScoreResult.ScoreValue.Score).Returns(300);
            mockcreditscorer.Setup(x => x.CalculateScore(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<InvalidOperationException>();

            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockcreditscorer.Object);

            sut.Process(application);
            Assert.That(application.GetIsAccepted(), Is.False);
        }
        interface IIdentityVerifierServiceGateWayProtectedMembers
        {
            DateTime GetCurrentTime();
            bool CallService(string applicantName, int applicantAge, string applicantAddress);
        }
       
        [Test]
        public void AcceptUsingpartialMock()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42,
                                                  product,
                                                  amount,
                                                  "Sarah",
                                                  25,
                                                  "133 Pluralsight Drive, Draper, Utah",
                                                  65_000);


            var mockIdentityVerifier = new Mock<IdentityVerifierServiceGateway>();

            //mockIdentityVerifier.Protected().Setup<bool>("CallService","Sarah",25, "133 Pluralsight Drive,
            //Draper, Utah")
            //   .Returns(true);
            mockIdentityVerifier.Protected().As<IIdentityVerifierServiceGateWayProtectedMembers>()
                .Setup(x=>x.CallService(It.IsAny<string>(),It.IsAny<int>(), It.IsAny<string>())).Returns(true);
            var expectedtime = new DateTime(2024, 12, 24);
            //mockIdentityVerifier.Protected().Setup<DateTime>("GetCurrentTime").Returns(expectedtime);
            mockIdentityVerifier.Protected().As<IIdentityVerifierServiceGateWayProtectedMembers>()
               .Setup(x => x.GetCurrentTime()).Returns(expectedtime);

            var mockcreditscorer = new Mock<ICreditScorer>();
            mockcreditscorer.Setup(x => x.ScoreResult.ScoreValue.Score).Returns(300);
            

            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockcreditscorer.Object);

            sut.Process(application);
            Assert.That(application.GetIsAccepted(), Is.True);
            Assert.That(mockIdentityVerifier.Object.LastCheckTime, Is.EqualTo(expectedtime));
        }
        [Test]
        public void NullReturnExample()
        {
            var mock=new Mock<INullExample>();
            mock.Setup(x => x.SomeMethod()).Returns<string>(null);
            
            string mockreturnValue=mock.Object.SomeMethod();
            Assert.That(mockreturnValue, Is.Null);
        }
        [Test]
        public void CalculateScore()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42,
                                                  product,
                                                  amount,
                                                  "Sarah",
                                                  25,
                                                  "133 Pluralsight Drive, Draper, Utah",
                                                  65_000);


            var mockIdentityVerifier = new Mock<IIdentityVerifier>();
            var mockcreditscorer = new Mock<ICreditScorer>();
            mockIdentityVerifier.Setup(x => x.Validate("Sarah", 25, "133 Pluralsight Drive, Draper, Utah"))
                .Returns(true);

            mockcreditscorer.SetupAllProperties();
            mockcreditscorer.Setup(x => x.ScoreResult.ScoreValue.Score).Returns(300);
            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockcreditscorer.Object);

            sut.Process(application);


            mockcreditscorer.Verify(x => x.CalculateScore("Sarah", 
                "133 Pluralsight Drive, Draper, Utah"),Times.Once);
        }
        [Test]
        public void InitalizeIdentityVerifier()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42,
                                                  product,
                                                  amount,
                                                  "Sarah",
                                                  25,
                                                  "133 Pluralsight Drive, Draper, Utah",
                                                  65_000);


            var mockIdentityVerifier = new Mock<IIdentityVerifier>();
            var mockcreditscorer = new Mock<ICreditScorer>();
            mockIdentityVerifier.Setup(x => x.Validate("Sarah", 25, "133 Pluralsight Drive, Draper, Utah"))
                .Returns(true);

            mockcreditscorer.SetupAllProperties();
            mockcreditscorer.Setup(x => x.ScoreResult.ScoreValue.Score).Returns(300);
            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockcreditscorer.Object);

            sut.Process(application);


            mockIdentityVerifier.Verify(x => x.Initialize());
            mockIdentityVerifier.Verify(x=>x.Validate(It.IsAny<string>(),It.IsAny<int>(),It.IsAny<string>()));
            mockIdentityVerifier.VerifyNoOtherCalls();
        }
    }
    public interface INullExample
    {
        string SomeMethod();
    }


}
