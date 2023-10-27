using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaIdentityContext context = new DL.IespinozaIdentityContext())
                {
                    var query = context.Productos.FromSqlRaw($"ProductoGetAll").ToList();

                    if (query.Count > 0) 
                    { 
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.Nombre;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaIdentityContext context = new DL.IespinozaIdentityContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ProductoAdd '{producto.Nombre}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}