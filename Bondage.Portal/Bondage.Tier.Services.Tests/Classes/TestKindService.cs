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
    /// Represents a <see cref="TestKindService"/> class. Inherits <see cref="TestBaseService"/>
    /// </summary>
    [TestFixture]
    public class TestKindService : TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="ILogger{KindService}"/>
        /// </summary>
        private ILogger<KindService> Logger;

        /// <summary>
        /// Instance of <see cref="KindService"/>
        /// </summary>
        private KindService KindService;

        /// <summary>
        /// Initializes a new Instance of <see cref="TestKindService"/>
        /// </summary>
        public TestKindService()
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

            KindService = new KindService(Context, Mapper, Logger);
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

            Logger = @loggerFactory.CreateLogger<KindService>();
        }

        /// <summary>
        /// Sets Up Context
        /// </summary>
        private void SetUpContext()
        {
            Context.Kind.Add(new Kind { Name = "Kind " + Guid.NewGuid().ToString(), ImageUri = "Kinds/Kind_1_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Kind.Add(new Kind { Name = "Kind " + Guid.NewGuid().ToString(), ImageUri = "Kinds/Kind_2_500.png", LastModified = DateTime.Now, Deleted = false });
            Context.Kind.Add(new Kind { Name = "Kind " + Guid.NewGuid().ToString(), ImageUri = "Kinds/Kind_3_500.png", LastModified = DateTime.Now, Deleted = false });

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
        /// Finds All Kind
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindAllKind()
        {
            await KindService.FindAllKind();

            Assert.Pass();
        }

        /// <summary>
        /// Finds Kind By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task FindKindById()
        {
            await KindService.FindKindById(Context.Kind.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Removes Kind By Id
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task RemoveKindById()
        {
            await KindService.RemoveKindById(Context.Kind.FirstOrDefault().Id);

            Assert.Pass();
        }

        /// <summary>
        /// Updates Kind
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task UpdateKind()
        {
            UpdateKind Kind = new UpdateKind()
            {
                Id = Context.Kind.FirstOrDefault().Id,
                ImageUri = "URL/Kind_21_500px.png",
                Name = "Kind 21"
            };

            await KindService.UpdateKind(Kind);

            Assert.Pass();
        }

        /// <summary>
        /// Adds Kind
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public async Task AddKind()
        {
            AddKind @Kind = new AddKind()
            {
                ImageUri = "URL/Kind_4_500px.png",
                Name = "Kind 4"
            };

            await KindService.AddKind(@Kind);

            Assert.Pass();
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <returns>Instance of <see cref="Task"/></returns>
        [Test]
        public void CheckName()
        {
            AddKind @Kind = new AddKind()
            {
                ImageUri = "URL/Kind_3_500px.png",
                Name = Context.Kind.FirstOrDefault().Name
            };
            Exception exception = Assert.ThrowsAsync<Exception>(async () => await KindService.CheckName(@Kind));

            Assert.Pass();
        }
    }
}