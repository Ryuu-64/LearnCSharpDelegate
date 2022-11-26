using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace LearnCSharpDelegate
{
    internal static class DelegateAdd
    {
        private static int res = 0;

        private static void ResIncrease()
        {
            res++;
        }

        [SetUp]
        public static void SetUp()
        {
            res = 0;
        }

        [Test]
        public static void MulticastDelegateAddTest()
        {
            Action action1 = ResIncrease;
            Action action2 = () => { };
            action2 += action1;
            action1 += ResIncrease;
            action2.Invoke();
            AreEqual(1, res);
        }
    }
}