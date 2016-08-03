var ViewModel = function () {
    var self = this;
    self.parcels = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.authors = ko.observableArray();
    self.newBook = {
        Author: ko.observable(),
        Genre: ko.observable(),
        Price: ko.observable(),
        Title: ko.observable(),
        Year: ko.observable()
    }

    var booksUri = '/api/parcels/';
    //var authorsUri = '/api/authors/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllParcels() {
        ajaxHelper(parcelsUri, 'GET').done(function (data) {
            self.parcels(data);
        });
    }

    self.getBookDetail = function (item) {
        ajaxHelper(parcelsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    //function getAuthors() {
    //    ajaxHelper(authorsUri, 'GET').done(function (data) {
    //        self.authors(data);
    //    });
    //}


    self.addPrcel = function (formElement) {
        var parcel = {
            AuthorId: self.newBook.Author().Id,
            Genre: self.newBook.Genre(),
            Price: self.newBook.Price(),
            Title: self.newBook.Title(),
            Year: self.newBook.Year()
        };

        ajaxHelper(parcelsUri, 'POST', parcel).done(function (item) {
            self.parcels.push(item);
        });
    }

    // Fetch the initial data.
    getAllParcels();
    //getAuthors();
};

ko.applyBindings(new ViewModel());