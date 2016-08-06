function ParelViewModel(parcel) {
    var self = this;
    self.weight = ko.observable(parcel.weight);
    self.width = ko.observable(parcel.width);
    self.heght = ko.observable(parcel.heght);
    self.depth = ko.observable(parcel.depth);
    self.fragile = ko.observable(parcel.fragile);
    self.hazardous = ko.observable(parcel.hazardous);
    self.perishable = ko.observable(parcel.perishable);
    self.price = ko.computed(function () {
        return self.weight * self.width * self.heght;
    }, this);
}