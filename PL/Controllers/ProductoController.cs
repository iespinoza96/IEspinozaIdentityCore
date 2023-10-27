using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAll();

            ML.Producto producto = new ML.Producto();

            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error en la consulta";
            }
            return View(producto);
        }
    }
}
