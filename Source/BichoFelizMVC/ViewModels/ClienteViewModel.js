$(document).ready(function () {
    ko.applyBindings(new ClienteViewModel());
});

//Inicia o ViewModel
function ClienteViewModel() {
    var self = this;
    self.NomeContato = ko.observable("");
    self.Cpf = ko.observable("");
    self.Endereco = ko.observable("");
    self.Bairro = ko.observable("");
    self.Cidade = ko.observable("");

    //Modelo empresa
    var cliente = {
        NomeContato: self.NomeContato,
        Cpf: self.Cpf,
        Endereco: self.Endereco,
        Bairro: self.Bairro,
        Cidade: self.Cidade,
        IdEmpresa: $("#idempresa").val()
    };

    self.cliente = ko.observable();
    self.clientes = ko.observableArray();

    self.cancel = function (emp) {
        self.NomeContato("");
        self.Cpf("");
        self.Endereco("");
        self.Bairro("");
        self.Cidade("");
    };

    //Get dados
    $.ajax({
        url: '/api/clienteapi?$filter=Perfil%20eq%201&IdEmpresa%20eq%20' + $("#idempresa").val(),
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.clientes(data);
        }
    });

    self.get = function() {
        $.ajax({
            url: '/api/clienteapi?$filter=startswith(NomeContato,%20' + $("#pesq").val() + ')',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: {},
            success: function (data) {
                self.clientes(data);
            }
        });
    };
    
    //Remove dados
    self.remove = function (cli) {
        if (confirm('Tem certeza que deseja desativar o cliente "' + cli.NomeContato + '"?')) {
            var id = cli.IdContato;
            $.ajax({
                url: '/api/clienteapi/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(id),
                success: function (data) {
                    self.clientes.remove(cli);
                }
            }).fail(function (xhr, textStatus, err) {
                alert(err);
            });
        }
    };

    //Adicionar itens
    self.add = function () {
        $.ajax({
            url: '/api/clienteapi/',
            type: 'POST',
            data: ko.toJSON(cliente),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                self.clientes.push(result);
                self.NomeContato("");
                self.Cpf("");
                self.Endereco("");
                self.Bairro("");
                self.Cidade("");
            }
        });
    };

    //Editar
    self.edit = function (user) {
        self.NomeContato(user.NomeContato);
        self.Cpf(user.Cpf);
        self.Endereco(user.Endereco);
        self.Bairro(user.Bairro);
        self.Cidade(user.Cidade);
    };

    //Efetuar update
    /*self.update = function () {
        var cli = new cliente();
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