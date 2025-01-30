using ShoppingCartProject.Models;

namespace TestCodeShoppingCart
{
    public class UnitTest1
    {
        [Fact]
        public void AddProduct_IncreasesProductCount()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act
            cart.AddProduct("Alma", 1.5);

            // Assert
            Assert.Equal(1, cart.ProductCount);
        }

        [Fact]
        public void RemoveProduct_DecreasesProductCount()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddProduct("Alma", 1.5);

            // Act
            cart.RemoveProduct("Alma");

            // Assert
            Assert.Equal(0, cart.ProductCount);
        }

        [Fact]
        public void GetTotalPrice_ReturnsCorrectSum()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddProduct("Alma", 1.5);
            cart.AddProduct("Banán", 2.0);

            // Act
            double totalPrice = cart.GetTotalPrice();

            // Assert
            Assert.Equal(3.5, totalPrice);
        }

        [Fact]
        public void RemoveProduct_ThrowsException_IfProductNotInCart_Empty()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => cart.RemoveProduct("Alma"));
        }

        [Fact]
        public void RemoveProduct_ThrowsException_IfProductNotInCart_NotEmpty()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddProduct("Füge", 23);
            cart.AddProduct("Citrom", 18);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => cart.RemoveProduct("Alma"));
        }

        [Fact]
        public void GetProducts_ReturnsCorrectProducts()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddProduct("Alma", 1.5);
            cart.AddProduct("Banán", 2.0);

            // Act
            var products = cart.GetProducts();

            // Assert
            Assert.Equal(2, products.Count);
            Assert.Contains(products, p => p.Name == "Alma" && p.Price == 1.5);
            Assert.Contains(products, p => p.Name == "Banán" && p.Price == 2.0);
        }

        [Fact]
        public void ProductAlreadyExists_ShouldAddProduct_WhenProductDoesNotExist()
        {
            // Arrange
            string newProductName = "NewProduct";
            double price = 20.0;
            var cart = new ShoppingCart();

            // Act
            bool result = cart.ProductAlreadyExists(newProductName, price);

            // Assert
            Assert.True(result);
            Assert.Contains(cart.GetProducts(), p => p.Name.Equals(newProductName, StringComparison.OrdinalIgnoreCase));
        }
    }
}