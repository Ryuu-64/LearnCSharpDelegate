using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace LearnCSharpDelegate;

internal static class DelegateAdd
{
    [Test]
    public static void SideEffectAddTest()
    {
        int res = 0;
        Action action1 = () => { };
        Action action2 = () => res++;
        action1 += action2;
        action2 += () => res++;
        action1.Invoke();
        AreEqual(1, res);
    }

    [Test]
    public static void SideEffectRemoveTest()
    {
        int res = 0;
        Action action1 = () => { };
        Action action2 = () => res++;
        action1 += action2;
        action1 += () => action1 -= action2;
        action1.Invoke();
        AreEqual(1, res);
    }

    [Test]
    public static void EqualsTest()
    {
        Action action1 = DummyMethod;
        Action action2 = DummyMethod;
        Action action3 = () => { };

        action1 += action3;
        action2 += action3;

        True(action1.Equals(action2));
        True(action2.Equals(action1));

        void DummyMethod()
        {
        }
    }

    [Test]
    public static void GetHashCodeTest()
    {
        Action action1 = DummyMethod;
        Action action2 = DummyMethod;
        Action action3 = () => { };

        action1 += action3;
        action2 += action3;

        int hashCode1 = action1.GetHashCode();
        int hashCode2 = action2.GetHashCode();

        AreEqual(hashCode1, hashCode2);

        void DummyMethod()
        {
        }
    }
}