$(document).ready(function () {
    $('.delete-product').on('click', function () {
        var IdProducto = $(this).data('idproducto');
        var NombreProducto = $(this).data('nombreproducto');

        $('#confirmarEliminacionProducto').modal('show');

        $('#confirmarEliminacionProducto .modal-body p').html('¿Seguro que deseas eliminar el producto?<br>ID: ' + IdProducto + '<br>Nombre: ' + NombreProducto);

        $('#deleteButtonProduct').on('click', function () {

            $.post('/Producto/ConfirmDelete', {id: IdProducto }, function (data) {
                if (data.success) {
                    console.log('Producto eliminado con éxito.');
                    location.reload();
                } else {
                    console.log('Error al eliminar el producto.');
                    alert('Error al eliminar el producto.');
                }
            });

            $('#confirmarEliminacionProducto').modal('hide');
        });
    });
});
