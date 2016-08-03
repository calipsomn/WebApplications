var ViewModel = function () {
    var self = this;
    //self.parcels = ko.observableArray();
    self.error = ko.observable();
    //self.detail = ko.observable();
    self.newParcel = {
        Weight: ko.observable(),
        Width: ko.observable(),
        Height: ko.observable(),
        Depth: ko.observable(),
        Fragile: ko.observable(),
        Hazardous: ko.observable(),
        Perishable: ko.observable(),
        Price: ko.observable(),
    };
    self.numberOfClicks = ko.observable(0);

    var parcelsUri = '/api/parcels/';
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
    };

    //function getAllParcels() {
    //    ajaxHelper(parcelsUri, 'GET').done(function (data) {
    //        self.parcels(data);
    //    });
    //}

    //function getParcel() {
    //    return parcel = {
    //        Weight: self.newParcel.Weight(),
    //        Width: self.newParcel.Width(),
    //        Height: self.newParcel.Height(),
    //        Fragile: self.newParcel.Fragile(),
    //        Depth: self.newParcel.Depth(),
    //        Hazardous: self.newParcel.Hazardous(),
    //        Perishable: self.newParcel.Perishable(),
    //        Price: self.newParcel.Price()
    //    };
    //}

    //self.getBookDetail = function (item) {
    //    ajaxHelper(parcelsUri + item.Id, 'GET').done(function (data) {
    //        self.newParcel.Price(data);
    //    });
    //}

    self.addParcel = function (formElement) {
        var parcel = {
            Weight: self.newParcel.Weight(),
            Width: self.newParcel.Width(),
            Height: self.newParcel.Height(),
            Fragile: self.newParcel.Fragile(),
            Depth: self.newParcel.Depth(),
            Hazardous: self.newParcel.Hazardous(),
            Perishable: self.newParcel.Perishable(),
            Price: self.newParcel.Price()
        };

        ajaxHelper(parcelsUri, 'POST', parcel).done(function (item) {
            self.parcels.push(item);
        });
    };

    self.UpdatePrice = function (formElement) {
        var parcel = {
            Weight: self.newParcel.Weight(),
            Width: self.newParcel.Width(),
            Height: self.newParcel.Height(),
            Fragile: self.newParcel.Fragile(),
            Depth: self.newParcel.Depth(),
            Hazardous: self.newParcel.Hazardous(),
            Perishable: self.newParcel.Perishable(),
            Price: self.newParcel.Price()
        };
        ajaxHelper(parcelsUri, 'GetPrice', parcel).done(function (data) {
            self.newParcel.Price(data);
        });
    }.bind(this);

    // Fetch the initial data.
    //getAllParcels();
    //self.newParcel.Weight.subscribe(function (newValue) {
    //    alert("The person's new name is " + newValue);
    //});
};
ko.applyBindings(new ViewModel());