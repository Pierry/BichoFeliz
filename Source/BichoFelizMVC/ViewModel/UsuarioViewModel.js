$(document).ready(function() {
  ko.applyBindings(new usuarioViewModel);
});

function usuarioViewModel() {
  var self = this;
  self.Nome = ko.observable();
  self.Cpf = ko.observable();
  self.Endereco = ko.observable();
  self.Bairro = ko.observable();
  self.Cidade = ko.observable();
  self.Estado = ko.observable();
  self.Email = ko.observable();
  self.Senha = ko.observable();

  var usuario = {
    Nome: self.Nome,
    Cpf: self.Cpf,
    Endereco: self.Cpf,
    Bairro: self.Bairro,
    Cidade: self.Cidade,
    Estado: self.Estado,
    Email: self.Email,
    Senha: self.Senha
  };

  self.usuario = ko.observable();
  
  //Add
  self.add = function(usuario) {
    $.ajax({
      url: '/api/usuario/',
      type: 'POST',
      data: ko.toJSON(usuario),
      contentType: 'application/json',
      success: function () {
        alert('Inserido com sucesso');
      }
    });
  };
  

}
