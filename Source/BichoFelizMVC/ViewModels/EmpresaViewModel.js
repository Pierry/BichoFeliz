$(document).ready(function () {
    ko.applyBindings(new EmpresaViewModel());
});

//Inicia o ViewModel
function EmpresaViewModel() {
    var self = this;
    self.IdEmpresa = ko.observable("");
    self.Cnpj = ko.observable("");
    self.Nome = ko.observable("");
    //Modelo empresa
    var empresa = {
        IdEmpresa: self.IdEmpresa,
        Cnpj: self.Cnpj,
        Nome: self.Nome,
    };
    self.empresa = ko.observable();
    self.empresas = ko.observableArray();

    self.cancel = function (emp) {
        self.Cnpj("");
        self.Nome("");
    };

    //Get dados
    $.ajax({
        url: '/api/empresaapi',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.empresas(data);
        }
    });

    self.get = function () {
        $.ajax({
            url: '/api/empresaapi?$filter=startswith(Nome,%20' + $("#pesq").val() + ')',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: {},
            success: function (data) {
                self.empresas(data);
            }
        });
    };

    //Remove dados
    self.remove = function(emp) {
        if (confirm('Tem certeza que deseja desativar a empresa "' + emp.Nome + '"?')) {
            var id = emp.IdEmpresa;

            $.ajax({
                url: '/api/empresaapi/'+ id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(id),
                success: function(data) {
                    self.empresas.remove(emp);
                }
            }).fail(function(xhr, textStatus, err) {
                alert(err);
            });
        }
    };

    //Adicionar itens
    self.add = function () {
        $.ajax({
            url: '/api/empresaapi/',
            type: 'POST',
            data: ko.toJSON(empresa),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                    self.empresas.push(result);
                    self.Cnpj("");
                    self.Nome("");
            }
        });
    };

    //Editar
    self.edit = function (emp) {
        self.Cnpj(emp.Cnpj);
        self.Nome(emp.Nome);
    };

    //Efetuar update
    self.update = function () {
        var emp = new empresa();
        emp.Cnpj = self.Cnpj;
        emp.Node = self.Nome;
        emp.IdEmpresa = self.IdEmpresa;
        $.ajax({
            url: '/api/empresaapi/' + emp.Id,
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