-- Procedimiento Almacenado para Buscar un Producto por ID
CREATE PROCEDURE ObtenerProductoPorId (
    @ProductoID INT
)
AS
BEGIN
    SELECT
        p.ProductoID,
        p.Nombre,
        p.Descripcion,
        tp.NombreTipo AS TipoProducto,
        fp.Nombre AS FormaPago,
        p.PrimaAnual,
        p.SumaAsegurada,
        (p.PrimaAnual * fp.Factor) AS PrimaCalculada
    FROM Productos p
    JOIN TiposProducto tp ON p.TipoProductoID = tp.TipoProductoID
    JOIN FormasPago fp ON p.FormaPagoID = fp.FormaPagoID
    WHERE p.ProductoID = @ProductoID;
END
GO