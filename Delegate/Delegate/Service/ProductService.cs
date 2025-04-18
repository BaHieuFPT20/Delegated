namespace Delegate.Service
{
    public class ProductService
    {
        public delegate void ProductList(Product product);

        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000.00, Quantity = 10 },
            new Product { Id = 2, Name = "Điện thoại", Price = 500.00, Quantity = 20 },
            new Product { Id = 3, Name = "Máy tính bảng", Price = 300.00, Quantity = 20 }

        };

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int id)
        {
            return _products.Find(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
            }
        }

        public delegate void ProductOperationById(int id);

        public void DeleteProductById(int id)
        {
            var product = _products.Find(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
