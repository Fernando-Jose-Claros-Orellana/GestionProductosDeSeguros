CREATE PROCEDURE CrearProducto (
    @Nombre VARCHAR(100),
    @Descripcion TEXT,
    @TipoProductoNombre VARCHAR(100),
    @FormaPagoNombre VARCHAR(50),
    @PrimaAnual DECIMAL(18, 2),
    @SumaAsegurada DECIMAL(18, 2)
)
AS
BEGIN
    -- Validar que el Tipo de Producto exista
    IF NOT EXISTS (SELECT 1 FROM TiposProducto WHERE NombreTipo = @TipoProductoNombre)
    BEGIN
        RAISERROR('El Tipo de Producto especificado no existe.', 16, 1)
        RETURN
    END

    -- Validar que la Forma de Pago exista
    IF NOT EXISTS (SELECT 1 FROM FormasPago WHERE Nombre = @FormaPagoNombre)
    BEGIN
        RAISERROR('La Forma de Pago especificada no existe.', 16, 1)
        RETURN
    END

    -- Validar Prima Anual vs Suma Asegurada
    IF @PrimaAnual >= @SumaAsegurada
    BEGIN
        RAISERROR('La Prima Anual debe ser menor que la Suma Asegurada.', 16, 1)
        RETURN
    END

    -- Validar Prima Anual máxima
    IF @PrimaAnual > 300.00
    BEGIN
        RAISERROR('La Prima Anual no puede ser mayor a $300.00.', 16, 1)
        RETURN
    END

    -- Obtener los IDs
    DECLARE @TipoProductoID INT
    SELECT @TipoProductoID = TipoProductoID FROM TiposProducto WHERE NombreTipo = @TipoProductoNombre

    DECLARE @FormaPagoID INT
    SELECT @FormaPagoID = FormaPagoID FROM FormasPago WHERE Nombre = @FormaPagoNombre

    -- Insertar el nuevo producto
    INSERT INTO Productos (Nombre, Descripcion, TipoProductoID, FormaPagoID, PrimaAnual, SumaAsegurada)
    VALUES (@Nombre, @Descripcion, @TipoProductoID, @FormaPagoID, @PrimaAnual, @SumaAsegurada)

    -- Devolver el ID del producto creado
    SELECT SCOPE_IDENTITY() AS ProductoID
END
GO
GO
