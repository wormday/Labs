using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Moq.Mock<IAccess>();
            mock.Setup(o => o.Add(Moq.It.IsAny<string>(), Moq.It.IsAny<string>())).Returns(100);
            mock.Setup(o => o.Get(3)).Verifiable();
            mock.Setup(o => o.Get(7)).Verifiable();
            var b = new Biz(mock.Object);
            var rtn=b.AddNewUser("1", "2", "3");
            
            Assert.AreEqual(rtn, 100);
            mock.Verify();



        }

    }

    public class Biz
    {
        IAccess acc = null;

        public Biz(IAccess acc)
        {
            this.acc = acc;
        }

        public int AddNewUser(string a, string b, string c)
        {
            acc.Get(7);
            //acc.Get(3);
            return acc.Add(a, b + c);
        }
    }

    public interface IAccess
    {
         int Add(string a, string b);
         string Get(int id);
    }
}
