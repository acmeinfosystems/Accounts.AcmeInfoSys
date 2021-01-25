$(document).ready(function () {
    // Initializes dialogs 
    $("#loginModule").dialog({
        autoOpen: false, modal: true, show: "blind", hide: "blind", width: "400px"
    });
    $("#journalEntryModule").dialog({
        autoOpen: false, modal: true, show: "blind", hide: "blind", width: "500px"
    });    
    // Initializes date picker    
    $("#transactionDate").datepicker({ dateFormat: 'mm/dd/yy' });
});

function PromptLogin() {
    $("#loginModule").dialog("open");
    return false;
}

function NewJournalEntry() {  
    $("#journalEntryModule").dialog("open");    
    return false;
}

function CloseJournalEntry() {
    $("#journalEntryModule").dialog("close");
    return false;
}
