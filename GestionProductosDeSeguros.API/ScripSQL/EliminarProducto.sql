CREATE PROCEDURE EliminarProducto (
    @ProductoID INT
)
AS
BEGIN
    -- Validar que el producto exista
    IF NOT EXISTS (SELECT 1 FROM Productos WHERE ProductoID = @ProductoID)
    BEGIN
        RAISERROR('El Producto con el ID especificado no existe.', 16, 1)
        RETURN
    END

    -- Eliminar el producto
    DELETE FROM Productos
    WHERE ProductoID = @ProductoID
END
GO