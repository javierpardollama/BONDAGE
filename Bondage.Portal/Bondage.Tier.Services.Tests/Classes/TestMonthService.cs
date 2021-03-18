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
    /// Represents a <see cref="TestMonthService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestMonthService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{MonthService}"/>
        /// </summary>
        private ILogger<MonthService> Logger;

        /// <summary>
        /// Instance of <see cref="MonthService"/>
        /// </summary>
        private MonthService MonthService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestMonthService"/>
        /// </summary>
        public TestMonthService()
        {
        }

        /// <summary>
        /// Sets Up
        /// </summary>
        [SetUp]
        public void Setup()
        {
            SetUpContextOptions();

            SetUpJwtOptions();

            SetUpServices();

            SetUpMapper();

            SetUpLogger();

            SetUpContext();

            MonthService = new MonthService(Context, Mapper, Logger);
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

            Logger = @loggerFactory.CreateLogger<MonthService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Month.Add(new Month { Name = "Month " + Guid.NewGuid().ToString(), Number = 1, LastModified = DateTime.Now, Deleted = false });
            Context.Month.Add(new Month { Name = "Month " + Guid.NewGuid().ToString(), Number = 2, LastModified = DateTime.Now, Deleted = false });
            Context.Month.Add(new Month { Name = "Month " + Guid.NewGuid().ToString(), Number = 3, LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.Month.RemoveRange(Context.Month.ToList());
            Context.SaveChanges();
        }

        /// <summary>
        /// Finds All Month
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllMonth()
        {
            await MonthService.FindAllMonth();

            Assert.Pass();
        }

        /// <summary>
        /// Finds Month By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindMonthById()
        {
            await MonthService.FindMonthById(Context.Month.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Removes Month By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveMonthById()
        {
            await MonthService.RemoveMonthById(Context.Month.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Updates Month
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdateMonth()
        {
            UpdateMonth Month = new UpdateMonth()
            {
                Id = Context.Month.FirstOrDefault().Id,
                Number = 21,
                Name = "Month 21"
            };

            await MonthService.UpdateMonth(Month);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Month
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddMonth()
        {
            AddMonth @Month = new AddMonth()
            {
                Number = 4,
                Name = "Month 4"
            };

            await MonthService.AddMonth(@Month);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckName()
        {
            AddMonth @Month = new AddMonth()
            {
                Number = 1,
                Name = Context.Month.FirstOrDefault().Name
            };

            Exception exception = Assert.ThrowsAsync<Exception>(async () => await MonthService.CheckName(@Month));

            Assert.Pass();
        }
    }
}