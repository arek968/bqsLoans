
var LoanViewModel = function () {
    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI
    self.Month = ko.observable("0");
    self.Capital = ko.observable("0");
    self.Interest = ko.observable("0");
    self.Amount = ko.observable("0");
    //The Object which stored data entered in the observables
    var InstallmentData = {
        Month: self.Month,
        Capital: self.Capital,
        Interest: self.Interest,
        Amount: self.Amount
    };

    //Declare an ObservableArray for Storing the JSON Response
    self.Installments = ko.observableArray();

    //The Function which gets all records using ajax call
    self.GetInstallments= function() {
        //Loads static data for testing
        // self.Installments = JSON.parse('[{"Month":1,"Capital":833.33,"Interest":29.17,"Payment":862.50},{"Month":2,"Capital":833.33,"Interest":26.74,"Payment":860.07},{"Month":3,"Capital":833.33,"Interest":24.31,"Payment":857.64},{"Month":4,"Capital":833.33,"Interest":21.88,"Payment":855.21},{"Month":5,"Capital":833.33,"Interest":19.44,"Payment":852.77},{"Month":6,"Capital":833.33,"Interest":17.01,"Payment":850.34},{"Month":7,"Capital":833.33,"Interest":14.58,"Payment":847.91},{"Month":8,"Capital":833.33,"Interest":12.15,"Payment":845.48},{"Month":9,"Capital":833.33,"Interest":9.72,"Payment":843.05},{"Month":10,"Capital":833.33,"Interest":7.29,"Payment":840.62},{"Month":11,"Capital":833.33,"Interest":4.86,"Payment":838.19},{"Month":12,"Capital":833.33,"Interest":2.43,"Payment":835.76}]');
        //data from the server

        var strLoanDecreasingAPI = "../api/LoanDecreasing?LoanType=Housing&PaybackTime=" + document.getElementById("PaybackTime").value + "&Amount=" + document.getElementById("Amount").value;
        $.getJSON(strLoanDecreasingAPI, function (data, status, xhr) {

            self.Installments(data);
        })
    }

    self.removeInstallments = function () {
        self.Installments.removeAll();
    }
}
function showValues() {
    var str = $("form").serialize();
    $("#results").text(str);
}

ko.applyBindings(new LoanViewModel());    
var btnSubmit = document.getElementById('btnSubmit');

btnSubmit.addEventListener('click', function (e) {
    var PaybackTime = document.getElementById('PaybackTime');
    var Amount = document.getElementById('Amount');
    if (PaybackTime.value.match(/^[0-9]+$/) == null) {
        e.preventDefault;
        PaybackTime.setCustomValidity('Enter valid number!');
    } else {
        PaybackTime.setCustomValidity('');
    }
    if (Amount.value.match(/^[0-9]+$/) == null) {
        e.preventDefault;
        Amount.setCustomValidity('Enter valid number!');
    } else {
        Amount.setCustomValidity('');
    }
});
