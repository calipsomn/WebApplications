function ParcelDetailViewModel(model) {
    self.cartItem = {
        cartId: cartSummaryViewModel.cart.id,
        quantity: ko.observable(1),
        parcel: model
    };
}