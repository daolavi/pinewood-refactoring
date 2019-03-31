using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PinnacleSample.Controllers.PartInvoiceController;
using PinnacleSample.Entities;
using PinnacleSample.Infrastructure.IoC;
using PinnacleSample.Repositories.CustomerRepository;
using PinnacleSample.Repositories.PartInvoiceRepository;

namespace PinnacleSample.Tests
{
    [TestClass]
    public class PartInvoiceControllerTests
    {
        [TestMethod]
        public void PartInvoiceControllerTests_StockCodeEmpty()
        {
            var ioc = new Mock<IIoC>();

            var customerRepository = new Mock<ICustomerRepositoryDB>();
            ioc.Setup(c => c.Resolve<ICustomerRepositoryDB>()).Returns(customerRepository.Object);

            var partInvoiceRepository = new Mock<IPartInvoiceRepositoryDB>();
            ioc.Setup(c => c.Resolve<IPartInvoiceRepositoryDB>()).Returns(partInvoiceRepository.Object);

            var partAvailabilityService = new Mock<Services.PartAvailabilityService.IPartAvailabilityService>();
            ioc.Setup(c => c.Resolve<Services.PartAvailabilityService.IPartAvailabilityService>()).Returns(partAvailabilityService.Object);

            var partInvoiceController = new PartInvoiceController(ioc.Object);
            var stockCode = string.Empty;
            var quantity = 10;
            var customerName = "PineWood";
            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }

        [TestMethod]
        public void PartInvoiceControllerTests_QuantityNotMoreThan0()
        {
            var ioc = new Mock<IIoC>();

            var customerRepository = new Mock<ICustomerRepositoryDB>();
            ioc.Setup(c => c.Resolve<ICustomerRepositoryDB>()).Returns(customerRepository.Object);

            var partInvoiceRepository = new Mock<IPartInvoiceRepositoryDB>();
            ioc.Setup(c => c.Resolve<IPartInvoiceRepositoryDB>()).Returns(partInvoiceRepository.Object);

            var partAvailabilityService = new Mock<Services.PartAvailabilityService.IPartAvailabilityService>();
            ioc.Setup(c => c.Resolve<Services.PartAvailabilityService.IPartAvailabilityService>()).Returns(partAvailabilityService.Object);

            var partInvoiceController = new PartInvoiceController(ioc.Object);
            var stockCode = "PW";
            var quantity = 0;
            var customerName = "PineWood";
            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }

        [TestMethod]
        public void PartInvoiceControllerTests_CustomerNameNull()
        {
            var ioc = new Mock<IIoC>();

            var customerRepository = new Mock<ICustomerRepositoryDB>();
            ioc.Setup(c => c.Resolve<ICustomerRepositoryDB>()).Returns(customerRepository.Object);

            var partInvoiceRepository = new Mock<IPartInvoiceRepositoryDB>();
            ioc.Setup(c => c.Resolve<IPartInvoiceRepositoryDB>()).Returns(partInvoiceRepository.Object);

            var partAvailabilityService = new Mock<Services.PartAvailabilityService.IPartAvailabilityService>();
            ioc.Setup(c => c.Resolve<Services.PartAvailabilityService.IPartAvailabilityService>()).Returns(partAvailabilityService.Object);

            var partInvoiceController = new PartInvoiceController(ioc.Object);
            var stockCode = "PW";
            var quantity = 0;
            string customerName = null;
            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }

        [TestMethod]
        public void PartInvoiceControllerTests_CustomerNotFound()
        {
            var ioc = new Mock<IIoC>();

            var customerRepository = new Mock<ICustomerRepositoryDB>();
            Customer customer = null;
            customerRepository.Setup(r => r.GetByName(It.IsAny<string>())).Returns(customer);
            ioc.Setup(c => c.Resolve<ICustomerRepositoryDB>()).Returns(customerRepository.Object);

            var partInvoiceRepository = new Mock<IPartInvoiceRepositoryDB>();
            ioc.Setup(c => c.Resolve<IPartInvoiceRepositoryDB>()).Returns(partInvoiceRepository.Object);

            var partAvailabilityService = new Mock<Services.PartAvailabilityService.IPartAvailabilityService>();
            ioc.Setup(c => c.Resolve<Services.PartAvailabilityService.IPartAvailabilityService>()).Returns(partAvailabilityService.Object);

            var partInvoiceController = new PartInvoiceController(ioc.Object);
            var stockCode = "PW";
            var quantity = 1;
            var customerName = "PineWood";

            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }

