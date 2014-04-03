$(document).ready(function () {
    ko.applyBindings(new AnimalViewModel());
});

//Inicia o ViewModel
function AnimalViewModel() {
    var self = this;
    self.Nome = ko.observable("");
    self.IdContato = ko.observable("");
    self.cli = ko.observable("");
    self.NomeCliente = ko.observable("");
    
    //Modelo empresa
    var animal = {
        Nome: self.Nome,
        IdContato: self.cli,
        NomeCliente: self.NomeCliente
    };

    var cliente = {
        NomeContato: ko.observable(""),
        Cpf: ko.observable(""),
        Endereco: ko.observable(""),
        Bairro: ko.observable(""),
        Cidade: ko.observable(""),
    };

    self.animal = ko.observable();
    self.animais = ko.observableArray();
    self.clientes = ko.observableArray();

    self.cancel = function (emp) {
        self.Nome("");
    };

    //Get dados empresas
    $.ajax({
        url: '/api/clienteapi?$filter=IdEmpresa%20eq%20' + $("#idempresa").val(),
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.clientes(data);
        }
    });

    self.get = function() {
        $.ajax({
            url: '/api/animalapi?$filter=startswith(Nome,%20' + $("#pesq").val() + ')',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: {},
            success: function (data) {
                self.animais(data);
            }
        });
    };

    $.ajax({
        url: '/api/animalapi/',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.animais(data);
        }
    });

    self.get = function() {
        $.ajax({
            url: '/api/animalapi?$filter=startswith(Nome,%20' + $("#pesq").val() + ')',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: {},
            success: function(data) {
                self.animais(data);
            }
        });
    };

    //Adicionar itens
    self.add = function () {
        $.ajax({
            url: '/api/animalapi/',
            type: 'POST',
            data: ko.toJSON(animal),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                self.animais.push(result);
                self.Nome("");
            }
        });
    };

    //Remove dados
    self.remove = function (anim) {
        if (confirm('Tem certeza que deseja desativar o animal "' + anim.Nome + '"?')) {
            var id = anim.IdAnimal;
            $.ajax({
                url: '/api/animalapi/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(id),
                success: function (data) {
                    self.animais.remove(anim);
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