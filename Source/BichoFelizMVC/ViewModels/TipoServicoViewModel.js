$(document).ready(function () {
    ko.applyBindings(new TipoServicoViewModel());
});

//Inicia o ViewModel
function TipoServicoViewModel() {
    var self = this;
    self.Nome = ko.observable("");

    //Modelo empresa
    var tipo = {
        Nome: self.Nome
    };

    self.tipo = ko.observable();
    self.tipos = ko.observableArray();
    
    self.cancel = function (emp) {
        self.Nome("");
    };

    //Get dados empresas
    $.ajax({
        url: '/api/tipoapi/',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.tipos(data);
        }
    });
    
    //Adicionar itens
    self.add = function () {
        $.ajax({
            url: '/api/tipoapi/',
            type: 'POST',
            data: ko.toJSON(tipo),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                self.tipos.push(result);
                self.Nome("");
            }
        });
    };

    //Remove dados
    self.remove = function (ti) {
        if (confirm('Tem certeza que deseja desativar o tipo "' + ti.Nome + '"?')) {
            var id = ti.IdTipoServico;
            $.ajax({
                url: '/api/tipoapi/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(id),
                success: function (data) {
                    self.tipos.remove(ti);
                }
            }).fail(function (xhr, textStatus, err) {
                alert(err);
            });
        }
    };

    /*//Get dados


    

    

    //Editar
    self.edit = function (user) {
        self.NomeContato(user.NomeContato);
        self.Cpf(user.Cpf);
        self.Endereco(user.Endereco);
        self.Bairro(user.Bairro);
        self.Cidade(user.Cidade);
        self.Estado(user.Estado);
        self.Email(user.Email);
        self.Senha("");
        self.ConfirmarSenha("");
    };

    //Efetuar update
    self.update = function () {
        var user = new usuario();
        user.NomeContato = self.NomeContato;
        user.Cpf = self.Cpf;
        user.Endereco = self.Endereco;
        user.Bairro = self.Bairro;
        user.Cidade = self.Cidade;
        user.Estado = self.Estado;
        user.Email = self.Email;
        user.Senha = self.Senha;
        user.ConfirmarSenha = self.ConfirmarSenha;
        $.ajax({
            url: '/api/empresaapi/' + user.IdContato.Id,
            cache: false,
            type: 'PUT',
            contentType: 'application/json',
            data: ko.toJSON(emp),
            success: function () {
                self.empresas.removeAll();
                self.empresas(data); //Put the response in ObservableArray
                self.empresas(null);
                alert("Registro atualizado com sucesso!");
            }
        }).fail(function (xhr, textStatus, err) {
            alert(err);
        });
    };*/
}