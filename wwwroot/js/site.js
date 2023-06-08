$(document).ready(function () {
    $('.produto-checkbox').each((index, elem) => {
        var elementoCheckbox = this
        $(elementoCheckbox).change(function () {
            $('.produto').each((ind, prod) => {
                var elemProdNome = $(prod).children().eq(1).children().eq(0).text()
                if ($(elem).is(':checked')) {
                    if ($(elem).val() == elemProdNome) {
                        $(prod).show()
                    }
                } else {
                    if ($(elem).val() == elemProdNome) {
                        $(prod).hide()
                    }
                }
            })
        })
    })

    $('#form-cadastro-produto').submit(function () {
        var padrao = /^\d{1,3},\d{2}$/;

        if (!padrao.test($('#preco').val())) {
            alert('Preço inválido')
            return false;
        }
    })

    $('#form-cadastro-produto').validate({
        messages: {
            Nome: 'Digite o nome',
            Tamanho: 'Digite o tamanho',
            Preco: 'Digite o preço'
        }
    })

    $('.close-alert').click(() => {
        $('.alert').hide()
    })
})

//$('.produto').each((index, elemento) => {
//    $(elemento).find('*').eq(1).children().css({ 'background-color': 'red' })

//    OU FAZER ASSIM

//    $(elemento).find('h5').css({ 'background-color': 'red' })
//})