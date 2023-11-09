$(document).ready(function () {
    $('.delete-sucursal').on('click', function () {
        var IdSucursal = $(this).data('idsucursal');
        var NombreSucursal = $(this).data('nombresucursal');

        $('#confirmarEliminacionSucursal').modal('show');

        $('#confirmarEliminacionSucursal .modal-body p').html('Seguro que deseas eliminar la sucursal?<br>ID: ' + IdSucursal + '<br>Nombre: ' + NombreSucursal);

        $('#deleteButtonSucursal').on('click', function () {
            $.post('/Sucursal/ConfirmDelete', { id: IdSucursal }, function (data) {
                if (data.success) {
                    location.reload();
                } else {
                    alert('Error al eliminar la sucursal.');
                }
            });

            $('#confirmarEliminacionSucursal').modal('hide');
        });
    });
});