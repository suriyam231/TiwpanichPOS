using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RunningNo.API.Interfaces;
using RunningNo.API.Models;
using RunningNo.API.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunningNo.TEST.Services
{
    [TestClass]
    public class RunningTypeServiceTest
    {
        private ISRMContext Context;
        public RunningTypeServiceTest()
        {
            var Option = new DbContextOptionsBuilder<SRM_DEVContext>().UseInMemoryDatabase(databaseName: "MyDb").Options;
            Context = new SRM_DEVContext(Option);
            Mockdata();
        }
        public void Mockdata()
        {
            foreach (var entity in Context.RunningType)
                Context.RunningType.Remove(entity);
            Context.SaveChanges();
            Context.RunningType.Add(new RunningType()
            {
                Code = "01",
                Name = "Username",
                RunningNoFormat = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}[RUNNING]",
                RunningNoDigit = 8,
                Active = true,
                CreatedBy = "System",
                CreatedDate = DateTime.Parse("5/1/2008 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture)
            });
            Context.SaveChanges();
        }

        [TestMethod]
        public void TestHaveRunningType()
        {
            RunningTypeService runningType = new RunningTypeService(Context);
            RunningType result = runningType.GetRunningType("01");
            Assert.AreEqual("01", result.Code);
        }

        [TestMethod]
        public void TestDontHaveRunningType()
        {
            RunningTypeService runningType = new RunningTypeService(Context);
            RunningType result = runningType.GetRunningType("02");
            Assert.AreEqual(null, result);
        }
    }
}
