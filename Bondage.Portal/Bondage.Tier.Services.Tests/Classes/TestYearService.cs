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
    /// Represents a <see cref="TestYearService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestYearService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{YearService}"/>
        /// </summary>
        private ILogger<YearService> Logger;

        /// <summary>
        /// Instance of <see cref="YearService"/>
        /// </summary>
        private YearService YearService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestYearService"/>
        /// </summary>
        public TestYearService()
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

            YearService = new YearService(Context, Mapper, Logger);
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

            Logger = @loggerFactory.CreateLogger<YearService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Year.Add(new Year { Number = DateTime.Now.Year, LastModified = DateTime.Now, Deleted = false });
            Context.Year.Add(new Year { Number = DateTime.Now.Year + 1, LastModified = DateTime.Now, Deleted = false });
            Context.Year.Add(new Year { Number = DateTime.Now.Year + 2, LastModified = DateTime.Now, Deleted = false });

            Context.SaveChanges();
        }

        /// <summary>
        /// Tears Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Context.Year.RemoveRange(Context.Year.ToList());
            Context.SaveChanges();
        }

        /// <summary>
        /// Finds All Year
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllYear()
        {
            await YearService.FindAllYear();

            Assert.Pass();
        }

        /// <summary>
        /// Finds Year By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindYearById()
        {
            await YearService.FindYearById(Context.Year.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Removes Year By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveYearById()
        {
            await YearService.RemoveYearById(Context.Year.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Updates Year
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdateYear()
        {
            UpdateYear Year = new UpdateYear()
            {
                Id = Context.Year.FirstOrDefault().Id,
                Number = DateTime.Now.Year + 4,
            };

            await YearService.UpdateYear(Year);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Year
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddYear()
        {
            AddYear @Year = new AddYear()
            {
                Number = DateTime.Now.Year + 5,
            };

            await YearService.AddYear(@Year);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Number
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckNumber()
        {
            AddYear @Year = new AddYear()
            {
                Number = DateTime.Now.Year,
            };

            Exception exception = Assert.ThrowsAsync<Exception>(async () => await YearService.CheckNumber(@Year));

            Assert.Pass();
        }
    }
}