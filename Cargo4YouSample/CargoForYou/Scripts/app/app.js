function AppViewModel() {
    this.Weight = ko.observable();
    this.Width = ko.observable();
    this.Height = ko.observable();
    this.Depth = ko.observable();
    this.Fragile = ko.observable();
    this.Hazardous = ko.observable();
    this.Perishable = ko.observable();
    this.Price = ko.computed(function () {
        return this.Weight()*2;
    }, this);
    var parcelsUri = '/api/parcels/';
};
ko.applyBindings(new AppViewModel());