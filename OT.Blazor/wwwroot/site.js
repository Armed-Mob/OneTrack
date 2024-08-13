console.log("JavaScript file loaded");
window.modals = {
    openModal: function (modalId) {
        var modalElement = document.getElementById(modalId);
        var modalInstance = new bootstrap.Modal(modalElement);
        modalInstance.show();
    },
    closeModal: function (modalId) {
        console.log("Closing modal: " + modalId);
        var modalElement = document.getElementById(modalId);
        var modalInstance = bootstrap.Modal.getInstance(modalElement);
        if (modalInstance) {
            modalInstance.hide();
        }
    }
};