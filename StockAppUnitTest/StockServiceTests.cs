using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System.ComponentModel.DataAnnotations;

namespace StockAppUnitTest
{
    public class StockServiceTests
    {
        private readonly IStockService _stockService;
        public StockServiceTests()
        {
            _stockService = new StocksService();
        }

        #region CreateBuyOrder Tests
        [Fact]
        public void CreateBuyOrder_NullBuyOrderRequest()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => _stockService.CreateBuyOrder(buyOrderRequest));

        }

        [Fact]
        public void CreateBuyOrder_InvalidMinimumQuantity()
        {
            //Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 0,
                Price = 100
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateBuyOrder(buyOrderRequest));
        }

        [Fact]
        public void CreateBuyOrder_InvalidMaximumQuantity()
        {
            // Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100001,
                Price = 100
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateBuyOrder(buyOrderRequest));
        }

        [Fact]
        public void CreateBuyOrder_InvalidMinimumPrice()
        {
            // Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100,
                Price = 0
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateBuyOrder(buyOrderRequest));
        }

        [Fact]
        public void CreateBuyOrder_InvalidMaximumPrice()
        {
            // Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100,
                Price = 10001
            };
            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateBuyOrder(buyOrderRequest));
        }

        [Fact]
        public void CreateBuyOrder_NullStockSymbol()
        {
            // Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = null,
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100,
                Price = 100
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateBuyOrder(buyOrderRequest));
        }

        [Fact]
        public void CreateBuyOrder_InvalidDateAndTimeOfOrder()
        {
            // Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = null,
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"),
                Quantity = 100,
                Price = 100
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateBuyOrder(buyOrderRequest));
        }

        [Fact]
        public void CreateBuyOrder_ValidBuyOrderRequest()
        {
            // Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100,
                Price = 100
            };

            // Act
            BuyOrderResponse buyOrderResponseFromCreate = _stockService.CreateBuyOrder(buyOrderRequest);

            // Assert
            Assert.NotEqual(Guid.Empty, buyOrderResponseFromCreate.BuyOrderID);
        }
        #endregion

        #region CreateSellOrder Test
        [Fact]
        public void CreateSellOrder_NullSellOrderRequest()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => _stockService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_InvalidMinimumQuantity()
        {
            // Arrange
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 0,
                Price = 100
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_InvalidMaximumQuantity()
        {
            // Arrange
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100001,
                Price = 100
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_InvalidMinimumPrice()
        {
            // Arrange
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100,
                Price = 0
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_InvalidMaximumPrice()
        {
            // Arrange
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100,
                Price = 10001
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_NullStockSymbol()
        {
            // Arrange
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = null,
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100,
                Price = 100
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_InvalidDateAndTimeOfOrder()
        {
            // Arrange
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"),
                Quantity = 100,
                Price = 100
            };
            // Assert
            Assert.Throws<ArgumentException>(() => _stockService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_ValidSellOrderRequest()
        {
            // Arrange
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "AAPL",
                StockName = "Apple Inc.",
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = 100,
                Price = 100
            };

            // Act
            SellOrderResponse sellOrderResponseFromCreate = _stockService.CreateSellOrder(sellOrderRequest);

            // Assert
            Assert.NotEqual(Guid.Empty, sellOrderResponseFromCreate.SellOrderID);
        }
        #endregion
    }
}