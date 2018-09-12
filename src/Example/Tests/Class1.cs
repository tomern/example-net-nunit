﻿using NUnit.Framework;
using ReportPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Tests
{
    [Parallelizable]
    [TestFixture]
    [Description("this is description for Class1")]
    public class Class1
    {
        protected log4net.ILog Log4NetLogger = log4net.LogManager.GetLogger(typeof(Class1));

        [Category("T1")]
        [Test]
        public void Test1()
        {
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Trace, "class1 test1 log message");
            Log4NetLogger.Info("My log message from Log4Net");
            var filePath = TestContext.CurrentContext.TestDirectory + "\\dog.png";

            // add attachment into results
            TestContext.AddTestAttachment(filePath, "my dog");

            // or send directly to ReportPortal
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Info, "my dog {rp#file#" + filePath + "}");

            
        }

        [Test]
        [Description("this is description for Test2")]
        public void Test2()
        {
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Trace, "class1 test2 log message");
        }

        [Test]
        [Description("Test should fail with timeout")]
        [Timeout(1000)]
        public void Test3()
        {
            System.Threading.Thread.Sleep(3000);
        }

        [Test, Retry(5)]
        [Description("Test should be retried")]
        public void Test4()
        {
            System.Threading.Thread.Sleep(3000);
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Trace, "class1 test4 log message");
            //throw new Exception("abc");
            Assert.IsTrue(false);
        }
    }
}
