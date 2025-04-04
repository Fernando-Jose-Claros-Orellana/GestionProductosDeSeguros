CREATE PROCEDURE ObtenerProductos
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
    ORDER BY p.Nombre
END
GO