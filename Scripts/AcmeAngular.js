var app = angular.module('acmeApp', ["ngTable"]);

app.controller('accountController', function ($scope, $http, NgTableParams) {
    
    //// ---- Section User ------

    $scope.loginError = '';

    $scope.login = {
        Username: '',
        Password: ''
    };

    $scope.validateUser = function () {        
        $("#btnLogin").prop("disabled", true);
        $("body").css("cursor", "progress");
        
        $http.post('/Api/CheckLogin', $scope.login).then(
            function (response) {     
                location.href = '/Home/Index';
            },
            function (error) {                
                $scope.loginError = error.statusText;
                console.log(error);
                $("#btnLogin").prop("disabled", false);
                $("body").css("cursor", "default");
            }
        );
    }

    //// ---- Section Journal ------

    $scope.journalEntryError = '';
    $scope.journalSuccessMessage = '';

    $scope.ClearJournalEntry = function () {
        $scope.journal = {
            Id: 0,
            TransactionDate: '',
            Name: '',
            Entry: 'CR',
            Amount: '',
            Particulars: ''
        };
    }

    $scope.ClearJournalEntry();    

    $scope.getJournalData = function () {
        $("body").css("cursor", "progress");
        $http.get('/Api/GetJournalEntries').then(
            function (response) {
                $scope.tableParams = new NgTableParams({}, { dataset: response.data }); 
                $("body").css("cursor", "default");
            },
            function (error) {
                console.log(error);
                $("body").css("cursor", "default");
            }
        );    
    }    

    $scope.SaveJournalEntry = function () {
        $("#btnSaveJournal").prop("disabled", true);
        $("body").css("cursor", "progress");
        $http.post('/Api/SaveJournalEntry', $scope.journal).then(
            function (response) {
                $("#journalEntryModule").dialog("close");                
                $scope.getJournalData();
                $scope.journalSuccessMessage = $scope.journal.Id == 0 ? 'Journal Entry added Successfully!' : 'Journal Entry updated Successfully!';
                $scope.ClearJournalEntry(); 
                $("#btnSaveJournal").prop("disabled", false);
                $("body").css("cursor", "default");
            },
            function (error) {
                $scope.journalEntryError = error.statusText;
                console.log(error);
                $("#btnSaveJournal").prop("disabled", false);
                $("body").css("cursor", "default");
            }
        );
    }

    $scope.MakeEntryEditable = function (data) {
        $scope.journal = {
            Id: data.Id,
            TransactionDate: data.Date,
            Name: data.Name,
            Entry: data.Entry,
            Amount: data.Amount,
            Particulars: data.Particulars
        };
        $("#journalEntryModule").dialog("open");
    }

});