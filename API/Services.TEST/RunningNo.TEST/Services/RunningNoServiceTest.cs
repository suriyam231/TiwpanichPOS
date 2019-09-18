using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RunningNo.API.DTOs;
using RunningNo.API.Interfaces;
using RunningNo.API.Models;
using RunningNo.API.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunningNo.TEST.Services
{
    [TestClass]
    public class RunningNoServiceTest
    {
        private ISRMContext Context;
        private Mock<IRunningTypeService> RunningTypeService;

        public RunningNoServiceTest()
        {
            var Option = new DbContextOptionsBuilder<SRM_DEVContext>().UseInMemoryDatabase(databaseName: "MyDb").Options;
            Context = new SRM_DEVContext(Option);
            RunningTypeService = new Mock<IRunningTypeService>(MockBehavior.Strict);

        }

        public void Mockdata()
        {
            RunningType Type = new RunningType()
            {
                Code = "01",
                Name = "Username",
                RunningNoFormat = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}[RUNNING]",
                RunningNoDigit = 8,
                Active = true,
                CreatedBy = "System",
                CreatedDate = DateTime.Parse("5/1/2008 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture)
            };
            RunningTypeService.Setup(r => r.GetRunningType(It.IsAny<string>())).Returns(Type);
        }
        [TestMethod]
        public void TestHaveRunningType()
        {
            Mockdata();
            RunningNoService RunningNo = new RunningNoService(Context, RunningTypeService.Object);
            ReturnMessageDTO result = RunningNo.GenerateRunningNo("01", "US");
            Assert.AreEqual("RunningNo Created Success!!", result.Message);
        }

        [TestMethod]
        public void TestDontHaveRunningType()
        {
            RunningTypeService.Setup(r => r.GetRunningType(It.IsAny<string>())).Returns(It.IsAny<RunningType>());
            RunningNoService RunningNo = new RunningNoService(Context, RunningTypeService.Object);
            ReturnMessageDTO result = RunningNo.GenerateRunningNo("02", "US");
            Assert.AreEqual("Not found running Tpye!!", result.Message);
        }

        [TestMethod]
        public void TestCreateRunningNo()
        {
            RunningTypeService.Setup(r => r.GetRunningType(It.IsAny<string>())).Returns(It.IsAny<RunningType>());
            RunningNoService RunningNo = new RunningNoService(Context, RunningTypeService.Object);
            SystemRunningNo result = RunningNo.CreateRunningNo(new RunningType() { Code = "01" }, "US");
            Assert.AreEqual("01", result.RunningTypeCode);
        }

        [TestMethod]
        public void TestCreateRunningNoCodeNotSame()
        {
            RunningTypeService.Setup(r => r.GetRunningType(It.IsAny<string>())).Returns(It.IsAny<RunningType>());
            RunningNoService RunningNo = new RunningNoService(Context, RunningTypeService.Object);
            SystemRunningNo result = RunningNo.CreateRunningNo(new RunningType() { Code = "02" }, "UAS");
            Assert.AreNotSame("01", result.RunningTypeCode);
        }
    }
}
