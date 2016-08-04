function AppViewModel() {
    this.error = ko.observable();
    var parcelsUri = '/api/parcels/';
    this.Weight = ko.observable(1.0);
    this.Width = ko.observable(1.0);
    this.Height = ko.observable(1.0);
    this.Depth = ko.observable(1.0);
    this.Fragile = ko.observable();
    this.Hazardous = ko.observable();
    this.Perishable = ko.observable();
    this.Price = ko.observable();
    //this.Price = ko.computed(function () {
    //    return this.Weight() * 2;
    //}, this);
    var parcelsUri = '/api/parcels/';
    function ajaxHelper(uri, method, data) {
        this.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            this.error(errorThrown);
        });
    };
    //this.ShowPrice = function (formElement) {
    //    $.ajax({
    //        url: parcelsUri + 'CalculatePrice',
    //        type: 'POST',
    //        data: JSON.stringify({ weight: this.Weght(), width: this.Width(), depth: this.Depth(), height: this.Height }),
    //        dataType: 'json',
    //        contentType: 'application/json; charset=utf-8',
    //        success: function (response) {
    //            this.Price(response);
    //        },
    //        error: function () {
    //            this.Price(0);
    //        }
    //    });
    this.ShowPrice = function (formElement) {
        //$.post(parcelsUri + 'CalculatePrice', { weight: this.Weght, width: this.Width, depth: this.Depth, height: this.Height },
        $.post(parcelsUri + 'CalculatePrice', { weight: 1.0, width: 1.0, depth: 1.0, height: 1.0 },
            function (returnedData) {
                console.log(returnedData);
            });
    }
};
ko.applyBindings(new AppViewModel());

//var ViewModel = function () {
//    var self = this;
//    //self.parcels = ko.observableArray();
//    self.error = ko.observable();
//    //self.detail = ko.observable();
//    self.newParcel = {
//        Weight: ko.observable(),
//        Width: ko.observable(),
//        Height: ko.observable(),
//        Depth: ko.observable(),
//        Fragile: ko.observable(),
//        Hazardous: ko.observable(),
//        Perishable: ko.observable(),
//        Price: Weight*2
//    };

//    var parcelsUri = '/api/parcels/';
//    //var authorsUri = '/api/authors/';

//    function ajaxHelper(uri, method, data) {
//        self.error(''); // Clear error message
//        return $.ajax({
//            type: method,
//            url: uri,
//            dataType: 'json',
//            contentType: 'application/json',
//            data: data ? JSON.stringify(data) : null
//        }).fail(function (jqXHR, textStatus, errorThrown) {
//            self.error(errorThrown);
//        });
//    };

//    //function getAllParcels() {
//    //    ajaxHelper(parcelsUri, 'GET').done(function (data) {
//    //        self.parcels(data);
//    //    });
//    //}

//    //function getParcel() {
//    //    return parcel = {
//    //        Weight: self.newParcel.Weight(),
//    //        Width: self.newParcel.Width(),
//    //        Height: self.newParcel.Height(),
//    //        Fragile: self.newParcel.Fragile(),
//    //        Depth: self.newParcel.Depth(),
//    //        Hazardous: self.newParcel.Hazardous(),
//    //        Perishable: self.newParcel.Perishable(),
//    //        Price: self.newParcel.Price()
//    //    };
//    //}

//    //self.getBookDetail = function (item) {
//    //    ajaxHelper(parcelsUri + item.Id, 'GET').done(function (data) {
//    //        self.newParcel.Price(data);
//    //    });
//    //}

//    self.addParcel = function (formElement) {
//        var parcel = {
//            Weight: self.newParcel.Weight(),
//            Width: self.newParcel.Width(),
//            Height: self.newParcel.Height(),
//            Fragile: self.newParcel.Fragile(),
//            Depth: self.newParcel.Depth(),
//            Hazardous: self.newParcel.Hazardous(),
//            Perishable: self.newParcel.Perishable(),
//            Price: self.newParcel.Price()
//        };

//        ajaxHelper(parcelsUri, 'POST', parcel).done(function (item) {
//            self.parcels.push(item);
//        });
//    };

//    self.updatePrice = function (formElement) {
//        var parcel = {
//            Weight: self.newParcel.Weight(),
//            Width: self.newParcel.Width(),
//            Height: self.newParcel.Height(),
//            Fragile: self.newParcel.Fragile(),
//            Depth: self.newParcel.Depth(),
//            Hazardous: self.newParcel.Hazardous(),
//            Perishable: self.newParcel.Perishable(),
//            Price: self.newParcel.Price()
//        };
//        ajaxHelper(parcelsUri, 'GetPrice', parcel).done(function (data) {
//            self.newParcel.Price(data);
//        });
//    }.bind(this);

//    // Fetch the initial data.
//    //getAllParcels();
//    //self.newParcel.Weight.subscribe(function (newValue) {
//    //    alert("The person's new name is " + newValue);
//    //});
//};
//ko.applyBindings(new ViewModel());