        [TestMethod]
        public void PartInvoiceControllerTests_CustomerIdNotMoreThan0()
        {
            var ioc = new Mock<IIoC>();

            var customerRepository = new Mock<ICustomerRepositoryDB>();
            Customer customer = new Customer
            {
                ID = 0,
                Name = "PineWood",
                Address = "UK"
            };
            customerRepository.Setup(r => r.GetByName(It.IsAny<string>())).Returns(customer);
            ioc.Setup(c => c.Resolve<ICustomerRepositoryDB>()).Returns(customerRepository.Object);

            var partInvoiceRepository = new Mock<IPartInvoiceRepositoryDB>();
            ioc.Setup(c => c.Resolve<IPartInvoiceRepositoryDB>()).Returns(partInvoiceRepository.Object);

            var partAvailabilityService = new Mock<Services.PartAvailabilityService.IPartAvailabilityService>();
            ioc.Setup(c => c.Resolve<Services.PartAvailabilityService.IPartAvailabilityService>()).Returns(partAvailabilityService.Object);

            var partInvoiceController = new PartInvoiceController(ioc.Object);
            var stockCode = "PW";
            var quantity = 1;
            var customerName = "PineWood";

            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }

        [TestMethod]
        public void PartInvoiceControllerTests_AvailabilityNotMoreThan0()
        {
            var ioc = new Mock<IIoC>();

            var customerRepository = new Mock<ICustomerRepositoryDB>();
            Customer customer = new Customer
            {
                ID = 1,
                Name = "PineWood",
                Address = "UK"
            };
            customerRepository.Setup(r => r.GetByName(It.IsAny<string>())).Returns(customer);
            ioc.Setup(c => c.Resolve<ICustomerRepositoryDB>()).Returns(customerRepository.Object);

            var partInvoiceRepository = new Mock<IPartInvoiceRepositoryDB>();
            ioc.Setup(c => c.Resolve<IPartInvoiceRepositoryDB>()).Returns(partInvoiceRepository.Object);

            var partAvailabilityService = new Mock<Services.PartAvailabilityService.IPartAvailabilityService>();
            var availability = 0;
            partAvailabilityService.Setup(s => s.GetAvailability(It.IsAny<string>())).Returns(availability);
            ioc.Setup(c => c.Resolve<Services.PartAvailabilityService.IPartAvailabilityService>()).Returns(partAvailabilityService.Object);

            var partInvoiceController = new PartInvoiceController(ioc.Object);
            var stockCode = "PW";
            var quantity = 1;
            var customerName = "PineWood";

            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }

        [TestMethod]
        public void PartInvoiceControllerTests_CreatePartInvoice_Success()
        {
            var ioc = new Mock<IIoC>();

            var customerRepository = new Mock<ICustomerRepositoryDB>();
            Customer customer = new Customer
            {
                ID = 1,
                Name = "PineWood",
                Address = "UK"
            };
            customerRepository.Setup(r => r.GetByName(It.IsAny<string>())).Returns(customer);
            ioc.Setup(c => c.Resolve<ICustomerRepositoryDB>()).Returns(customerRepository.Object);

            var partInvoiceRepository = new Mock<IPartInvoiceRepositoryDB>();
            partInvoiceRepository.Setup(r => r.Add(It.IsAny<PartInvoice>()));
            ioc.Setup(c => c.Resolve<IPartInvoiceRepositoryDB>()).Returns(partInvoiceRepository.Object);

            var partAvailabilityService = new Mock<Services.PartAvailabilityService.IPartAvailabilityService>();
            var availability = 1;
            partAvailabilityService.Setup(s => s.GetAvailability(It.IsAny<string>())).Returns(availability);
            ioc.Setup(c => c.Resolve<Services.PartAvailabilityService.IPartAvailabilityService>()).Returns(partAvailabilityService.Object);

            var partInvoiceController = new PartInvoiceController(ioc.Object);
            var stockCode = "PW";
            var quantity = 1;
            var customerName = "PineWood";

            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == true);
        }
    }
}
