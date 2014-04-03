$(document).ready(function () {
    ko.applyBindings(new ServicoViewModel());
});

//Inicia o ViewModel
function ServicoViewModel() {
    var self = this;
    self.IdServico = ko.observable("");
    self.Data = ko.observable("");

    self.cliente = ko.observable();
    self.clientes = ko.observableArray();
    self.animais = ko.observableArray();
    self.tipos = ko.observableArray();
    self.periodos = ko.observableArray(["Matutino", "Vespertino"]);
    self.servicos = ko.observableArray();
    self.cli = ko.observable("");
    self.anim = ko.observable("");
    self.perio = ko.observable("");
    self.tiposerv = ko.observable("");

    self.cancel = function (emp) {
        self.Data("");
    };

    var servico = {
        IdContato: self.cli,
        IdAnimal: self.anim,
        IdTipoServico: self.tiposerv,
        DataHora: self.Data,
        Status: 1,
        Periodo: self.perio,
    };

    //Get dados clientes
    $.ajax({
        url: '/api/clienteapi?$filter=Perfil%20eq%201&IdEmpresa%20eq%20' + $("#idempresa").val(),
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.clientes(data);
        }
    });



    //Get dados animais
    $.ajax({
        url: '/api/animalapi?$filter=IdEmpresa%20eq%20' + $("#idempresa").val(),
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.animais(data);
        }
    });

    //Get dados tipos
    $.ajax({
        url: '/api/tipoapi/',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.tipos(data);
        }
    });
    
    //Get dados servicos
    $.ajax({
        url: '/api/servico/',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.servicos(data);
        }
    });
    
    //Get dados servicos
    self.get = function() {
        $.ajax({
            url: '/api/servico/',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: {},
            success: function(data) {
                self.servicos(data);
            }
        });
    };

    //Adicionar itens
    self.add = function () {
        $.ajax({
            url: '/api/servico/',
            type: 'POST',
            data: ko.toJSON(servico),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                self.servicos.push(result);
                self.Data("");
            }
        });
    };
    
     //Remove dados
     self.remove = function (serv) {
         if (confirm('Tem certeza que deseja desativar o serviço "' + serv.NomeContato + '"?')) {
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
 
    /*
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
     };*/
}