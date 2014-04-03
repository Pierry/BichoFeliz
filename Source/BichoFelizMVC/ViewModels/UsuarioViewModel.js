$(document).ready(function () {
    ko.applyBindings(new UsuarioViewModel());
});

//Inicia o ViewModel
function UsuarioViewModel() {
    var self = this;
    self.IdContato = ko.observable("");
    self.NomeContato = ko.observable("");
    self.Cpf = ko.observable("");
    self.Endereco = ko.observable("");
    self.Bairro = ko.observable("");
    self.Cidade = ko.observable("");
    self.Estado = ko.observable("");
    self.Emp = ko.observable("");
    self.Email = ko.observable("");
    self.Senha = ko.observable("");
    self.ConfirmarSenha = ko.observable("");

    //Modelo empresa
    var usuario = {
        NomeContato: self.NomeContato,
        Cpf: self.Cpf,
        Endereco: self.Endereco,
        Bairro: self.Bairro,
        Cidade: self.Cidade,
        Estado: self.Estado,
        Email: self.Email,
        IdEmpresa: self.Emp,
        Senha: self.Senha,
        ConfirmarSenha: self.ConfirmarSenha
    };

    

    var empresa = {
        IdEmpresa: self.IdEmpresa,
        Nome: self.Nome,
        Cnpj: self.Cnpj
    };

    self.usuario = ko.observable();
    self.usuarios = ko.observableArray();
    self.empresas = ko.observableArray();
    
    self.cancel = function (emp) {
        self.NomeContato("");
        self.Cpf("");
        self.Endereco("");
        self.Bairro("");
        self.Cidade("");
        self.Estado("");
        self.Email("");
        self.Senha("");
        self.ConfirmarSenha("");
    };

    //Get dados empresas
    $.ajax({
        url: '/api/empresaapi/',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.empresas(data);
        }
    });

    //Get dados
    $.ajax({
        url: '/api/contatoapi/',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.usuarios(data);
        }
    });
    
    //Remove dados
    self.remove = function (user) {
        if (confirm('Tem certeza que deseja desativar o usuário "' + user.NomeContato + '"?')) {
            var id = user.IdContato;
            $.ajax({
                url: '/api/usuarioapi/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(id),
                success: function (data) {
                    self.usuarios.remove(user);
                }
            }).fail(function (xhr, textStatus, err) {
                alert(err);
            });
        }
    };

    //Adicionar itens
    self.add = function () {
        $.ajax({
            url: '/api/usuarioapi/',
            type: 'POST',
            data: ko.toJSON(usuario),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                self.usuarios.push(result);
                self.NomeContato("");
                self.Cpf("");
                self.Endereco("");
                self.Bairro("");
                self.Cidade("");
                self.Estado("");
                self.Email("");
                self.Senha("");
                self.ConfirmarSenha("");
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
    };
}