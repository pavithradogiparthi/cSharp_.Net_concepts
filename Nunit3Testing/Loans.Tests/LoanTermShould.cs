

using System.Threading.Tasks;
using Loans.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests
{
    [TestFixture]
public  class LoanTermShould
    {
        [Test]
        //[Ignore("Need to complete update work")]
        public void ReturnTermInMonths()
        {
            //arrange
            var sut = new LoanTerm(1);
            //act
            var result=sut.ToMonths();
            //assert
            Assert.That(result, Is.EqualTo(12), "Months should be 12 *noof years"); ;
        }
        [Test]
        public void StoreYears()
        {
            var sut = new LoanTerm(1);
            Assert.That(sut.Years, Is.EqualTo(1));
        }
        [Test]
        public void RespectValueEquality()
        {
            var a = new LoanTerm(1);
            var b =new LoanTerm(1);
            Assert.That(a,Is.EqualTo(b));
        }
        [Test]
        public void ReturnvalueInequality()
        {
            var a = new LoanTerm(1);
            var b =new LoanTerm(2);
            Assert.That(a, Is.Not.EqualTo(b));
        }
        [Test]
        public void EqualityReferenceExample()
        {
            var a=new LoanTerm(1);
            var b = a;
            var c=new LoanTerm(2);
            Assert.That(a,Is.SameAs(b));
            Assert.That(a,Is.Not.SameAs(c));
            var x = new List<string> { "a", "b" };
           
            var y = x;
            var z = new List<string> { "a", "b"};
            Assert.That(y,Is.SameAs(x));
            Assert.That(z,Is.Not.SameAs(x));
        }
        [Test]
        public void Doublecheck()
        {
            double a = 1.0 / 3.0;
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));
            Assert.That(a,Is.EqualTo(a).Within(10).Percent);
        }
        [Test]
        public void NotAllowZeroYears()
        {

            Assert.That(() => new LoanTerm(0),
       Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("Message")
       .EqualTo("Please specify a value greater than 0. (Parameter 'years')"));
            Assert.That(()=>new LoanTerm(0),Throws.TypeOf<ArgumentOutOfRangeException>().With
                .Property("ParamName").EqualTo("years"));

            Assert.That(() => new LoanTerm(0),
       Throws.TypeOf<ArgumentOutOfRangeException>().With.
       Matches<ArgumentOutOfRangeException>(ex=>ex.ParamName=="years")
     );
        }
    
    }
}
