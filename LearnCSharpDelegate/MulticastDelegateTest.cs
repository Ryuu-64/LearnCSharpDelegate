using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace LearnCSharpDelegate
{
    internal static class MulticastDelegateTest
    {
        private static int res;

        [SetUp]
        public static void SetUp()
        {
            res = 0;
        }

        [Test]
        public static void MulticastDelegateSideEffectTest()
        {
            Action action1 = ResIncrease;
            Action action2 = () => { };
            action2 += action1;
            action1 += ResIncrease; // no effect to action2
            action2.Invoke();
            AreEqual(1, res);
        }

        private static void ResIncrease()
        {
            res++;
        }
    }
}