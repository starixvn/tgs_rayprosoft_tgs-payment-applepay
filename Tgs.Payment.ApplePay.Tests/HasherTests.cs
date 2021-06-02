using NUnit.Framework;

namespace Tgs.Payment.ApplePay.Tests
{
    [TestFixture]
    public class HasherTests
    {
        [Test]
        public void Test_Check_Hash()
        {
            var store_guid = "TEST12345";
            var api_key = "AAA1234";
            var plainText = store_guid + api_key;

            ApplePayHasher applePayHasher = new ApplePayHasher();
            var excepted = "682a199a795d67dd0920457d2f03ef3c";

            var actual = applePayHasher.ComputeHash(plainText);

            Assert.AreEqual(excepted, actual);
        }
    }
}