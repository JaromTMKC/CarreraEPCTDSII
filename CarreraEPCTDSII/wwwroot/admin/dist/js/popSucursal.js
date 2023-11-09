$(document).ready(function () {
    $('.delete-sucursal').on('click', function () {
        var IdSucursal = $(this).data('idventa');
        var NombreSucursal = $(this).data('nombre');

        $('#confirmarEliminacionSucursal').modal('show');

        $('#confirmarEliminacionSucursal .modal-body p').html('Seguro que deseas eliminar la sucursal?<br>ID: ' + IdSucursal + '<br>Nombre: ' + NombreSucursal);

        $('#deleteButtonSucursal').on('click', function () {
            $.post('/OCompra/ConfirmDelete', { id: IdSucursal }, function (data) {
                if (data.success) {
                    location.reload();
                } else {
                    alert('Error al eliminar el producto.');
                }
            });

            $('#confirmarEliminacionSucursal').modal('hide');
        });
    });
});