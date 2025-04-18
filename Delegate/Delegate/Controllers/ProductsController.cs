using Delegate.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.CompilerServices;

namespace Delegate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Khởi tạo ProductService để quản lý sản phẩm
        private readonly ProductService _productService = new ProductService();

        // Phương thức GET để lấy danh sách tất cả sản phẩm
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(new { message = "Lấy danh sách sản phẩm thành công.", products });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi khi lấy danh sách sản phẩm: {ex.Message}" });
            }
        }

        // Phương thức POST để thêm sản phẩm mới
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            try
            {
                ProductService.ProductList addProd = _productService.AddProduct;
                addProd(newProduct); // Thực hiện hành động thêm sản phẩm thông qua delegate

                return CreatedAtAction(nameof(GetAllProducts), new { id = newProduct.Id }, new { message = "Thêm sản phẩm thành công.", product = newProduct });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi khi thêm sản phẩm: {ex.Message}" });
            }
        }

        // Phương thức PUT để cập nhật sản phẩm
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            try
            {
                updatedProduct.Id = id;
                ProductService.ProductList updateProd = _productService.UpdateProduct;
                updateProd(updatedProduct); // Thực hiện hành động cập nhật sản phẩm thông qua delegate

                return Ok(new { message = "Cập nhật sản phẩm thành công.", product = updatedProduct });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi khi cập nhật sản phẩm với ID {id}: {ex.Message}" });
            }
        }

        // Phương thức DELETE để xóa sản phẩm
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                ProductService.ProductOperationById deleteProd = _productService.DeleteProductById;
                deleteProd(id); // Thực hiện hành động xóa sản phẩm thông qua delegate

                return Ok(new { message = $"Sản phẩm với ID {id} đã được xóa thành công." }); // Thông báo thành công bằng tiếng Việt
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi khi xóa sản phẩm với ID {id}: {ex.Message}" }); // Thông báo lỗi
            }
        }

    }
}
