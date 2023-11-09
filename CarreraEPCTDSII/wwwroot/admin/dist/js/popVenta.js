$(document).ready(function () {
    $('.delete-venta').on('click', function () {
        var IdVenta = $(this).data('idventa');
        var Nombre = $(this).data('nombre');
        var Cantidad = $(this).data('cantidad');

        $('#confirmarEliminacionVenta').modal('show');

        $('#confirmarEliminacionVenta .modal-body p').html('Seguro que deseas eliminar la venta?<br>ID: ' + IdVenta + '<br>Producto: ' + Nombre + '<br>Cantidad: ' + Cantidad);

        $('#deleteButtonVenta').on('click', function () {
            $.post('/OCompra/ConfirmDelete', { id: IdVenta }, function (data) {
                if (data.success) {
                    location.reload();
                } else {
                    alert('Error al eliminar la venta.');
                }
            });

            $('#confirmarEliminacionVenta').modal('hide');
        });
    });
});