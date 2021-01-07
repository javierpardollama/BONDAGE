using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.Services.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;

namespace Bondage.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestGradeService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestGradeService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{GradeService}"/>
        /// </summary>
        private ILogger<GradeService> Logger;

        /// <summary>
        /// Instance of <see cref="GradeService"/>
        /// </summary>
        private GradeService GradeService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestGradeService"/>
        /// </summary>
        public TestGradeService()
        {
        }

        /// <summary>
        /// Sets Up
        /// </summary>
        [SetUp]
        public void Setup()
        {
            SetUpJwtSettings();

            SetUpConfiguration();

            SetUpOptions();

            SetUpServices();

            SetUpMapper();

            SetUpLogger();

            SetUpContext();

            GradeService = new GradeService(Context, Mapper, Logger);
        }

        /// <summary>
        /// Sets Up Logger
        /// </summary>
        private void SetUpLogger()
        {
            ILoggerFactory @loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
            });

            Logger = @loggerFactory.CreateLogger<GradeService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Grade.Add(new Grade { Name = "Grade " + Guid.NewGuid().ToString(), ImageUri = "Grades/Grade_1_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Grade.Add(new Grade { Name = "Grade " + Guid.NewGuid().ToString(), ImageUri = "Grades/Grade_2_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Grade.Add(new Grade { Name = "Grade " + Guid.NewGuid().ToString(), ImageUri = "Grades/Grade_3_500.png", LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Finds All Grade
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllGrade()
        {
            await GradeService.FindAllGrade();

            Assert.Pass();
        }        

        /// <summary>
        /// Finds Grade By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindGradeById()
        {
            await GradeService.FindGradeById(Context.Grade.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Removes Grade By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveGradeById()
        {
            await GradeService.RemoveGradeById(Context.Grade.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Updates Grade
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdateGrade()
        {
            UpdateGrade Grade = new UpdateGrade()
            {
                Id = Context.Grade.FirstOrDefault().Id,
                ImageUri = "URL/Grade_21_500px.png",
                Name = "Grade 21"
            };

            await GradeService.UpdateGrade(Grade);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Grade
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddGrade()
        {
            AddGrade @Grade = new AddGrade()
            {
                ImageUri = "URL/Grade_4_500px.png",
                Name = "Grade 4"
            };

            await GradeService.AddGrade(@Grade);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckName()
        {
            AddGrade @Grade = new AddGrade()
            {
                ImageUri = "URL/Grade_3_500px.png",
                Name = Context.Grade.FirstOrDefault().Name
            };
            Exception exception = Assert.ThrowsAsync<Exception>(async () => await GradeService.CheckName(@Grade));

            Assert.Pass();
        }
    }
}