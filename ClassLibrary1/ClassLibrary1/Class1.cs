using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Class1
    {
        public void a()
        {
            var t = new Moq.Mock<IA>();
            t.Setup(o => o.Add("1", "2", "3"));
            t.Object.Add("1", "2", "3");
        }
    }
    public interface IA
    {
        int Add(string a, string b, string c);
    }
}
